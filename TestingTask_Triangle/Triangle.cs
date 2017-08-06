using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleLib
{
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

        public Triangle(T a, T b, T c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

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
        private void ErrorLog(string ErrorString)
        {
            var file = new System.IO.StreamWriter("ErrorLog.txt", true);
            file.WriteLine(ErrorString);
            file.Close();
        }
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
        public void DisplaySquareConsole()
        {
            Console.WriteLine("Площадь треугольника {0}: {1}", this, SquareRightTriangle());
        }
    }
}
