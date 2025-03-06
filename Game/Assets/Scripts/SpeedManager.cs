using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnSpeedIncresed;
    static float speed = 20f;
    [SerializeField] float limitSpeed = 50f;

    public static float Speed { get { return speed; } }

    private void Awake()
    {
        speed = 20f;
    }

    private void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
        while (GameManager.Instance.State && speed < limitSpeed)  
        {
            yield return CoroutineCache.WaitforSeconds(2.5f);
            speed += 2;
            OnSpeedIncresed?.Invoke();
        }
    }
}
