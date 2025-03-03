using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> obstacles;
    int rand = 0;

    [SerializeField] List<string> obstacleNames;

    WaitForSeconds waitforseconds = new(2.5f);

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
        int count = 0;
        while(true) // 2.5초마다 반복
        {
            count = 0;
            rand = Random.Range(0, obstacles.Count);

            while (obstacles[rand].activeSelf && count < obstacles.Count)
            {
                rand = (rand+1)% obstacles.Count;
                count++;
            }
            if (count >= obstacles.Count)
            {
                AddObstacle();
                obstacles[obstacles.Count - 1].SetActive(true);
                yield return waitforseconds;
                continue;
            }

            //obstacles[rand].SetActive(true);
            yield return waitforseconds;
        }
    }

    void AddObstacle()
    {
        GameObject prefab = ResourcesManager.Instance.Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)]);
        prefab.SetActive(false);
        obstacles.Add(prefab);
    }
}