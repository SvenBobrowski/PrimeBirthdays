namespace PrimeBirthdays.Core;

public sealed class BirthdayCalculator
{
    public IEnumerable<BirthdayOccurrence> GetPrimeAgeBirthdays(
        DateOnly dateOfBirth,
        int count = 10
    )
    {
        Validate(dateOfBirth, count);

        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = GetAge(dateOfBirth, today);

        while (true)
        {
            var birthday = dateOfBirth.AddYears(age);

            if (birthday >= today && PrimeNumber.IsPrime(age))
            {
                yield return new BirthdayOccurrence(birthday, age);

                count--;

                if (count == 0)
                    yield break;
            }

            age++;
        }
    }

    public IEnumerable<BirthdayOccurrence> GetBirthdaysInPrimeYears(
        DateOnly dateOfBirth,
        int count = 10
    )
    {
        Validate(dateOfBirth, count);

        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = GetAge(dateOfBirth, today);

        while (true)
        {
            var birthday = dateOfBirth.AddYears(age);

            if (birthday >= today && PrimeNumber.IsPrime(birthday.Year))
            {
                yield return new BirthdayOccurrence(birthday, age);

                count--;

                if (count == 0)
                    yield break;
            }

            age++;
        }
    }

    private static int GetAge(DateOnly dateOfBirth, DateOnly date)
    {
        var age = date.Year - dateOfBirth.Year;

        if (dateOfBirth.AddYears(age) > date)
            age--;

        return age;
    }

    private static void Validate(DateOnly dateOfBirth, int count)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        if (dateOfBirth >= today)
            throw new ArgumentException("Date of birth must be before today.", nameof(dateOfBirth));

        if (count <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(count),
                "Count must be greater than zero."
            );
    }
}
