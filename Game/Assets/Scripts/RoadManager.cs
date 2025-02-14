using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<Transform> roads;
    [SerializeField] float speed;
    [SerializeField] float roadSize;

    float movedDistance = 0f;
    int turn = 0;

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
            movedDistance += speed * Time.deltaTime;
        }
        
        if(movedDistance > roadSize*roads.Count)
        {
            movedDistance = 0f;
            roads[turn++].Translate(roadSize* roads.Count * Vector3.forward);
            if (turn >= roads.Count) turn = 0;
        }
    }
}
