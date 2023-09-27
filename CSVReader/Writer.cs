namespace CSVReader;

public class Writer
{
    public void Write(IList<string> data)
    {
        using StreamWriter outFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "out.text"));
        foreach (var line in data)
        {
            Console.WriteLine(line);
            outFile.WriteLine(line);
        }
    }
}
