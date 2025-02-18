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
    [SerializeField] Animator animator;

    private void Start()
    {
        currentLine = RoadLine.MIDDLE;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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
                animator.Play("Left_Avoid");
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentLine < RoadLine.RIGHT)
            {
                currentLine++;
                animator.Play("Right_Avoid");
            }
        }
    }
    public void Move()
    {
        rigid.position = new Vector3(2.5f * (float)currentLine, 0, -6);
    }

}