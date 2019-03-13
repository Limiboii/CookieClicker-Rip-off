using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAchievement", menuName = "Achievements/Cookies Per Second")]
public class CpsAchievement : ScriptableObject
{
    public float cpsNeeded;
    public GameObject achievementPopUp;
}
