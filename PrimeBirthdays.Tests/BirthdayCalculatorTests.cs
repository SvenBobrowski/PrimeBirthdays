using PrimeBirthdays.Core;

namespace PrimeBirthdays.Tests;

public sealed class BirthdayCalculatorTests
{
    private readonly BirthdayCalculator _calculator = new();

    [Fact]
    public void GetPrimeAgeBirthdays_ReturnsRequestedNumberOfBirthdays()
    {
        var dateOfBirth = new DateOnly(1974, 5, 14);

        var result = _calculator.GetPrimeAgeBirthdays(dateOfBirth).ToList();

        Assert.Equal(10, result.Count);
    }

    [Fact]
    public void GetPrimeAgeBirthdays_ReturnsOnlyPrimeAges()
    {
        var dateOfBirth = new DateOnly(1974, 5, 14);

        var result = _calculator.GetPrimeAgeBirthdays(dateOfBirth).ToList();

        Assert.All(result, birthday => Assert.True(PrimeNumber.IsPrime(birthday.Age)));
    }

    [Fact]
    public void GetBirthdaysInPrimeYears_ReturnsRequestedNumberOfBirthdays()
    {
        var dateOfBirth = new DateOnly(1974, 5, 14);

        var result = _calculator.GetBirthdaysInPrimeYears(dateOfBirth).ToList();

        Assert.Equal(10, result.Count);
    }

    [Fact]
    public void GetBirthdaysInPrimeYears_ReturnsOnlyPrimeYears()
    {
        var dateOfBirth = new DateOnly(1974, 5, 14);

        var result = _calculator.GetBirthdaysInPrimeYears(dateOfBirth).ToList();

        Assert.All(result, birthday => Assert.True(PrimeNumber.IsPrime(birthday.Year)));
    }

    [Fact]
    public void GetPrimeAgeBirthdays_ThrowsForFutureBirthDate()
    {
        var dateOfBirth = DateOnly.FromDateTime(DateTime.Today).AddDays(1);

        Assert.Throws<ArgumentException>(() =>
            _calculator.GetPrimeAgeBirthdays(dateOfBirth).ToList()
        );
    }

    [Fact]
    public void GetPrimeAgeBirthdays_ThrowsForInvalidCount()
    {
        var dateOfBirth = new DateOnly(1974, 5, 14);

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _calculator.GetPrimeAgeBirthdays(dateOfBirth, 0).ToList()
        );
    }
}
