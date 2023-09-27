using CSVReader;
using ExcelDataReader;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Users.xlsx");

using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
{
    var conf = new ExcelDataSetConfiguration()
    {
        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
        {
            UseHeaderRow = true
        }
    };

    using (var reader = ExcelReaderFactory.CreateReader(stream))
    {
        do
        {
            while (reader.Read())
            {
                // reader.GetDouble(0);
            }
        } while (reader.NextResult());

        var result = reader.AsDataSet(conf);
        var dataTable = result.Tables[0];
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
                var cellValue = rows[index][innerIndex].ToString();

                if (cellValue is null || cellValue == "")
                {
                    switch (innerIndex)
                    {
                        case 3:
                        {
                            cellValue = "'DATE'";
                            break;
                        }

                        default:
                        {
                            break;
                        }
                    }
                }

                if (innerIndex == 0)
                {
                    insert += "(";
                    insert += $"{cellValue},";
                }

                if (innerIndex != 0 && innerIndex != columns.Count - 1)
                {
                    insert += $"{cellValue},";
                }
                
                if (innerIndex == columns.Count - 1)
                {
                    insert += $"{cellValue}";
                    insert += "),";
                }
                
                innerIndex += 1;
            }

            index += 1;
            
            toWrite.Add(insert);
        }
        
        new Writer().Write(toWrite);

        reader.Close();
    }
}