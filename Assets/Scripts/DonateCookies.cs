using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DonateCookies : MonoBehaviour
{
    //För över alla kakor till donatedCookies. Skriver ut en text med hur mycket man har donerat. 
    private ulong donatedCookies;
    public event Action DonateEnoughCookies;
    public TextMeshProUGUI donatedCookiesText;

    private void Start()
    {
        donatedCookiesText.text = "You have donated: " + donatedCookies;
    }

    public void DonateAllCookies()
    {
        donatedCookies += GameController1.cookies;
        GameController1.cookies = 0;
        if (donatedCookies >= 1000000)
            DonateEnoughCookies?.Invoke();
        donatedCookiesText.text = "You have donated: " + donatedCookies;
    }
}
