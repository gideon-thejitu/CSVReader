namespace CSVReader.Formatters;

public class BaseFormatter
{
    protected bool IsEmpty(string? value)
    {
        return value is null || value == "";
    }

    protected string ToBit(string? value)
    {
        if (IsEmpty(value))
        {
            return "0";
        }

        return value == "True" ? "1" : "0";
    }

    protected bool ContainsApos(string value)
    {
        if (IsEmpty(value))
        {
            return false;
        }

        return value.Contains("'");
    }

    protected string EscapeApos(string value)
    {
        if (ContainsApos(value) == false)
        {
            return value;
        }

        return value.Replace("'", "''");
    }
}
