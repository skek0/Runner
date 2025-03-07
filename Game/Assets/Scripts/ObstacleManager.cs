using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> obstacles;
    int rand = 0;

    [SerializeField] List<string> obstacleNames;

    private void Start()
    {
        Create();

        StartCoroutine(ActivateObstacles());
    }

    public void Create()
    {
        obstacles.Capacity = 10;
        for (int i = 0; i < createCount; i++)
        {
            AddObstacle();
        }
    }
    public GameObject GetObstacle()
    {
        return obstacles[rand];
    }

    IEnumerator ActivateObstacles()
    {
        while(GameManager.Instance.State) // 2.5초마다 반복
        {
            yield return CoroutineCache.WaitforSeconds(TimeManager.Instance.IncreaseTime);

            rand = Random.Range(0, obstacles.Count);

            while (obstacles[rand].activeSelf)
            {
                if(ExamineActive())
                {
                    AddObstacle();
                }
                rand = (rand+1) % obstacles.Count;
            }
        }
    }

    private bool ExamineActive()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }
        return true;
    }

    void AddObstacle()
    {
        GameObject prefab = ResourcesManager.Instance.Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)]);
        prefab.SetActive(false);
        obstacles.Add(prefab);
    }
}