using UnityEngine;

public class ParagraphBlockProcessor : BlockProcessor
{
    public override bool CanProcess(string[] lines, int currentIndex)
    {
        return !string.IsNullOrWhiteSpace(lines[currentIndex]);
    }

    public override (MarkdownBlockBase block, int lineConsumed) Process(string[] lines, int currentIndex)
    {
        return (new ParagraphBlock { RawContent = lines[currentIndex] }, 1);
    }
}
