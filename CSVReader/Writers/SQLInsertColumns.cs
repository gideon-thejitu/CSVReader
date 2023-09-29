using System.Data;
using CSVReader.Formatters;

namespace CSVReader;

public class SQLInsertColumns
{
    private readonly string _outFile;
    private readonly IBaseFormatter _formatter;
    public SQLInsertColumns(string outFile, IBaseFormatter formatter)
    {
        _outFile = outFile;
        _formatter = formatter;
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
        var dataTable = dataset.Tables[dataset.Tables[0].TableName];
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
                var value = _formatter.Format(celValue, innerIndex);
       
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
}
