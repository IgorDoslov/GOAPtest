using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    //string myString = "";
    Color colour;

    [MenuItem("Window/Colouriser")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colouriser");
    }

    void OnGUI()
    {
        GUILayout.Label("Colour the selected objects!", EditorStyles.boldLabel);

        //myString = EditorGUILayout.TextField("Name", myString);

        colour = EditorGUILayout.ColorField("Colour", colour);

        if (GUILayout.Button("COLOURISE!"))
        {
            Colourise();
        }

    }

    void Colourise()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer rend = obj.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.sharedMaterial.color = colour;
            }
        }
    }


}
