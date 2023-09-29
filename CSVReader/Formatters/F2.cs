namespace CSVReader.Formatters;

public class F2: BaseFormatter, IBaseFormatter {
    public string Format(string value, int index)
    {
        var _value = value;

        switch (index)
        {
            case 0:
            case 4:
            case 5:
            {
                _value = IsEmpty(value) ? "NULL" : $"'{EscapeApos(value)}'";
                break;
            }
            case 3:
            {
                _value = ToBit(value);
                break;
            }
            default:
                break;
        }

        return _value;
    }
}