using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DopolnitZadan2
{
    public delegate void MyDelegate();
    enum enValue
    {/// <summary>
    /// переменные для вычисления среднего значения
    /// </summary>
        x=0, y, z
    }
    class Massiv
    {
        private int[] vs = new int[3];
        //public int this[int index]  // индексатор теперь не нужен. БЫЛ НУЖЕН ДЛЯ ДОСТУПА ИЗ ДРУГОГО КЛАССА.
        //{
        //    set { vs[index] = value; }
        //    get { return vs[index]; }
        //}

        public void Method()
        {
            Type type = enValue.x.GetType();
            Console.WriteLine("Для нахождения среднего арифметического значения введем три целочисленных значения переменных 'x', 'y' 'z' .");
            for (int j = 0; j < 3; j++)
            {
                Console.Write("  {0} = ", Enum.Format(type, j, "G"));
                if (Int32.TryParse(Console.ReadLine(), out int input))
                    vs[j] = input;
                else
                {
                    Console.WriteLine("Неправильный ввод. По умолчанию приймем {0} = 1 .", Enum.Format(type, j, "G"));
                    vs[j] = 1;
                }
            }
            Console.Write("Посмотрим на значения массива :  ");
            foreach (int item in vs)
                Console.Write(item + "  ");

            Console.WriteLine("\n   Средеарифметическое значение = {0} (double).", vs.Average());
        }
    }
    class Program
    {
        static void Main()
        {
            Massiv massiv = new Massiv();

            MyDelegate myDelegate  = massiv.Method;
            massiv.Method();

            Console.ReadKey();
        }
    }
}
// Вывод в строковом формате. Флаг "G" - str (Строковой формат)
//Console.WriteLine("  строковое значение {0}", Enum.Format(post.GetType(), (byte)152, "G"));
//Console.WriteLine("  строковое значение {0}", Enum.Format(post.GetType(), array5.GetValue(4), "G"));