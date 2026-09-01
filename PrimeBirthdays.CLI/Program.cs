using System.Globalization;
using PrimeBirthdays.Core;

Console.WriteLine("Prime Birthdays");
Console.WriteLine("===============");
Console.WriteLine();

var birthDate = ReadBirthDate();

var calculator = new BirthdayCalculator();

Console.WriteLine();
Console.WriteLine($"Date of birth : {birthDate:dd.MM.yyyy}");

Console.WriteLine();
Console.WriteLine("Next 10 birthdays with a prime-number age");
Console.WriteLine("-----------------------------------------");

foreach (var birthday in calculator.GetPrimeAgeBirthdays(birthDate))
{
    Console.WriteLine(
        $"{birthday.Date:dd.MM.yyyy}  |  Age {birthday.Age}");
}

Console.WriteLine();
Console.WriteLine("Next 10 birthdays in a prime-number calendar year");
Console.WriteLine("-----------------------------------------------");

foreach (var birthday in calculator.GetBirthdaysInPrimeYears(birthDate))
{
    Console.WriteLine(
        $"{birthday.Date:dd.MM.yyyy}  |  Year {birthday.Year}");
}
return;

static DateOnly ReadBirthDate()
{
    while (true)
    {
        Console.Write("Date of birth (dd.MM.yyyy): ");

        var input = Console.ReadLine();

        if (DateOnly.TryParseExact(
                input,
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var date))
        {
            return date;
        }

        Console.WriteLine("Invalid date. Please try again.");
        Console.WriteLine();
    }
}