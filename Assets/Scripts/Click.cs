using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Click : MonoBehaviour
{
    public float minScale;
    public static ulong timesClicked = 0;
    private SpriteRenderer spriteRend;

    public event Action TimesClickedAchievementGet;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public event Action ClickOnCookie;
    
    private void OnMouseDown()
    {
        ClickOnCookie?.Invoke();
        timesClicked += 1;
        StartCoroutine(CookieScaling());

        TimesClickedAchievementGet?.Invoke();
    }
    
    //gör kakan mindre och sedan tillbaka till orginalstorlek när man klickar på den.
    public IEnumerator CookieScaling()
    {
        spriteRend.transform.localScale = Vector2.one * minScale;
        yield return new WaitForSeconds(0.2f);
        spriteRend.transform.localScale = Vector2.one;
    }
}
