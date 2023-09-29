using CSVReader;
using CSVReader.Formatters;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

// Reader reader = new Reader("data/data.xlsx", "data/result.sql");
IBaseFormatter formatter = new F1();
IBaseFormatter formatter2 = new F2();


// Reader reader = new Reader("data/file.xlsx", "data/result.sql", formatter);
Reader reader2 = new Reader("data/file.xlsx", "data/result.sql", formatter2);

// reader.Start();
reader2.Start();
