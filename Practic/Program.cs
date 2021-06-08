using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariphmetic
{
    public delegate decimal DelAriphm(int a, int b, int c);

    class Ariphmetik
    {/// <summary>
    /// Вычисление среднеарифметического значения
    /// </summary>
    /// <param name="x">параметр x</param>
    /// <param name="y">параметр y</param>
    /// <param name="z">параметр z</param>
    /// <returns>для большей точности приведем к типу decimal</returns>
        public decimal MyAriphm(int x, int y, int z)
        {
                                                                                        // decimal X = (decimal)x;
           return (decimal)(x + y + z) / 3; 
        }
    }
    class Program
    {
        static void Main()
        {
            // Ariphmetik ariphmetik; экземпляр не построен, использовать нечего.
            Ariphmetik ariphmetik = new Ariphmetik(); // без аргумента в каком случае.
            DelAriphm delariphm = new DelAriphm(ariphmetik.MyAriphm);//указываем имя метода, не вызываем - без скобок.
            Console.WriteLine("Для нахождения среднего арифметического значения введем три целочисленных значения переменных 'x', 'y' 'z' .");
            Console.Write("  x = ");
            if (Int32.TryParse(Console.ReadLine(), out int x)) ; // continue  как
            else
            {
                Console.WriteLine("Неправильный ввод. По умолчанию приймем x = 1 .");
                x = 1;
            }
            Console.Write("\n  y = ");
            if (Int32.TryParse(Console.ReadLine(), out int y)) ;
            else
            {
                Console.WriteLine("Неправильный ввод. По умолчанию приймем y = 1 .");
                y = 1;
            }
            Console.Write("\n  z = ");
            if (Int32.TryParse(Console.ReadLine(), out int z)) ;
            else
            {
                Console.WriteLine("Неправильный ввод. По умолчанию приймем z = 1 .");
                z = 1;
            }
            Console.WriteLine("\n   Средеарифметическое значение = {0}",delariphm(x,y,z));  // с делегатом указываем параметры сообщенного метода.

            Console.ReadKey();
        }
    }
}
