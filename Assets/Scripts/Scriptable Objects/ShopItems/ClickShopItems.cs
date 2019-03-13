using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "ShopItems/Cookies per click")]
public class ClickShopItems : ScriptableObject
{
    public int cpcMultiplier;
    public int cost;

    public new string name;
}
