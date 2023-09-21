using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField, Range(0, 20f)] private float speed;
    private Vector3 initialScale;
    private bool isMovingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator animator;


    private void Start()
    {
        initialScale = enemy.localScale;
    }

    private void Update()
    {
        if (enemy != null)
        {
            if (isMovingLeft)
            {
                if (enemy.position.x >= leftEdge.position.x)
                    MoveInDirection(-1);
                else
                {
                    ChangeDirection();
                }
            }
            else
            {
                if (enemy.position.x <= rightEdge.position.x)
                    MoveInDirection(1);
                else
                {
                    ChangeDirection();
                }
            }
        }
    }

    private void OnDisable()
    {
        if (animator != null)
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void ChangeDirection()
    {
        animator.SetBool("isMoving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            isMovingLeft = !isMovingLeft;
    }

    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        animator.SetBool("isMoving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initialScale.x) * direction, initialScale.y, initialScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed,
                                     enemy.position.y, enemy.position.z);
    }

}