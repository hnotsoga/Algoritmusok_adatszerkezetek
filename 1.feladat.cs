using System;
using System.Collections.Generic;        
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.feladat
class Solution
{
    public static int ShortPalindrome(string s)
    {
        const int MOD = 1000000007;
        int[] szamolo = new int[26];
        int[,] parszamolo = new int[26, 26];
        int[] harmasszamolo = new int[26];
        long result = 0;

        foreach (char ch in s)
        {
            int index = ch - 'a';

            // Add the current triplet count for this character
            result = (result + harmasszamolo[index]) % MOD;

            // Update triplet count using the pair count
            for (int i = 0; i < 26; i++)
            {
                harmasszamolo[i] = (harmasszamolo[i] + parszamolo[i, index]) % MOD;
            }

            // Update pair count using single counts
            for (int i = 0; i < 26; i++)
            {
                parszamolo[i, index] = (parszamolo[i, index] + szamolo[i]) % MOD;
            }

            // Update single count for the current character
            szamolo[index] = (szamolo[index] + 1) % MOD;
        }

        return (int)result;
    }

    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        Console.WriteLine(ShortPalindrome(s));
    }
}