using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    private Animator animator;
    public Transform playerTransform;
    public float moveSpeed = 0.5f;
    public float closeDistance = 2.5f;
    public float attackDistance = 2.0f;
    private int currentAction = -1;
    private int lastAction = -1; // 마지막 액션 추적
    private bool isActionCompleted = true;

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
            if (!isActionCompleted)
            {
                isActionCompleted = true;
                ChooseNewAction();
            }
        }

        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        directionToPlayer.y = 0;
        if (distanceToPlayer > closeDistance||currentAction==0)
        {
            SetAction(0); // 이동 상태 설정
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
        if (currentAction == 2)
        {
            transform.position -= directionToPlayer * moveSpeed * Time.deltaTime; // 후퇴
        }
        if (distanceToPlayer<attackDistance){
            SetAction(1);
        }
    }

    void ChooseNewAction()
    {
        int newAction;
        do
        {
            newAction = Random.Range(1, 3); // 1부터 3까지 랜덤 선택 (attack, dodge, retreat)
        } while (newAction == lastAction);

        SetAction(newAction);
    }
    // void PerformCurrentAction(float distanceToPlayer)
    // {

    //     // 추가적인 액션 처리가 필요하면 여기에 코드를 추가합니다.
    // }

    void SetAction(int action)
    {
        if (action != currentAction && isActionCompleted)
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
