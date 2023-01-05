using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class MyMathImplementation
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static List<int> GenericSort(List<int> toSort, Func<int, int, int> isInOrder)
        {
            while (!IsListInOrder(toSort, isInOrder))
            {
                for (int i = 0; i < toSort.Count - 1; i++)
                {
                    if(isInOrder.Invoke(toSort[i], toSort[i + 1]) == -1)
                    {
                        int temp = toSort[i + 1];
                        toSort[i + 1] = toSort[i];
                        toSort[i] = temp;
                        break;
                    }
                }
                
            }
            return toSort;
        }

        public static List<int> GetAllPrimary(int a)
        {
            List<int> list = new();
            for(int i = 2 ; i <= a; i++)
            {
                if (IsPrimary(i))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public static bool IsDivisible(int a, int b)
        {
            return a % b == 0;
        }

        public static bool IsEven(int a)
        {
            return a % 2 == 0;
        }

        public static int IsInOrder(int a, int b)
        {
            if(a > b)
            {
                return -1;
            }
            else if( a < b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int IsInOrderDesc(int arg1, int arg2)
        {
            return -IsInOrder(arg1, arg2);
        }

        public static bool IsListInOrder(List<int> list)
        {
            for(int i = 0; i < list.Count - 1; i++)
            {
                if(list[i] > list[i + 1])
                {
                    return false;
                }

            }
            return true;
        }

        public static bool IsListInOrder(List<int> list, Func<int, int,int> IsInOrder)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (IsInOrder(list[i], list[i+1]) == -1)
                {
                    return false;
                }

            }
            return true;
        }


        public static bool IsMajeur(int age)
        {
            if (age < 0 || age >= 150)
                throw new ArgumentException();

            return age >= 18;
        }

        public static bool IsPrimary(int a)
        {
            for(int i = 2; i < a; i++)
            {
                if(a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int Power(int a, int b)
        {
            int newA = a;
            for(int i = 1; i < b; i++)
            {
                newA *= a;
            }
            return newA;
        }

        public static int Power2(int a)
        {
            return a * a;
        }

        public static List<int> Sort(List<int> toSort)
        {
            while (!IsListInOrder(toSort))
            {
                for(int i = 0; i < toSort.Count - 1; i++)
                {
                    if(toSort[i] > toSort[i + 1])
                    {
                        int temp = toSort[i + 1];
                        toSort[i + 1] = toSort[i];
                        toSort[i] = temp;
                    }
                }
            }
            return toSort;
        }
    }


}
