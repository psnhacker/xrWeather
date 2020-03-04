using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Env_ambient))]
public class WeatherEnvEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Env_ambient generator = (Env_ambient)target;
        if (GUILayout.Button("Find sound"))
        {
            generator.SetSound();
        }
    }
}
