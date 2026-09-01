namespace PrimeBirthdays.Core;

public sealed record BirthdayOccurrence(
    DateOnly Date,
    int Age)
{
    public int Year => Date.Year;
}