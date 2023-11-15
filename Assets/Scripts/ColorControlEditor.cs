using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ColorControl))] 
public class CubeGenerateButton : Editor 
{ 
    public override void OnInspectorGUI() 
    { 
        base.OnInspectorGUI(); 
        ColorControl generator = (ColorControl)target;

        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Continue Digit Span", GUILayout.Height(100))) 
        { 
            generator.Proceed();
        }
        if (GUILayout.Button("Practice Session", GUILayout.Height(100)))
        {
            generator.PracticeSession();
        }
        if (GUILayout.Button("Update Infomation", GUILayout.Height(100)))
        {
            generator.UpdateInformation();
        }
        GUILayout.EndHorizontal();
    } 
}
