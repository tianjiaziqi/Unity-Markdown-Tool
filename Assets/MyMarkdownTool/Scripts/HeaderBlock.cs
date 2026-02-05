using UnityEngine;
using UnityEngine.UIElements;

public class HeaderBlock : MarkdownBlockBase
{
    public int Level;

    public override VisualElement CreateElement(MarkdownStyleConfig styleConfig)
    {
        var label = new Label(RawContent);
        label.style.fontSize = styleConfig.GetHeaderStyle(Level).fontSize;
        label.style.color = styleConfig.GetHeaderStyle(Level).color;
        label.style.unityFontStyleAndWeight = styleConfig.GetHeaderStyle(Level).unityFontStyle;
        
        label.style.marginBottom = 10;
        label.style.marginTop = 15;

        return label;
    }
}
