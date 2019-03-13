using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ItemDisplay : MonoBehaviour
{
    public ShopItems item;
    public ClickShopItems clickItem;
    public GameController1 gc;

    //Text på knapparna som uppdateras.
    public TextMeshProUGUI cpsText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI timesBoughtNumber;

    public event Action GokuGet;

    //En cost variabel som gör att scriptableObject base cost inte ändras.
    private ulong cost;
    private int timesBought;
    private float costOnHold;

    private void Start()
    {
        //Nullcheckar då jag inte alltid har variabeln item.
        if (item != null)
        {
            cost = (ulong)item.cost;
            nameText.text = item.name;
            item.gokuAchievementAvailable = true;
        }

        //Har inte heller alltid cps text
        if (cpsText != null)
            cpsText.text = "Cps: " + item.cps;

        //annan cost än 2 steg upp.
        if (clickItem != null)
        {
            costText.text = "Cost " + clickItem.cost;
            nameText.text = clickItem.name;
        }
    }

    private void Update()
    {
        if (item != null)
        {
            costText.text = "Cost: " + cost;
            timesBoughtNumber.text = "" + timesBought;
        }
    }

    public void BuyThis()
    {
        //Kände att det var bra att nullchecka för ifall. Funktion för cps items.
        if (item != null)
            if (GameController1.cookies >= cost)
            {
                gc.BuyItem(cost, item.cps);
                timesBought += 1;

                costOnHold += cost * item.costMultiplier;
                cost += (ulong)Mathf.Floor(costOnHold);
                costOnHold = costOnHold % 1;

                if (item.gokuAchievementAvailable)
                {
                    GokuGet?.Invoke();
                    item.gokuAchievementAvailable = false;
                }
            }
    }
    //Funktion för cpc items.
    public void BuyClickItem()
    {
        if (clickItem != null)
            if (GameController1.cookies >= cost)
            {
                gc.BuyClickItem((ulong)clickItem.cost, (ulong)clickItem.cpcMultiplier);
                gameObject.SetActive(false);
            }
    }
}