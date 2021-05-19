using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerReload : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 0f;
    public float timeLeft;

    void Start()
    {
        timerBar = GetComponent<Image> ();
        timeLeft = maxTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;

        }
    }
}
