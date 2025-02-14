using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}
public class Runner : MonoBehaviour
{
    [SerializeField]RoadLine currentLine = RoadLine.MIDDLE;

    private void Start()
    {
        currentLine = RoadLine.MIDDLE;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(currentLine > RoadLine.LEFT)
            {
                currentLine--;
                transform.Translate(-2.5f * Vector3.right);
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(currentLine < RoadLine.RIGHT)
            {
                currentLine++;
                transform.Translate(2.5f * Vector3.right);
            }
        }
    }
}