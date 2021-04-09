using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string playerName;
    public string backStory;
    public float health;
    public float damage;
    public float weapon1Damage;
    public float weapon2Damage;
    public string shoeName;
    public int shoeSize;
    public string shoeType;
    //[SerializeField]
    //[ReadOnlyWithColor(1, 0, 0)]
    //[SpaceWithImage(10)]
    private string HL = "海澜";

    [SpaceWithImage(300)]
    public Shoe shoe;

    [ReadOnly]
    public int achievementCount = 5;
    [ReadOnly]
    public float factor = 0.5f;
}
