using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class AssetHandler
{
    [OnOpenAsset(1)]
    public static bool OnOpenMarkdown(int instanceID, int line)
    {
        Object obj = EditorUtility.InstanceIDToObject(instanceID);
        string path = AssetDatabase.GetAssetPath(obj);
        if (path.ToLower().EndsWith(".md"))
        {
            MarkdownPreviewWindow.ShowWindow(path);
            return true;
        }

        return false;
    }
}
