using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCookieSound : MonoBehaviour
{
    void Start()
    {
        GameObject.FindWithTag("Cookie").GetComponent<Click>().ClickOnCookie += OnClick;
    }

    void OnClick()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
