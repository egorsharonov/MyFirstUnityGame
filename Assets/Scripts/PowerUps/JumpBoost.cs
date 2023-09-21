using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : Coin
{
    [SerializeField, Range(0, 50)] private int jumpDelta;


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Jump>().ChangeMaxAirJumps(jumpDelta);
            base.OnTriggerEnter2D(collision);
        }
    }
}