using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] float activeTime;
    [SerializeField] float increaseTime;
    public float ActiveTime { get { return activeTime; } }
    public float IncreaseTime { get { return increaseTime; } }

    protected override void Awake()
    {
        base.Awake();

        activeTime = 2.5f;
        increaseTime = 2.5f;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(DecreaseInterval());
    }

    IEnumerator DecreaseInterval()
    {
        while (GameManager.Instance.State && activeTime > 0.5f)
        {
            yield return CoroutineCache.WaitforSeconds(4f);

            activeTime -= 0.25f;
        }
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}