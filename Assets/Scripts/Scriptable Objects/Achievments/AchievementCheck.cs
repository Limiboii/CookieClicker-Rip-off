using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AchievementCheck : MonoBehaviour
{
    [Header("Achievements")]
    //bools som gör att man inte kan få samma achievement flera gånger.
    bool luckyAchievementLeft;
    bool gokuAchievementLeft;
    bool donateAchievementLeft;
    bool cpsAchievementLeft;

    //pop-ups då jag inte hade ett scriptableObject för några achievements.
    float luckyAchievement;
    public GameObject luckyPopUp;
    public GameObject gokuPopUp;
    public GameObject donatePopUp;

    //så att det inte fortsätter ge achievements som inte finns efter att arrayen har nått sista.
    int tcLength = 0;
    int cLength = 0;
    public TcAchievement[] tcAchievement;
    public CpsAchievement[] cpsAchievement;
    public ClicksAchievement[] timesClickedAchievement;

    //Alla 12 achievements displayer som jag tar setActive på. Hittade inget bra sätt att göra det med scriptableObject.
    public GameObject[] totalCookiesDisplays;
    public GameObject[] ClickDisplays;
    public GameObject[] otherDisplays;

    //Spawnpoint för alla pop-ups.
    public GameObject SpawnPoint;
    float timer;

    private void Start()
    {
        //Hittar alla events som har med achievements att göra och aktiverar 4 achievements ifall de skulle var false.
        GameObject.FindWithTag("GameController").GetComponent<GameController1>().TotalCookiesAchievementGet += CheckTcAchievement;
        GameObject.FindWithTag("GameController").GetComponent<GameController1>().CpsAchievementGet += CheckCpsAchievement;
        GameObject.FindWithTag("Cookie").GetComponent<Click>().TimesClickedAchievementGet += CheckClicksAchievement;
        GameObject.FindWithTag("GokuButton").GetComponent<ItemDisplay>().GokuGet += CheckGokuAchievement;
        GameObject.FindWithTag("DonateButton").GetComponent<DonateCookies>().DonateEnoughCookies += CheckDonateAchievement;

        luckyAchievementLeft = true;
        gokuAchievementLeft = true;
        donateAchievementLeft = true;
        cpsAchievementLeft = true;
    }

    //Där jag kollar mina Total cookies och sedan gör så att achievementet får en pop-up samt visas på achievement fliken.
    void CheckTcAchievement()
    {
        if (tcAchievement.Length > tcLength)
            if (GameController1.cookiesTotal >= tcAchievement[tcLength].totalCookiesNeeded)
            {
                totalCookiesDisplays[tcLength].SetActive(true);
                Instantiate(tcAchievement[tcLength].achievementPopUp, SpawnPoint.transform);
                tcLength++;
            }
    }

    //Samma som innan förutom att det endast ska köras en gång och då kan jag skriva in allt utan variabler.
    void CheckCpsAchievement()
    {
        if (cpsAchievementLeft)
            if (GameController1.cookiesPerSecond >= cpsAchievement[0].cpsNeeded)
            {
                otherDisplays[0].SetActive(true);
                Instantiate(cpsAchievement[0].achievementPopUp, SpawnPoint.transform);
                cpsAchievementLeft = false;
            }
    }

    //Samma som första.
    void CheckClicksAchievement()
    {
        if (timesClickedAchievement.Length > cLength)
            if (Click.timesClicked >= timesClickedAchievement[cLength].clicksNeeded)
            {
                ClickDisplays[cLength].SetActive(true);
                Instantiate(timesClickedAchievement[cLength].achievementPopUp, SpawnPoint.transform);
                cLength++;
            }
    }

    //Ger Achievementet för att äga en Goku.
    private void CheckGokuAchievement()
    {
        if (gokuAchievementLeft)
        {
            StartCoroutine(GoGoku());
        }
    }

    //En random som behövde vara i update och jag gjorde achievementet här då det bara fanns 1 av det.
    private void Update()
    {
        if (luckyAchievementLeft)
        {
            luckyAchievement = UnityEngine.Random.Range(0, 9999);
            if (luckyAchievement == 1)
            {
                Instantiate(luckyPopUp, SpawnPoint.transform);
                otherDisplays[2].SetActive(true);
                luckyAchievementLeft = false;
            }
        }
    }

    //Ger Achievementet för att donera kakor. Finns bara 1 sådant achievement.
    private void CheckDonateAchievement()
    {
        if (donateAchievementLeft)
        {
            Instantiate(donatePopUp, SpawnPoint.transform);
            otherDisplays[3].SetActive(true);
            donateAchievementLeft = false;
        }
    }

    IEnumerator GoGoku()
    {
        yield return new WaitForSeconds(1);
        Instantiate(gokuPopUp, SpawnPoint.transform);
        otherDisplays[1].SetActive(true);
        gokuAchievementLeft = false;
    }
}