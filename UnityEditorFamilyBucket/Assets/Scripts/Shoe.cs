using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShoeType
{
    Leather, Bronze, Iron, Steel
}
[System.Serializable]
public class Shoe
{
    public string name;
    public ShoeType shoeType;
    public int size;
    public string description;

    public Shoe()
    {
        name = "";
        shoeType = ShoeType.Leather;
        size = 0;
        description = "";
    }
}
