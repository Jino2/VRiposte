using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    private Animator animator;
    public Transform playerTransform;
    public float moveSpeed = 0.2f;
    public float closeDistance = 3.0f;

    private int currentAction = -1; // 현재 상태를 나타내는 변수
    private int frameCounter = 0; // 프레임 카운터
    private int minFrames = 3; // 상태가 유지되어야 하는 최소 프레임 수 (예: N = 60)

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetBool("isWalking", true);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        Debug.Log("Distance: " + distanceToPlayer);

        if (distanceToPlayer > closeDistance)
        {
            // 플레이어에게 접근
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;

            SetAction(3); // 이동 상태 설정
        }
        else
        {
            if (frameCounter >= minFrames)
            {
                // 프레임 카운터가 최소 프레임 수에 도달하면 새로운 행동 선택
                SetAction(Random.Range(0, 3));
                frameCounter = 0; // 프레임 카운터 재설정
            }
            else
            {
                frameCounter++; // 프레임 카운터 증가
            }
        }
    }

    void SetAction(int action)
    {
        if (action != currentAction)
        {
            // 애니메이션 상태 변경
            // animator.setBool("idle", action==4)
            animator.SetBool("isWalking", action == 3);
            animator.SetBool("attack", action == 0);
            animator.SetBool("dodge", action == 1);
            animator.SetBool("retreat", action == 2);
            currentAction = action; // 현재 상태 업데이트
            frameCounter = 0; // 프레임 카운터 재설정
        }
    }
}
