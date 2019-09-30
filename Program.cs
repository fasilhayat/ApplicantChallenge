namespace Challenge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    { 
        static List<List<int>> pyramid = Pyramid.Inputdata();

        static void Main(string[] args)
        {
            List<int> result = new List<int>();

            CalculateMaxPath(0, 0, result);
            Console.WriteLine(result.Sum());
            Console.ReadKey();
        }

        static void CalculateMaxPath(int row, int column, List<int> result)
        {
            var noi = new int[3];
            noi[0] = pyramid[row][column];
            if (row != pyramid.Count - 1)
            {
                noi[1] = pyramid[row + 1][column];
                noi[2] = pyramid[row + 1][column + 1];
            }

            if (noi[0] % 2 != noi[1] % 2 && noi[0] % 2 != noi[2] % 2 && noi[1] < noi[2] || noi[0] % 2 == noi[1] % 2 && noi[0] % 2 != noi[2] % 2)
            {
                column++;
            } 

            result.Add(noi[0]);
            row++;

            if (row != pyramid.Count())
            {
                CalculateMaxPath(row, column, result); 
            }
        }
    }
}
