using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameController1 : MonoBehaviour
{
    //Alla viktiga variabler.
    public static ulong cookies = 0;
    public static ulong cookiesTotal = 0;
    public static ulong cookiesPerClick = 1;
    private float cpsCd = 0.1f;

    [Header("Cookies")]
    public static double cookiesPerSecond = 0;

    //Varför ska det vara [Space] under för att det ska vara mellanrum mellan "Text" och "cookiesPerSecond"
    [Header("Text")]
    [Space]
    [Space]
    public TextMeshProUGUI clicksText;
    public TextMeshProUGUI cookiesText;
    public TextMeshProUGUI cookiesTotalText;
    public TextMeshProUGUI cookiesPerSecondText;
    
    public event Action TotalCookiesAchievementGet;
    public event Action CpsAchievementGet;

    void Start()
    {
        //Startar passive cookie gain här. Samt hittar eventet som körs när jag klickar på kakan.
        StartCoroutine(AddCps());
        GameObject.FindWithTag("Cookie").GetComponent<Click>().ClickOnCookie += AddCookies;
    }

    void Update()
    {
        //All text måste uppdateras konstant.
        cookiesText.text = $"{cookies}";
        cookiesPerSecondText.text = $"Cps: {cookiesPerSecond.ToString("0.0")}";
        cookiesTotalText.text = $"All Time Cookies: {cookiesTotal}";
        clicksText.text = $"All clicks: {Click.timesClicked}";

        //Cheat button samt quit knapp    Hjälper ifall du inte orkar köra för att kolla donate achievement.
        if (Input.GetKeyDown(KeyCode.S))
            cookies += 1000000;
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            Application.Quit(0);
    }

    //Varje gång jag klickar.
    void AddCookies()
    {
        cookies += cookiesPerClick;
        cookiesTotal += cookiesPerClick;
        TotalCookiesAchievementGet?.Invoke();
    }

    //Passive cookies
    public IEnumerator AddCps()
    {
        float cookiesOnHold = 0;
        while (true)
        {
            yield return new WaitForSeconds(cpsCd);
            cookiesOnHold += (float)cookiesPerSecond * cpsCd;

            if (cookiesOnHold >= 1)
            {
                //Adderar cookiesOnHold utan dess decimaler.
                cookies += (ulong)Mathf.Floor(cookiesOnHold);
                cookiesTotal += (ulong)Mathf.Floor(cookiesOnHold);
                //cookiesOnHold förlorar alla heltal och har bara kvar decimalerna.
                cookiesOnHold = cookiesOnHold % 1; 
                TotalCookiesAchievementGet?.Invoke();
            }
        }
    }

    //Funktionen för att köpa cps items.
    public void BuyItem(ulong cost, float cps)
    {
        cookies -= cost;
        cookiesPerSecond += cps;
        CpsAchievementGet?.Invoke();
    }
    
    //Funktionen för att köpa cpc items.
    public void BuyClickItem(ulong cost, ulong clickMultiplier)
    {
        cookies -= cost;
        cookiesPerClick = cookiesPerClick * clickMultiplier;
    }
}