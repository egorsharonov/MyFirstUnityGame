using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;
using System.Collections;
using System.Collections.Generic;

public class Finish : MonoBehaviour
{
    private LevelManager levelManager;
    [SerializeField] ParticleSystem finishParticles;

    private void Awake()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (levelManager.Finish())
            {
                GetComponent<Renderer>().material.color = Color.magenta;
                StartCoroutine(Wait());
            }
            
        }
    }
    private IEnumerator Wait()
    {
        Instantiate(finishParticles, transform.position, Quaternion.identity, null).Play();
        yield return new WaitForSeconds(3);
        GameInterface.Instance.ShowWinPanel();
    }
}