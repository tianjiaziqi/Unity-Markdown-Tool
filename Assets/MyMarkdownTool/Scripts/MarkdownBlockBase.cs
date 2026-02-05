using UnityEngine;
using UnityEngine.UIElements;

public abstract class MarkdownBlockBase
{

    public abstract VisualElement CreateElement(MarkdownStyleConfig styleConfig);

    public virtual void OnDispose()
    {
        
    }
    
    public string RawContent { get; set; }

}
