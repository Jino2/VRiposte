using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    private Animator animator;
    public Transform playerTransform;
    public float moveSpeed = 0.5f;
    public float closeDistance = 3.0f;
    public float attackDistance = 2.0f;
    private int currentAction = -1;
    private int lastAction = -1; // 마지막 액션 추적
    float distanceToPlayer;
    Vector3 directionToPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetBool("isWalking", true);
        currentAction=0;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        directionToPlayer = (playerTransform.position - transform.position).normalized;
        directionToPlayer.y = 0;

        if(distanceToPlayer<closeDistance){
            Debug.Log(distanceToPlayer);
            ChooseNewAction();
        }
        if(distanceToPlayer>closeDistance){
            Debug.Log(distanceToPlayer);
            SetAction(0);
        }

        if (currentAction == 0)
        {
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
        if (currentAction == 2)
        {
            transform.position -= 2*directionToPlayer * moveSpeed * Time.deltaTime; // 후퇴
        }
    }

    void ChooseNewAction()
    {
        int newAction;
        newAction = Random.Range(1, 4); // 1부터 3까지 랜덤 선택 (attack, dodge, retreat)
        SetAction(newAction);
    }

    void SetAction(int action)
    {
        animator.SetBool("isWalking", action == 0);
        animator.SetBool("attack", action >= 2);
        animator.SetBool("retreat", action == 1);
        if(action>=2){
            int newAction; 
            newAction = Random.Range(0, 5); // 1부터 3까지 랜덤 선택 (attack, dodge, retreat)
            animator.SetInteger("att_motion",newAction);
        }
        currentAction = action;
    }
}