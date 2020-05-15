using System;

namespace Test1
{
    class Program
    {

        //Условие: вводятся три точки в виде (х,у) как координаты вершин треугольника
        //Найти: периметр и площадь (и вывести)
        static void Main(string[] args)
        {
            int[,] dots = GetDots();
            double[] verges = GetVerges(dots);
            double perimeter = GetPerimeter(verges);
            Console.WriteLine("Perimeter: " + perimeter);
            double square = GetSquare(verges);
            Console.WriteLine("Square: " + square);

        }

        //получаем точки из консоли
        static int[,] GetDots()
        {
            int[,] dots = new int[3, 2];
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Input the dot number " + (i + 1) + ":");
                string line = Console.ReadLine();
                string[] coordinates = line.Split(" ");
                dots[i, 0] = Convert.ToInt32(coordinates[0]);
                dots[i, 1] = Convert.ToInt32(coordinates[1]);
            }

            return dots;
        }

        //получаем длины ребер
        static double[] GetVerges(int[,] dots)
        {
            double[] verges = new double[3];
            for (int i = 0; i < 3; i++)
            {
                int x1 = dots[i, 0], y1 = dots[i, 1];
                int x2, y2;
                if (i != 2)
                {
                    x2 = dots[i + 1, 0];
                    y2 = dots[i + 1, 1];
                }
                else
                {
                    x2 = dots[0, 0];
                    y2 = dots[0, 1];
                }
                double verge = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                verges[i] = verge;
            }

            return verges;
        }


        //ищем периметр
        static double GetPerimeter(double[] verges)
        {
            double perimeter = 0;
            for (int i = 0; i < verges.Length; i++)
            {
                perimeter = perimeter + verges[i];
            }
            return perimeter;
        }

        //ищем площадь
        static double GetSquare(double[] verges)
        {
            double a = verges[0], b = verges[1], c = verges[2];
            Console.WriteLine(a + " " + b + " " + c);
            double p = (a + b + c) / 2;
            double square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return square;
        }
    }
}
