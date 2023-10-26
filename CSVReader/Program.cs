using CSVReader;
using CSVReader.Formatters;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

IBaseFormatter formatter = new F1();
Reader reader3 = new Reader("data/in.xlsx", "data/out.sql", formatter);
reader3.Start();
