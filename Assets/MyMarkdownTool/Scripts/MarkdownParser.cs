using System.Collections.Generic;
using UnityEngine;

public class MarkdownParser
{
    private readonly List<BlockProcessor> processors = new List<BlockProcessor>
    {
        new HeaderBlockProcessor(),
        new ParagraphBlockProcessor()
    };

    public List<MarkdownBlockBase> Parse(string content)
    {
        string[] lines = content.Replace("\r\n", "\n").Split("\n");
        var blocks = new List<MarkdownBlockBase>();

        for (int i = 0; i < lines.Length;)
        {
            var processor = processors.Find(p => p.CanProcess(lines, i));
            if (processor != null)
            {
                var (block, consumed) = processor.Process(lines, i);
                blocks.Add(block);
                i += consumed;
            }
            else
            {
                // Handle whitespace lines
                i++;
            }
        }

        return blocks;
    }
}
