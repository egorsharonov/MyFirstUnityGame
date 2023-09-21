using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCoin : Coin
{
    [SerializeField, Range(0, 500f)] private float score;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.AddScore(score);
            base.OnTriggerEnter2D(collision);
        }
    }
}