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

    private void Update()
    {
        gameObject.transform.Translate(0, 1 * Time.deltaTime, 0);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
