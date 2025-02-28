using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    [SerializeField] int index = -1;
    [SerializeField] List<Transform> parentRoads;
    [SerializeField] List<float> randomPositionZ;

    private void Awake()
    {
        for(int i = 0; i < 16; i++)
        {
            randomPositionZ.Add(i*2.5f -10f);
        }
    }

    public void InitializePosition()
    {
        index = (index + 1) % parentRoads.Count;

        transform.SetParent(parentRoads[index]);


    }
    public void SstParentToNextRoad(Transform road)
    {
        transform.SetParent(road);
    }
}
