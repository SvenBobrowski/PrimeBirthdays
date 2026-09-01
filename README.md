# PrimeBirthdays

Small .NET sample application that calculates upcoming birthdays related to prime numbers.

.NET 10 is used because this project has no compatibility requirements that would justify targeting an earlier version.

The wording of the original task allows two interpretations:

1. Birthdays on which the person's **age is a prime number**
2. Birthdays occurring in a **calendar year that is a prime number**

Both variants are implemented.

## Projects

### PrimeBirthdays.Core

Contains the application logic.

Responsibilities:

* prime number validation
* calculation of upcoming birthdays with a prime-number age
* calculation of upcoming birthdays occurring in prime-number calendar years
* result model used by the application

The Core project has no dependency on the CLI or test project.

### PrimeBirthdays.Cli

Small console application used to demonstrate the Core functionality.

It:

* reads the date of birth from the user
* calls both calculation variants
* outputs the resulting birthdays

The CLI intentionally contains no business logic.

### PrimeBirthdays.Tests

Contains xUnit tests for the Core project.

The tests cover:

* prime and non-prime number detection
* number of returned birthdays
* validation of prime-number ages
* validation of prime-number calendar years
* invalid input values

## Build

```bash
dotnet build
```

## Run

```bash
dotnet run --project PrimeBirthdays.Cli
```

## Tests

```bash
dotnet test
```

## Notes

The implementation is intentionally kept small and straightforward.

The goal is to separate calculation logic, presentation and tests without introducing unnecessary abstractions for a small example application.
