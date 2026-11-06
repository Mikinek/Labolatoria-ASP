using System.Text.RegularExpressions;

namespace Labolatorium_ASP.Models;
using System.ComponentModel.DataAnnotations;

public class NotInFutureAttribute : ValidationAttribute
{
    public NotInFutureAttribute() => ErrorMessage = "Data nie może być z przyszłości";
    public override bool IsValid(object? value) => value is not DateTime d || d.Date <= DateTime.Today;
}
public class IsbnAttribute : ValidationAttribute
{
    public bool RequireChecksum { get; set; } = false;

    public IsbnAttribute() => ErrorMessage = "Niepoprawny format numeru ISBN";

    public override bool IsValid(object? value)
    {
        if (value is not string raw || string.IsNullOrWhiteSpace(raw))
            return true;

        string digits = raw.Replace("-", "").Replace(" ", "");

        return Regex.IsMatch(digits, @"^(\d{10}|\d{13})$");
    }
}