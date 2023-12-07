using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    private Animator animator;
    public Transform playerTransform;
    public float moveSpeed = 0.5f;
    public float closeDistance = 2.5f;

    private int currentAction = -1;
    private int lastAction = -1; // 마지막 액션 추적
    private bool isActionCompleted = true;
    private int retreatFrameCounter = 0; // 후퇴 프레임 카운터

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetBool("isWalking", true);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // 현재 애니메이션이 끝났는지 확인
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            isActionCompleted = true;
        }

        if (distanceToPlayer > closeDistance)
        {
            SetAction(0); // 이동 상태 설정
        }
        else if(isActionCompleted)
        {
            if(currentAction == 1) // attack 후에는 retreat 선택
            {
                SetAction(3);
            }
            else
            {
                int newAction;
                do
                {
                    newAction = Random.Range(1, 3); // 같은 액션을 연속해서 취하지 않도록 랜덤 선택
                } while (newAction == lastAction);
                
                SetAction(newAction);
            }
        }

        if(currentAction == 3 && isActionCompleted)
        {
            if (retreatFrameCounter < 30)
            {
                Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
                transform.position -= directionToPlayer * moveSpeed * Time.deltaTime; // 후퇴
                retreatFrameCounter++;
            }
            else
            {
                retreatFrameCounter = 0; // 카운터 초기화
                isActionCompleted = true; // 후퇴 완료
            }
        }
        else
        {
            if (currentAction == 0 && isActionCompleted) // 이동
            {
                Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
                transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
            }
        }
    }

    void SetAction(int action)
    {
        if (action != currentAction && isActionCompleted && action != lastAction)
        {
            animator.SetBool("isWalking", action == 0);
            animator.SetBool("attack", action == 1);
            animator.SetBool("retreat", action == 2);
            animator.SetBool("dodge", action == 3);
            lastAction = currentAction;
            currentAction = action;
            isActionCompleted = false;
        }
    }
}
