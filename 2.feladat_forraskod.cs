using System;
using System.Collections.Generic;

class Result
{
    public static int powerSum(int X, int N)
    {
        return powerSumHelper(X, N, 1, 0);
    }

    private static int powerSumHelper(int target, int power, int currentNumber, int currentSum)
    {
        if (currentSum == target)
            return 1; 
        if (currentSum > target)
            return 0; 

        int currentPower = (int)Math.Pow(currentNumber, power);
        if (currentSum + currentPower > target)
            return 0; 
       
        return powerSumHelper(target, power, currentNumber + 1, currentSum + currentPower) +
               powerSumHelper(target, power, currentNumber + 1, currentSum);
    }
}