using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWithImageAttribute : PropertyAttribute
{
    public int m_height;
    public SpaceWithImageAttribute()
    {
        
    }

    public SpaceWithImageAttribute(int height)
    {
        m_height = height;
    }
}
