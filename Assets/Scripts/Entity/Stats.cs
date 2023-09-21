using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    [SerializeField, Range(1f, 100f)] protected float maxHealth = 100f;
    float currentHealth;
    Animator animator;

    public float MaxHealth { get => maxHealth; protected set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; private set => currentHealth = value; }

    protected virtual void Awake() => animator = GetComponent<Animator>();

    protected virtual void Start() => CurrentHealth = MaxHealth;


    public virtual void TakeDamage(float damageAmount)
    {
        animator.SetTrigger("Hurt");
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
            Die();
    }

    public void Heal(float amount) => Mathf.Min(CurrentHealth += amount, MaxHealth);

    public virtual void Die()
    {
        DisableCollider();
        animator.SetBool("isDead", true);
        animator.ResetTrigger("Hurt");
        animator.SetTrigger("Dead");
        StartCoroutine(WaitAndDie(1000));
    }

    private void DisableCollider() {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    protected IEnumerator WaitMilliseconds(float ms)
    {
        yield return new WaitForSeconds(ms / 1000);
    }

    protected virtual IEnumerator WaitAndDie(float ms)
    {
        yield return WaitMilliseconds(ms);
    }

}