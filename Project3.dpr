library Project3;

{ Important note about DLL memory management: ShareMem must be the
  first unit in your library's USES clause AND your project's (select
  Project-View Source) USES clause if your DLL exports any procedures or
  functions that pass strings as parameters or function results. This
  applies to all strings passed to and from your DLL--even those that
  are nested in records and classes. ShareMem is the interface unit to
  the BORLNDMM.DLL shared memory manager, which must be deployed along
  with your DLL. To avoid using BORLNDMM.DLL, pass string information
  using PChar or ShortString parameters. }

uses
  SysUtils,
  Classes;

{$R *.res}

function GetString(Buf: PChar; BufLen: Integer): Integer;

var

 S: string;

begin
  S:='F';

 if BufLen > 0 then StrLCopy(Buf, PChar(S), BufLen - 1);

 Result:= Length(S) + 1;

end;

function FuncName():PChar;stdcall;export;
const

 StatBufSize =1;

var

 StatBuf: array[0..StatBufSize - 1] of Char;

 Buf: PChar;

 RealLen: Integer;

begin
 StatBuf:='';

 RealLen:= GetString(StatBuf, StatBufSize);

 if RealLen > StatBufSize then

 begin
 Buf:= StrAlloc(RealLen);
 GetString(Buf, RealLen);
 end

 else
 Buf:= StatBuf;
 Result:=Buf;

 if Buf <> StatBuf then StrDispose(Buf);

end;

function TheFunc

exports
FuncName name 'FuncName';

begin

end.
 