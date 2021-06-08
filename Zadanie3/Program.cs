using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3  // массив из разных делегатов.     массив из одинакового делегата.    из переменных (экземпляров) делегата.
{
    public delegate int MyDelegate();
    // MyDelegate myDelegate1=null;// Пространство имен не может напрямую включать в себя такие члены,как поля или методы(их некому выполнять).
    public delegate int MyMassDelegate(MyDelegate[] instance); // этому экземпляру делегата тоже в соответствие сообщим метод.

    class Program
    {
        static void Main()
        {
            MyDelegate myDelegate0 = null;
            MyDelegate myDelegate1 = null;
            MyDelegate myDelegate2 = null;
            MyDelegate myDelegate3 = null;
            MyDelegate[] myDelegates = new MyDelegate[] { myDelegate0, myDelegate1, myDelegate2, myDelegate3 };//MyDelegates[1] = myDelegate1;/Массив делегатов
                                                                                                               // В инициализаторе создать переменную делегата или экземпляр нельзя? -MyDelegate myDelegate;?
            //MyDelegate[] myDelegates = { myDelegate0, myDelegate1, myDelegate2, myDelegate3 };

            Random random = new Random();
            myDelegate0 = () => { return random.Next(1, 100); }; // лямбда оператор
            myDelegate1 = () => { return random.Next(1, 100); };
            myDelegate2 = () => { return random.Next(1, 100); };
            myDelegate3 = () => { return random.Next(1, 100); };


            MyMassDelegate @delegate = delegate (MyDelegate[] instance) { int[] array = { myDelegate0(), myDelegate1(), myDelegate2(), myDelegate3() }; return (int)array.Average(); }; // анонимный метод, лямбда метод.
                      //   так в теле анонимного используются конкретные делегаты, а не те, что переданы с аргументом при вызове.                                                                                                                                                                  // во входных аргументах указывать именно тип переменной и саму пееременную - (не экземпляр). 
            /* если мы не указываем конструктор 'new MyDelegate(..);',то всеравно будет создаваться экземпляр определенного делегата,
             такая техника назыввается техникой предположения делегата:
            MyMassDelegate @delegate =new MyMassDelegate( delegate (MyDelegate[] instance) { int[] ar......);
            */
            Console.WriteLine(myDelegate0());

            // int vs = MyDelegates.Average(MyDelegates);
            Console.WriteLine(myDelegates);
            Console.WriteLine(myDelegates.GetType());
            Console.WriteLine(new string('o',15));
            Console.WriteLine(@delegate(myDelegates));// если в аргумент передать другой массив, то в этом @delegate всеравно вызовятся конкретные делегаты- методы.

            Console.WriteLine( new string('#',25));
            for (int i = 0; i < myDelegates.Length; i++)   // посмотреть доступ к элементам (делегата) массива (через) в цикле.
            {
                myDelegates[i] = () => { return random.Next(1, 100); };//инициализация элементов массива.
            }
            Array array1 = myDelegates.ToArray();  // myDelegates в Array
            Console.WriteLine(array1.GetType());
            foreach(MyDelegate item in array1)   //перебираются делегаты и потом запускаются сообщ.е методы
                Console.WriteLine(item());     // запускаются заново сообщенные методы

            Console.WriteLine(new string('-',20));
            foreach(MyDelegate item in myDelegates)  // myDelegates в MyDelegate  //перебираются делегаты и потом запускаются сообщ.е методы
                Console.WriteLine(item());  // запускаются заново сообщенные методы
           
            Console.WriteLine(new string('*',25));
            MyDelegate[] myinstance = new MyDelegate[6]; // заново массив
            MyMassDelegate myMassDelegate = delegate (MyDelegate[] mymassinstance) // анонимный метод сразу не выполняется, а просто сообщается с делегатом.
            {
                int[] intMassDelegate = new Int32[myinstance.Length];
                for (int i = 0; i < myinstance.Length; i++)   //присвоить можно не в методе.
                {
                    myinstance[i] = () => { return random.Next(1, 100); };
                    intMassDelegate[i] = myinstance[i]();  // значениия myinstance[i]() должны не выпасть за Int32.
                    Console.Write("\n   " + intMassDelegate[i]);
                }
                // mymassinstance.AsQueryable().Aggregate() - разобрать.

                return (int)intMassDelegate.Average();
            };
            Console.WriteLine("\n    " + myMassDelegate(myinstance));
            Console.ReadKey();
        }
    }
} // преобразование пользовательского типа массива например в int[] массив.

