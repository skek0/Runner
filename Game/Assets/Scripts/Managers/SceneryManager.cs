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
        // ����� ��ȯ�� �� ��� ����� Ȱ��ȭ�Ǵ� ���� ����ϴ� ����
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0.0f;

        // <asybcOperation.isDone>
        // �ش� ������ �Ϸ�Ǿ����� ��Ÿ���� ����
        while(!asyncOperation.isDone)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.progress>
            // �۾��� ���� ���¸� ��Ÿ���� ����
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
