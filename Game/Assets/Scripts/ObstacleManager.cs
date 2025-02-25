using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;

    [SerializeField] List<GameObject> obstacleList;

    private void Start()
    {
        AddObstacle();
    }
    void AddObstacle()
    {
        GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)]);
        obstacleList.Add(newObstacle);
        newObstacle.SetActive(false);
    }
}
