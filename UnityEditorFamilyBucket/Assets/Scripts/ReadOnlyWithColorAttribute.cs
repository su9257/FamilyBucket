using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadOnlyWithColorAttribute : PropertyAttribute
{
    public float m_r, m_g, m_b;
    public ReadOnlyWithColorAttribute()
    {

    }

    public ReadOnlyWithColorAttribute(float r, float g, float b)
    {
        m_r = r;
        m_g = g;
        m_b = b;
    }
}
