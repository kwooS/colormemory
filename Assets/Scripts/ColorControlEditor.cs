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
        if (GUILayout.Button("Continue Digit Span")) 
        { 
            generator.proceed(); 
        } 
    } 
}
