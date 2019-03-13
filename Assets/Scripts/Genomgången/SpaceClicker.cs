using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpaceClicker : MonoBehaviour
{
    public event Action LektionStart;
    public event Action LektionSlut;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LektionStart?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            LektionSlut?.Invoke();
        }
    }
}
