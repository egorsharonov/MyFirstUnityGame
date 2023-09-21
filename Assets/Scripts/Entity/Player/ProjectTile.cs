using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField, Range(0, 100f)] private float damage;
    [SerializeField, Range(0, 100f)] private float speed;
    [SerializeField] public float direction;

    private void Start()
    {
        StartCoroutine(WaitAndDisappear());
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed * direction, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
        }
        Debug.Log("ïûù");
        Destroy(gameObject);
    }
    private IEnumerator WaitAndDisappear()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}