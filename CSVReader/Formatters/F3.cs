namespace CSVReader.Formatters;

public class F3: BaseFormatter, IBaseFormatter {
    public string Format(string value, int index)
    {
        var _value = value;

        switch (index)
        {
            case 1:
            case 2:
            {
                _value = IsEmpty(value) ? "NULL" : $"'{EscapeApos(value)}'";
                break;
            }
            default:
                break;
        }

        return _value;
    }
}