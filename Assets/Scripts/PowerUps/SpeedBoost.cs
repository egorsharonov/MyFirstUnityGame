using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Coin
{
    [SerializeField, Range(0, 500f)] private float speedDelta;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Move>().ChangeMaxSpeed(speedDelta);
            base.OnTriggerEnter2D(collision);
        }
    }
}