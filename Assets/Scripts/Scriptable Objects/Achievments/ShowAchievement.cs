using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAchievement : MonoBehaviour
{
    //När en pop-up aktiveras så sitter det här scriptet på. 
    private void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
