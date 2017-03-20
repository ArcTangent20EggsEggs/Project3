using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VectorScaleAttribute : PropertyAttribute
{

    public float min;
    public float max;
    public VectorScaleAttribute(float mi, float ma)
    {
        this.min = mi;
        this.max = ma;
    }

}

[CustomPropertyDrawer(typeof(ColorLineAttribute))]
public class VectorScaleDrawer : PropertyDrawer
{
    VectorScaleAttribute jerry
    {
        get { return ((VectorScaleAttribute)attribute); }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        base.OnGUI(position, property, label);
        Vector3 myVector = property.vector3Value;
        if(myVector != null)
        {
            float myFloat1 = myVector.x;
            float myFloat2 = myVector.y;
            float myFloat3 = myVector.y;
            myFloat1 = EditorGUI.Slider(position, "X: ", myFloat1, jerry.min, jerry.max);
            myFloat2 = EditorGUI.Slider(position, "Y: ", myFloat2, jerry.min, jerry.max);
            myFloat3 = EditorGUI.Slider(position, "Z: ", myFloat3, jerry.min, jerry.max);
            EditorGUI.FloatField(position, "X: ", myFloat1);
            EditorGUI.FloatField(position, "Y: ", myFloat2);
            EditorGUI.FloatField(position, "Z: ", myFloat3);
        }
    }
}