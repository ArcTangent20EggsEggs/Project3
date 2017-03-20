using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorLineAttribute : PropertyAttribute
{
    public readonly int spaceSize;
    public Color color;

    public ColorLineAttribute(int spaceSize, float r, float g, float b)
    {
        this.spaceSize = spaceSize;
        this.color = new Color(r, g, b);
    }
}

[CustomPropertyDrawer(typeof(ColorLineAttribute))]
public class ColorLineDrawer : DecoratorDrawer
{
    ColorLineAttribute jerry
    {
        get { return ((ColorLineAttribute)attribute); }
    }

    public override float GetHeight()
    {
        return base.GetHeight() + jerry.spaceSize;
    }

    public override void OnGUI(Rect position)
    {
        float lW = 500;
        float lH = 1;
        float x = (position.x + (position.width / 2)) - lW / 2;
        float y = (position.y + (lH / 2));

        Color oldCol = GUI.color;
        GUI.color = jerry.color;
        EditorGUI.DrawPreviewTexture(new Rect(x, y, lW, lH), Texture2D.whiteTexture);
        GUI.color = oldCol;
        //base.OnGUI(position);
    }
}