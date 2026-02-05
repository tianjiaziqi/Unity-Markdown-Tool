using UnityEngine;

public abstract class BlockProcessor
{
    public abstract bool CanProcess(string[] lines, int currentIndex);
    
    public abstract (MarkdownBlockBase block, int lineConsumed) Process(string[] lines, int currentIndex);
}
