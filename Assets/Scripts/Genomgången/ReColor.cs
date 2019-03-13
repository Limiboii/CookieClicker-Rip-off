using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReColor : MonoBehaviour
{
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<SpaceClicker>().LektionStart += BecomeRed;
        GameObject.FindWithTag("Player").GetComponent<SpaceClicker>().LektionSlut += BecomeBlue;

    }

    void BecomeRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void BecomeBlue()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    void Update()
    {
        
    }
}
