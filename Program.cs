namespace Challenge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static List<int> result = new List<int>();
        static int cursorPosition = 0;
        static int index = 0;
        static List<List<int>> pyramid = Pyramid.Inputdata();

        static void Main(string[] args)
        {
            var res = CalculateMaxPath(cursorPosition, pyramid[index]);
            Console.WriteLine(res.Sum());
        }

        static List<int> CalculateMaxPath(int cursorPosition, List<int> sequence)
        {
            var noi = new int[3];
            noi[0] = sequence[cursorPosition];
            if (index != pyramid.Count-1)
            {
                noi[1] = pyramid[index + 1][cursorPosition];
                noi[2] = pyramid[index + 1][cursorPosition + 1];
            }

            if (noi[0] % 2 != noi[1] % 2 && noi[0] % 2 != noi[2] % 2 && noi[1] < noi[2] || noi[0] % 2 == noi[1] % 2 && noi[0] % 2 != noi[2] % 2) 
            {
                cursorPosition++;
            }

            result.Add(noi[0]);
            index++;

            return (index == pyramid.Count()) ? result : CalculateMaxPath(cursorPosition, pyramid[index]);
        }
    }
}
