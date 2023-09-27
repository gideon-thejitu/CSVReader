using System.Data;

namespace CSVReader;

public class SQLInsertColumns
{
    private readonly string _outFile;
    public SQLInsertColumns(string outFile)
    {
        _outFile = outFile;
    }
    public void Write(DataSet dataset)
    {
        var data = BuildData(dataset);

        using StreamWriter outFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), _outFile));
        foreach (var line in data)
        {
            outFile.WriteLine(line);
        }
    }

    private IList<string> BuildData(DataSet dataset)
    {
        var dataTable = dataset.Tables[0];
        var columns = dataTable.Columns;
        var rows = dataTable.Rows;

        IList<string> toWrite = new List<string>();
       
        var index = 0;
        foreach (var row in rows)
        {
            var innerIndex = 0;
            string insert = "";
       
            foreach (var col in columns)
            {
                var celValue = rows[index][innerIndex].ToString();
                var value = FormatValue(celValue, innerIndex);
       
                if (innerIndex == 0)
                {
                    insert += "(";
                    insert += $"{value},";
                }
       
                if (innerIndex != 0 && innerIndex != columns.Count - 1)
                {
                    insert += $"{value},";
                }
                       
                if (innerIndex == columns.Count - 1)
                {
                    insert += $"{value}";
                    insert += "),";
                }
                       
                innerIndex += 1;
            }
       
            index += 1;
                   
            toWrite.Add(insert);
        }

        return toWrite;
    }
    
    private string FormatValue(string value, int index)
    {
        var _value = value;

        switch (index)
        {
            case 2:
            case 4:
            case 6:
            {
                _value = IsEmpty(value) ? "''" : $"'{value}'";
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
                _value = IsEmpty(value) ? "Null" : value;
                break;
            }
            default:
                break;
        }

        return _value;
    }

    private bool IsEmpty(string? value)
    {
        return value is null || value == "";
    }

    private string ToBit(string? value)
    {
        if (IsEmpty(value))
        {
            return "0";
        }

        return value == "True" ? "1" : "0";
    }
}
