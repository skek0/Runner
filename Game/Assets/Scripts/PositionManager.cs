using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    Coroutine coroutine;
    [SerializeField] int index = -1;
    [SerializeField] List<Transform> parentRoads;
    [SerializeField] List<float> randomPositionZ;
    [SerializeField] Transform[] positionRandomX;
    ObstacleManager obstacleManager;

    private void Awake()
    {
        for(int i = 0; i < 16; i++)
        {
            randomPositionZ.Add(i*2.5f -10f);
        }
    }
    private void Start()
    {
        obstacleManager = FindAnyObjectByType<ObstacleManager>();
    }

    public void InitializePosition()
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(SetPosition());
        }
        index = (index + 1) % parentRoads.Count;

        transform.SetParent(parentRoads[index]);
    }

    public IEnumerator SetPosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.5f);

            transform.localPosition = new Vector3(0, 0, randomPositionZ[Random.Range(0, randomPositionZ.Count)]);
            obstacleManager.GetObstacle().SetActive(true);
            obstacleManager.GetObstacle().transform.position = positionRandomX[Random.Range(0, positionRandomX.Length)].position;
            obstacleManager.GetObstacle().transform.SetParent(transform.root.GetChild(index));
        }    
    }

    public void SetParentToNextRoad(Transform road)
    {
        transform.SetParent(road);
    }
}
