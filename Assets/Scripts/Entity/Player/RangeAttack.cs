using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    [SerializeField] private GameObject blobPrefab;
    [SerializeField] private InputController playerController;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform attackPoint;
    private float attackTimer = Mathf.Infinity;

    bool wantsToAttack;

    private void Update()
    {
        wantsToAttack = playerController.RetrieveRangedAttackInput();
        attackTimer += Time.deltaTime;

        if (wantsToAttack && attackTimer > attackCooldown)
        {
            GetComponent<Animator>().SetTrigger("Attack");
            attackTimer = 0;
            //attack
            var projectile = Instantiate(blobPrefab, attackPoint.position, Quaternion.identity, null);
            projectile.GetComponent<Projectile>().direction = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        }
    }

}