using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public delegate void MyDelegate(int x, int y);

    class Ariphmetik
    {

    }
    class Program
    {
        static void Main()
        {
            Console.Write("  Для выполнения математических операций введем значчения переменных 'X' и 'Y' :\n X = ");
            if (Int32.TryParse(Console.ReadLine(), out int a)) ; //после ввода значения клавиша 'Enter' переводит строку.
            else
            {
                Console.WriteLine("Не правильный ввод. Принимаем по умолчанию  Х = 0 .");
                a = 0;
            }
            Console.Write("   Y = ");
            if (Int32.TryParse(Console.ReadLine(), out int b)) ;
            else
            {
                Console.WriteLine("Не правильный ввод. Принимаем по умолчанию  Y = 0 .");
                b = 0;
            }
                Exception er = new Exception("My");
            MyDelegate myDelegate = (x, y) => { Console.Write("  Метод Add: "); Console.WriteLine(x + y); };//а как же сначала присвоить null? ПРИ РЕКУРСИИ
            myDelegate += (x, y) => { Console.Write("  Метод Sub: "); Console.WriteLine(x - y); };
            myDelegate += (x, y) => { Console.Write("  Метод Mul: "); Console.WriteLine(x * y); };
            myDelegate += (x, y) => { Console.Write("  Метод Div: "); Console.WriteLine(x / y); };// (double)(x/y)разрешено делить, =безконечность,нет исключения.
            try
            {
               // Exception er = new Exception("My"); экземпляр 'er' не видно в блоке 'catch'.
                myDelegate(a, b);
            }
            catch ( Exception e )//можно указать тип класса исключения: пользовательского или класса Exception. Если не указывать -просто выполнится тело 'catch'.(message ничье не выполнится.)
            {   //  блок 'catch' видит все экземпляры класса Exception (? похоже).
                Console.WriteLine(" Обработка исключения");
                Console.WriteLine(er.Message);// стандартное сообщение от класса Exception заменено на пользовательское сообщение.
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType());
                Console.WriteLine(er.GetType());
            }

            // Это пользовательское знач "My" записано в другой экземпляр класса Exception. А можно создать пользовательский класс, к примеру
            // UserException, нас ледуемый от базового класса Exception.

            Console.ReadKey();
        }
    }
}

//myDelegate = (x) => { return x * 2; };                   // Лямбда-Оператор.  (x) -входной аргумент.  (x * 2) -возвращаемое значение.
//(Add – сложение, Sub – вычитание, Mul – умножение, Div – деление)