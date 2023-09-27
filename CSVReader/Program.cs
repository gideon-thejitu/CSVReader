using CSVReader;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

Reader reader = new Reader("data/data.xlsx", "data/result.sql");

reader.Start();
