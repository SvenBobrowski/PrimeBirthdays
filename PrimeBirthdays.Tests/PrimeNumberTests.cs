namespace PrimeBirthdays.Tests;

using PrimeBirthdays.Core;

public sealed class PrimeNumberTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(9)]
    [InlineData(25)]
    public void IsPrime_ReturnsFalse_ForNonPrimeNumbers(int value)
    {
        Assert.False(PrimeNumber.IsPrime(value));
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(53)]
    [InlineData(2027)]
    public void IsPrime_ReturnsTrue_ForPrimeNumbers(int value)
    {
        Assert.True(PrimeNumber.IsPrime(value));
    }
}
