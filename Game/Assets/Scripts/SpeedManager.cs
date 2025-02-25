using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    static float speed = 20f;
    [SerializeField] float limitSpeed = 50f;
    WaitForSeconds interval = new WaitForSeconds(2.5f);

    public static float Speed { get { return speed; } }

    private void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
        while (speed < limitSpeed)  
        {
            yield return interval;
            speed += 2;
            Debug.Log(speed);
        }
        Debug.Log(speed);
    }
}
