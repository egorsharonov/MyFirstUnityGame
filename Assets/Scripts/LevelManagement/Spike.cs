using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField, Range(0, 100f)] private float damage;
    [SerializeField, Range(0, 100f)] private float pushForce;

    private void DamagePlayer(Collision2D player, float damageAmount)
    {
        var playerObject = player.gameObject;
        float xVelocity = player.gameObject.GetComponent<Rigidbody2D>().velocity.x;

        playerObject.GetComponent<Rigidbody2D>().velocity = (new Vector2 (-xVelocity, 0).normalized + new Vector2(0,1)) * pushForce;
        playerObject.GetComponent<PlayerStats>().TakeDamage(damageAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            DamagePlayer(collision, damage);
    }
}
