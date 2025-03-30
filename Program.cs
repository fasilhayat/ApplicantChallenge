namespace Challenge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* My old implementation in 20219
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
    }*/
    class Program
    {
        static List<List<int>> pyramid = Pyramid.Inputdata();
    
        static void Main(string[] args)
        {
            List<int> path = new List<int>();
            int maxSum = CalculateMaxPath(out path);
    
            Console.WriteLine($"Maximum Path Sum: {maxSum}");
            Console.WriteLine($"Path Taken: {string.Join(" -> ", path)}");
            Console.ReadKey();
        }
    
        static int CalculateMaxPath(out List<int> path)
        {
            int numRows = pyramid.Count;
            int[][] dp = new int[numRows][];
            int[][] pathIndex = new int[numRows][];
    
            for (int i = 0; i < numRows; i++)
            {
                dp[i] = new int[pyramid[i].Count];
                pathIndex[i] = new int[pyramid[i].Count];
            }
    
            // Copy last row values
            for (int col = 0; col < pyramid[numRows - 1].Count; col++)
            {
                dp[numRows - 1][col] = pyramid[numRows - 1][col];
            }
    
            // Bottom-up DP processing
            for (int row = numRows - 2; row >= 0; row--)
            {
                for (int col = 0; col < pyramid[row].Count; col++)
                {
                    if (dp[row + 1][col] > dp[row + 1][col + 1])
                    {
                        dp[row][col] = pyramid[row][col] + dp[row + 1][col];
                        pathIndex[row][col] = col;
                    }
                    else
                    {
                        dp[row][col] = pyramid[row][col] + dp[row + 1][col + 1];
                        pathIndex[row][col] = col + 1;
                    }
                }
            }
    
            // Reconstruct the path
            path = new List<int>();
            int colIndex = 0;
            for (int row = 0; row < numRows; row++)
            {
                path.Add(pyramid[row][colIndex]);
                colIndex = pathIndex[row][colIndex];
            }
    
            return dp[0][0];
        }
    }
}
