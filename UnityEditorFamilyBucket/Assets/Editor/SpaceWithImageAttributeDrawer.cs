using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(SpaceWithImageAttribute))]
public class SpaceWithImageAttributeDrawer : DecoratorDrawer
{
    Texture2D texture2D;
    SpaceWithImageAttribute m_attribute;
    public override float GetHeight()
    {
        if (m_attribute==null)
        {
            m_attribute = (SpaceWithImageAttribute)attribute;
        }
        return base.GetHeight()+ m_attribute.m_height;
    }

    public override void OnGUI(Rect position)
    {
        if (texture2D==null)
        {
            texture2D = Resources.Load<Texture2D>("Icons/star");
        }
        if (m_attribute == null)
        {
            m_attribute = (SpaceWithImageAttribute)attribute;
        }
        GUI.DrawTexture(position, texture2D);
    }
}
