using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : Singleton<SceneryManager>
{
    [SerializeField] Image screenImage;
    [SerializeField] AudioClip audioClip;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator AsyncLoad(int index)
    {
        AudioManager.Instance.Listen(audioClip);
        screenImage.gameObject.SetActive(true);

        // <asyncOperation.allowSceneActiveation>
        // 장면이 전환될 때 즉시 장면이 활성화되는 것을 허용하는 변수
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0.0f;

        // <asybcOperation.isDone>
        // 해당 동작이 완료되었는지 나타내는 변수
        while(!asyncOperation.isDone)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.progress>
            // 작업의 진행 상태를 나타내는 변수
            if(asyncOperation.progress >= 0.5f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                screenImage.color = color;

                if (color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
            }
            yield return null;
        }
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        Color color = screenImage.color;

        while(color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            screenImage.color = color;
            yield return null;
        }
        yield break;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
