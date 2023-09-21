using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private ParticleSystem playerHurtParticles;
    [SerializeField] private float playerHurtDuration;
    protected override void Start()
    {
        base.Start();
        FindObjectOfType<AudioManager>().Play("Ambient");
    }


    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        FindObjectOfType<AudioManager>().Play("PlayerHurt");
        healthBar.GetComponent<HealthBar>().UpdateHealth(Mathf.Max(CurrentHealth / MaxHealth, 0));
        StartCoroutine(PlayerParticleSystemForDuration());
    }
    public void DisableMovement(bool isDisable) {
        GetComponent<Move>().enabled = !isDisable;
        GetComponent<Jump>().enabled = !isDisable;
        GetComponent<RangedAttack>().enabled = !isDisable;
    }
    protected override IEnumerator WaitAndDie(float ms)
    {
        healthBar.SetActive(false);
        DisableMovement(true);
        yield return base.WaitAndDie(ms);
        sceneController.ReloadScene();
    }
    private IEnumerator PlayerParticleSystemForDuration()
    {
        playerHurtParticles.Play();
        yield return new WaitForSeconds(playerHurtDuration);
        playerHurtParticles.Clear();
    }

}