using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private bool isSpinning;
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<SpaceClicker>().LektionStart += () => { isSpinning = true; };
        GameObject.FindWithTag("Player").GetComponent<SpaceClicker>().LektionSlut += () => isSpinning = false;

    }

    void Update()
    {
        if (isSpinning)
            transform.Rotate(0, 0, 270 * Time.deltaTime);
    } 
}
