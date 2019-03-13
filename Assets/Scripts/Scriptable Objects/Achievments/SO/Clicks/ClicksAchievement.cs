using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAchievement", menuName = "Achievements/Clicks")]
public class ClicksAchievement : ScriptableObject
{
    public ulong clicksNeeded;
    public GameObject achievementPopUp;
}
