using System;
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
    [SerializeField] private float offsetX = 2.5f; public float OffsetX => offsetX;
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
        if (GameManager.Instance.State)
        {
            OnKeyUpdate();
        }
        else
        {
            Die();
        }
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
            new Vector3(offsetX * (int)currentLine, rigid.position.y, rigid.position.z),
            Time.fixedDeltaTime * verticalSpeed);
    }

    private void Die()
    {
        GameManager.Instance.Finish();

        animator.Play("Die");
    }
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if(obstacle != null)
        {
            Die();
        }
    }
}