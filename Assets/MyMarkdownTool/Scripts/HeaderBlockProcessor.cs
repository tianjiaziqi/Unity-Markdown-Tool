using System.Text.RegularExpressions;

public class HeaderBlockProcessor : BlockProcessor
{
    public override bool CanProcess(string[] lines, int currentIndex)
    {
        return Regex.IsMatch(lines[currentIndex], @"^#{1,6} ");
    }

    public override (MarkdownBlockBase block, int lineConsumed) Process(string[] lines, int currentIndex)
    {
        return (new HeaderBlock
            { Level = GetLevel(lines[currentIndex]), RawContent = GetContent(lines[currentIndex]) }, 1);
    }

    private int GetLevel(string line)
    {
        return line.Length - line.TrimStart('#').Length;
    }

    private string GetContent(string line)
    {
        return line.Remove(0, GetLevel(line) + 1);
    }
}
