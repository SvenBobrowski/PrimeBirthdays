namespace PrimeBirthdays.Core;

public static class PrimeNumber
{
    public static bool IsPrime(int value)
    {
        if (value < 2)
            return false;

        if (value == 2)
            return true;

        if (value % 2 == 0)
            return false;

        for (var divisor = 3; divisor <= value / divisor; divisor += 2)
        {
            if (value % divisor == 0)
                return false;
        }

        return true;
    }
}