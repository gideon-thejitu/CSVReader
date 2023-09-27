using ExcelDataReader;

namespace CSVReader;

public class Reader
{
    private readonly ExcelDataSetConfiguration _configuration = new()
    {
        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
        {
            UseHeaderRow = true
        }
    };

    private readonly SQLInsertColumns _sqlInsertColumns;
    private readonly string _fileName;


    public Reader(string fileName, string outFile)
    {
        _fileName = fileName;
        _sqlInsertColumns = new SQLInsertColumns(outFile);
    }

    public void Start()
    { 
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), _fileName);

        using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        using var reader = ExcelReaderFactory.CreateReader(stream);
        do
        {
            while (reader.Read())
            {
                // reader.GetDouble(0);
            }
        } while (reader.NextResult());
       
        var result = reader.AsDataSet(_configuration);
        
        _sqlInsertColumns.Write(result);
        
        reader.Close();
    }
}