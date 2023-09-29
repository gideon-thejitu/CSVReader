namespace CSVReader.Formatters;

public class F1 : BaseFormatter, IBaseFormatter
{
    public string Format(string value, int index)
    {
        var _value = value;

        switch (index)
        {
            case 1:
            case 3:
            {
                _value = IsEmpty(value) ? "NULL" : value;
                break;
            }
            case 2:
            case 4:
            case 6:
            case 9:
            {
                _value = IsEmpty(value) ? "NULL" : $"'{EscapeApos(value)}'";
                break;
            }

            case 7:
            case 8:
            {
                _value = ToBit(value);
                break;
            }
            case 11:
            case 12:
            {
                _value = IsEmpty(value) ? "NULL" : value;
                break;
            }
            default:
                break;
        }

        return _value;
    }
}