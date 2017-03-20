using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteShowAttribute : PropertyAttribute
{
    public float x;
    public float y;
    public SpriteShowAttribute(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}

[CustomPropertyDrawer(typeof(SpriteShowAttribute))]
public class SpriteShowDrawer : PropertyDrawer
{

    SpriteShowAttribute jimmy
    {
        get { return ((SpriteShowAttribute)attribute); }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 10;
    }
    

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect drawRect = position;
        drawRect.height += jimmy.y;

        EditorGUI.PropertyField(drawRect, property, label);

        Sprite mySprite = (Sprite)property.objectReferenceValue;
        mySprite = EditorGUILayout.ObjectField(mySprite, typeof(Sprite), false) as Sprite;
        if (property.objectReferenceValue != null)
        {
            position.y = EditorGUI.GetPropertyHeight(property, label, true);
            position.height = jimmy.y;
            position.width = jimmy.x;
            //position.height += jimmy.x;
            GUI.DrawTexture(position, mySprite.texture);
            /*drawRect.y = drawRect.y;
            GameObject myGameObj = new GameObject();
            myGameObj.transform.position = EditorGUI.Vector3Field(drawRect, "Position: ", myGameObj.transform.position);*/
        }

        //base.OnGUI(position, property, label);
    }
}