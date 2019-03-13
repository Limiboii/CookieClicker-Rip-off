using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "ShopItems/Cookies per second")]
public class ShopItems : ScriptableObject
{
    public float cps;
    public int cost;
    public float costMultiplier;

    public new string name;
    //Kommer endast aktiveras av knappen med taggen Goku!
    public bool gokuAchievementAvailable;
}
