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
    [SerializeField] float verticalSpeed = 25.0f;

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
        // ���� ������
        // ������ �� ���� �־����� �� �� ���̿� ��ġ�� ���� �����ϱ� ���Ͽ�
        // ���� �Ÿ��� ���� ���������� ����ϴ� ���

        // Lerp�Լ��� t ���� �����Ӹ��� Time.DeltaTime��ŭ �����ϰ� �׿����� ����� �ε巴�� ����
        rigid.position = Vector3.Lerp
            (rigid.position,
            new Vector3(offsetX * (int)currentLine, 0, -4),
            Time.fixedDeltaTime * verticalSpeed);
    }

}