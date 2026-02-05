using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MarkdownPreviewWindow : EditorWindow
{
    private string currentFilePath;
    private VisualElement container;
    private MarkdownParser parser = new MarkdownParser();
    private MarkdownStyleConfig styleConfig;
    
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

        if (styleConfig == null)
        {
            string[] guids = AssetDatabase.FindAssets("t:MarkdownStyleConfig");
            if (guids.Length > 0)
            {
                // TODO: Warning when more than one style config is found
                string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                styleConfig = AssetDatabase.LoadAssetAtPath<MarkdownStyleConfig>(path);
            }
            else
            {
                Debug.LogError("No MarkdownStyleConfig asset found");
                return;
            }
        }

        string content = File.ReadAllText(currentFilePath);
        List<MarkdownBlockBase> blocks = parser.Parse(content);

        container.Clear();

        foreach (var block in blocks)
        {
            var element = block.CreateElement(styleConfig);
            container.Add(element);
        }
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
