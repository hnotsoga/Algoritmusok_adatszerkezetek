using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    
    public static List<int> specialSubCubes(List<int> cube)
    {
        int n = (int)Math.Round(Math.Pow(cube.Count, 1.0 / 3.0));
        int[,,] dp = new int[n + 1, n + 1, n + 1];
        List<int> result = new List<int>(new int[n]);

       
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                for (int z = 0; z < n; z++)
                {
                    dp[x + 1, y + 1, z + 1] = cube[x * n * n + y * n + z];
                }
            }
        }
        for (int k = 1; k <= n; k++)
        {
            for (int x = 1; x <= n - k + 1; x++)
            {
                for (int y = 1; y <= n - k + 1; y++)
                {
                    for (int z = 1; z <= n - k + 1; z++)
                    {
                        int maxVal = 0;
                        for (int i = 0; i < k; i++)
                        {
                            for (int j = 0; j < k; j++)
                            {
                                for (int l = 0; l < k; l++)
                                {
                                    maxVal = Math.Max(maxVal, dp[x + i, y + j, z + l]);
                                }
                            }
                        }
                        if (maxVal == k)
                        {
                            result[k - 1]++;
                        }
                    }
                }
            }
        }

        return result;
    }

}