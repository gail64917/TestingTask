using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleLib
{
    //класс Треугольника с длинами сторон любого типа, при условии что тип длины сторон IComparable (для сравнивания с 0) и не ссылочный
    public class Triangle<T> where T : struct, IComparable
    {
        private T sideA, sideB, sideC;
        public T SideA
        {
            get
            {
                return sideA;
            }
            set
            {
                if (SideIsValid(value))
                    sideA = value;
                else
                    ErrorLog("Длина стороны не может иметь значение " + value);
            }
        }
        public T SideB
        {
            get
            {
                return sideB;
            }
            set
            {
                if (SideIsValid(value))
                    sideB = value;
                else
                    ErrorLog("Длина стороны не может иметь значение " + value);
            }
        }
        public T SideC
        {
            get
            {
                return sideC;
            }
            set
            {
                if (SideIsValid(value))
                    sideC = value;
                else
                    ErrorLog("Длина стороны не может иметь значение " + value);
            }
        }

        //конструктор обязан принимать три параметра: длины сторон треугольника
        public Triangle(T a, T b, T c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        //функция проверки на допустимость значения стороны. в противном случае пишет сообщение об ошибке в файл логов
        private bool SideIsValid(T arg)
        {
            try
            {
                return (dynamic)arg > 0 ? true : false;
            }
            catch
            {
                ErrorLog("Длина стороны не может иметь значнеие " + arg);
                return false;
            }

        }
        //функция записи в файл логов ошибок
        private void ErrorLog(string ErrorString)
        {
            var file = new System.IO.StreamWriter("ErrorLog.txt", true);
            file.WriteLine(ErrorString);
            file.Close();
        }
        //функция проеврки треугольника на правильность для тестов
        public bool IsRightTriangle()
        {
            T hypotenuse, cathet1, cathet2;
            if (SideA.CompareTo(SideB) == 1)
            {
                hypotenuse = SideA;
                cathet1 = SideB;
            }
            else
            {
                cathet1 = SideA;
                hypotenuse = SideB;
            }
            if (hypotenuse.CompareTo(SideC) == 1)
            {
                cathet2 = SideC;
            }
            else
            {
                cathet2 = hypotenuse;
                hypotenuse = SideC;
            }
            try
            {
                if (((dynamic)cathet2 * (dynamic)cathet2 + (dynamic)cathet1 * (dynamic)cathet1) == (dynamic)hypotenuse * (dynamic)hypotenuse)
                {
                    return true;
                }

                else
                {
                    return false;
                }

            }
            catch
            {
                ErrorLog("Type Error! Sides cannot be this types");
                return false;
            }
        }
        //функция проверки на правильность. в ходе проверки выясняется, какие из сторон - катеты, какие - гипотенузы. чтобы не повторять эти процедуры - функция выписывает катеты и гипотенузу во внешние переменные
        public bool IsRightTriangle(out T CathetAOut, out T CathetBOut, out T HypotenuseOut)
        {
            T hypotenuse, cathet1, cathet2;
            if (SideA.CompareTo(SideB) == 1)
            {
                hypotenuse = SideA;
                cathet1 = SideB;
            }
            else
            {
                cathet1 = SideA;
                hypotenuse = SideB;
            }
            if (hypotenuse.CompareTo(SideC) == 1)
            {
                cathet2 = SideC;
            }
            else
            {
                cathet2 = hypotenuse;
                hypotenuse = SideC;
            }
            try
            {
                if (((dynamic)cathet2 * (dynamic)cathet2 + (dynamic)cathet1 * (dynamic)cathet1) == (dynamic)hypotenuse * (dynamic)hypotenuse)
                {
                    CathetAOut = cathet1;
                    CathetBOut = cathet2;
                    HypotenuseOut = hypotenuse;
                    return true;
                }

                else
                {
                    CathetAOut = default(T);
                    CathetBOut = default(T);
                    HypotenuseOut = default(T);
                    return false;
                }

            }
            catch
            {
                CathetAOut = default(T);
                CathetBOut = default(T);
                HypotenuseOut = default(T);
                ErrorLog("Type Error! Sides cannot be this types");
                return false;
            }
        }        
        //для поиска площади требуется знать, какие из сторон катеты. это делает функция проверки треугольника на правильность. далее находится площадь 
        public float SquareRightTriangle()
        {
            T cathet1, cathet2, hypotenuse;
            if (IsRightTriangle(out cathet1, out cathet2, out hypotenuse))
            {
                try
                {
                    float result = Convert.ToSingle((dynamic)cathet1 * (dynamic)cathet2 / 2);
                    return result;
                }
                catch
                {
                    ErrorLog("type error! Cannot count this types!");
                    return 0;
                }
            }
            else
            {
                ErrorLog("Error! Triangle" + this.ToString() + " isnt right!");
                return 0;
            }

        }
        //вывод на консоль площади
        public void DisplaySquareConsole()
        {
            Console.WriteLine("Площадь треугольника {0}: {1}", this, SquareRightTriangle());
        }
    }
}
