using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Grid myTarget = (Grid)target;
        if (GUILayout.Button("update grid"))
        {
            myTarget.BuildGrid();
        }
        if (GUILayout.Button("clear"))
        {
            myTarget.DestroyGrid();
        }
    }
}
