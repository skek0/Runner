using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<Transform> roads;
    [SerializeField] float speed;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            roads.Add(transform.GetChild(i));
        }
    }

    private void Update()
    {
        foreach (var road in roads)
        {
            road.Translate(speed* Time.deltaTime * Vector3.back);
        }
    }

    public void InitializePosition()
    {
        Transform road = roads[0];
        roads.RemoveAt(0);
        road.Translate(40 * (roads.Count+1) * Vector3.forward);
        roads.Add(road);
    }
}