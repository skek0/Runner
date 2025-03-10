using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text textTime;
    int minute = 0;
    int second = 0;
    int milli = 0;
    float time = 0f;

    private void Awake()
    {
        textTime = GetComponent<Text>();
    }

    private void Start()
    {
        StartCoroutine(Watch());
    }

    IEnumerator Watch()
    {
        while (GameManager.Instance.State)
        {
            time += Time.deltaTime;

            minute = (int)time / 60;
            second = (int)time % 60;
            milli = (int)(time * 100) % 100;

            textTime.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, milli);

            yield return null;
        }
    }
}