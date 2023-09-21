using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform snapPoint;
    [SerializeField] private Transform healthBar;
    [SerializeField] private PlayerStats player;

    public void UpdateHealth(float normalizedAmount)
    {
        healthBar.localScale = new Vector3(normalizedAmount, healthBar.localScale.y, healthBar.localScale.z);
        healthBar.position = snapPoint.position;
    }
}
