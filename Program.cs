using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace Lab2._2
{
    public interface IClassLibrary
    {
        char CallTheFuncName();

        double CallTheFunc(double x);
    }
    public  class ClassLibrary1:IClassLibrary
    {
        [DllImport("Lib.dll", CallingConvention = CallingConvention.Cdecl)] /*импорт dll*/
        public static extern double TheFunc(double x);
        [DllImport("Lib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern char FuncName();

        public char CallTheFuncName()
        {
            try { return FuncName(); }
            catch { return ('-'); }
        }
        public double CallTheFunc(double x)
        {
            try { return TheFunc(x); }
            catch { throw new Exception("График не может быть построен"); }
        }
    }
    class Library2: IClassLibrary
    {
        [DllImport("Lib2-2-1.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-2-1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern char FuncName();

        public  char CallTheFuncName()
        {
            try { return FuncName(); }
            catch { return ('-'); }
        }
        public double CallTheFunc(double x)
        {
            try { return TheFunc(x); }
            catch { throw new Exception("График не может быть построен"); }
        }
    }
    class Library3:IClassLibrary
    {
        [DllImport("Lib2-2-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-2-2.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern char FuncName();

        public char CallTheFuncName()
        {
            try { return FuncName(); }
            catch { return ('-'); }
        }
        public double CallTheFunc(double x)
        {
            try { return TheFunc(x); }
            catch { throw new Exception("График не может быть построен"); }
        }
    }
    class Library4 : IClassLibrary
    {
        [DllImport("Lib2-2-3-1.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-2-3-1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern char FuncName();

        public char CallTheFuncName()
        {
            try { return FuncName(); }
            catch { return '-'; }
        }
        public double CallTheFunc(double x)
        {
            try { return TheFunc(x); }
            catch { throw new Exception("График не может быть построен"); }
        }
    }
    class Library5 : IClassLibrary
    {
        [DllImport("Lib2-3-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-3-2.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern char FuncName();

        public char CallTheFuncName()
        {
            try { return FuncName(); }
            catch { return ('-'); }
        }
        public double CallTheFunc(double x)
        {
            try { return TheFunc(x); }
            catch { throw new Exception("График не может быть построен"); }
        }
    }
    class Library6 : IClassLibrary
    {
        [DllImport("Lib2-2-3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-2-3.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern char FuncName();

        public char CallTheFuncName()
        {
            try { return FuncName(); }
            catch { return '-'; }
        }
        public double CallTheFunc(double x)
        {
            try { return TheFunc(x); }
            catch { throw new Exception("График не может быть построен"); }
        }
    }
    class MyLibrary : IClassLibrary
    {
        [DllImport("Project3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc(double x);
        [DllImport("Project3.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern char FuncName();

        public char CallTheFuncName()
        {
            try { return FuncName(); }
            catch { return '-'; }
        }
        public double CallTheFunc(double x)
        {
            try { return TheFunc(x); }
            catch { throw new Exception("График не может быть построен"); }
        }
    }

    class Program
    {
        public static void  Grapthics(List <IClassLibrary> dlls,int answers)
        {
            var xCoord = new List<double>();
            var yCoord = new List<double>();
            for (var x = 1; x <= 10; x += 1)
            {
                xCoord.Add(x);
                yCoord.Add(dlls[answers].CallTheFunc(x));
            }
            var graphic = new ScottPlot.Plot(300, 300);
            graphic.PlotScatter(xCoord.ToArray(), yCoord.ToArray());
            graphic.SaveFig("Function.png");
        }
        static void Main(string[] args)
        {

            List<IClassLibrary> dlls = new List<IClassLibrary>
            {
                new ClassLibrary1(),new Library2(),new Library3(),new Library4(),new Library5(),new Library6(),new MyLibrary()
            };
            Console.WriteLine("Какую функцию хотите посчитать?(Если написан -, то функция отсутствует или dll не загружена)   "+" 0)" + dlls[0].CallTheFuncName() + " 1)" + dlls[1].CallTheFuncName() + " 2)"+ dlls[2].CallTheFuncName() + " 3)"+ dlls[3].CallTheFuncName() + " 4)" + dlls[4].CallTheFuncName() + " 5)"+ dlls[5].CallTheFuncName()+ "6)"+dlls[6].CallTheFuncName());

            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == 0) 
            {
                Grapthics(dlls,answer);
            }
            if (answer == 1)
            {
                Grapthics(dlls, answer);

            }
            if (answer == 2)
            {
                Grapthics(dlls, answer);

            }
            if (answer == 3)
            {
                Grapthics(dlls, answer);

            }
            if (answer == 4)
            {
                Grapthics(dlls, answer);
            }
            if (answer == 5)
            {
                Grapthics(dlls, answer);
            }
            if (answer == 6)
            {
                Grapthics(dlls, answer);
            }
            Console.ReadKey();
        }
    }
}
