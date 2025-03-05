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
        // 선형 보간법
        // 직선에 두 점이 주어졌을 때 그 사이에 위치한 값을 추정하기 위하여
        // 직선 거리에 따라 선형적으로 계산하는 방법

        // Lerp함수의 t 값이 프레임마다 Time.DeltaTime만큼 증가하고 그에따라 대상이 부드럽게 움직
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