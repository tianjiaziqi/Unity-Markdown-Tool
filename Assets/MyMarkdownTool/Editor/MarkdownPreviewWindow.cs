using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MarkdownPreviewWindow : EditorWindow
{
    private string currentFilePath;
    private VisualElement container;
    
    [MenuItem("Tools/Markdown Preview")]
    public static void ShowWindowFromMenu()
    {
        MarkdownPreviewWindow window = GetWindow<MarkdownPreviewWindow>();
        window.titleContent = new GUIContent("Markdown Preview");
        window.Show();
    }
    public static void ShowWindow(string filePath)
    {
        MarkdownPreviewWindow window = GetWindow<MarkdownPreviewWindow>();
        window.titleContent = new GUIContent("Markdown Preview");
        window.LoadFile(filePath);
    }
    
    public void LoadFile(string path)
    {
        currentFilePath = path;
        Refresh();
    }
    
    private void Refresh()
    {
        if (string.IsNullOrEmpty(currentFilePath)) return;

        string content = File.ReadAllText(currentFilePath);
        rootVisualElement.Clear();
        var label = new Label(content);
        label.style.whiteSpace = WhiteSpace.Normal;
        rootVisualElement.Add(label);
    }

    public void CreateGUI()
    {
        var root = rootVisualElement;
        
        var scrollView = new ScrollView();
        root.Add(scrollView);
        
        container = new VisualElement();
        scrollView.Add(container);
        
        if (!string.IsNullOrEmpty(currentFilePath))
        {
            Refresh();
        }
    }
}
