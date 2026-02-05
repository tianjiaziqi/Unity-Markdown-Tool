using UnityEngine;

[System.Serializable]
public struct TextStyle
{
    public float fontSize;
    public Color color;
    public FontStyle unityFontStyle;
}
[CreateAssetMenu(fileName = "MarkdownStyle", menuName = "Markdown/Style Config")]
public class MarkdownStyleConfig : ScriptableObject
{
    [Header("Header Styles")] 
    public TextStyle h1;
    public TextStyle h2;
    public TextStyle h3;
    public TextStyle h4;
    public TextStyle h5;
    public TextStyle h6;
    
    [Header("Paragraph Styles")]
    public float paragraphFontSize;
    public Color paragraphColor;
    

    public TextStyle GetHeaderStyle(int level)
    {
        return level switch
        {
            1 => h1,
            2 => h2,
            3 => h3,
            4 => h4,
            5 => h5,
            6 => h6,
            _ => h1
        };
    }
}
