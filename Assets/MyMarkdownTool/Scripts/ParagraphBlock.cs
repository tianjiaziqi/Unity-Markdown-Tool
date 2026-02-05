using UnityEngine;
using UnityEngine.UIElements;

public class ParagraphBlock : MarkdownBlockBase
{
    
    public override VisualElement CreateElement(MarkdownStyleConfig styleConfig)
    {
        var label = new Label(RawContent);
        label.style.fontSize = styleConfig.paragraphFontSize;
        label.style.color = styleConfig.paragraphColor;
        label.style.whiteSpace = WhiteSpace.Normal;
        label.style.marginBottom = 8;
        return label;
    }
}
