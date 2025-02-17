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
    Rigidbody rigid;
    [SerializeField] float offsetX = 2.5f;

    private void Start()
    {
        currentLine = RoadLine.MIDDLE;
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        OnKeyUpdate();
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentLine > RoadLine.LEFT)
            {
                currentLine--;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentLine < RoadLine.RIGHT)
            {
                currentLine++;
            }
        }
    }
    public void Move()
    {
        rigid.position = new Vector3(2.5f * (float)currentLine, 0, -6);
    }

}