namespace CSVReader.Formatters;

public interface IBaseFormatter
{
    public string Format(string value, int index);
}
