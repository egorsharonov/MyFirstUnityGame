using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    private Collider2D objectCollider; // Ссылка на компонент Renderer для включения/выключения видимости
    private SpriteRenderer spriteRenderer;
    [SerializeField] private LiliesMove move;
    [SerializeField] private Disappear disappear;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
            move.enabled = true;
            disappear.Destroy();
        }
            

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            spriteRenderer.enabled = true;
    }
}
