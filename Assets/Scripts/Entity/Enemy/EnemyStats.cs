using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    protected override void Start()
    {
        MaxHealth = DifficultyManager.instance.GetEnemyHealthByDifficulty();
        base.Start();
    }
    protected override IEnumerator WaitAndDie(float ms)
    {
        
        GetComponentInParent<EnemyPatrol>().enabled = false;
        yield return base.WaitAndDie(ms);
        Destroy(gameObject);
    }
}