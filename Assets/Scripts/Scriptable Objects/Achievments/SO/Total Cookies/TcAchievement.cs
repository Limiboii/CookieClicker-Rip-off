using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAchievement", menuName = "Achievements/Total Cookies")]
public class TcAchievement : ScriptableObject
{
    public ulong totalCookiesNeeded;
    public GameObject achievementPopUp;
}
