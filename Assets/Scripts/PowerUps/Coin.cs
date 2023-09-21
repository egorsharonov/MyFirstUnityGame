using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float disappearDuration;
    [SerializeField] private ParticleSystem particles;
    protected LevelManager levelManager;


    private void Awake()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("CoinPickup");
            Instantiate(particles, transform.position, Quaternion.identity, null).Play();
            GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine(ScaleAndFade(disappearDuration));
        }
    }

    private IEnumerator ScaleAndFade(float duration)// duration in seconds
    {
        float targetScale = 3.0f;
        float targetAlpha = 0.0f;

        Vector3 initialScale = transform.localScale;
        Color initialColor = GetComponent<SpriteRenderer>().color;

        float timer = 0.0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            // Увеличение масштаба
            float scale = Mathf.Lerp(initialScale.x, targetScale, timer / duration);
            transform.localScale = new Vector3(scale, scale, scale);

            // Уменьшение прозрачности
            float alpha = Mathf.Lerp(initialColor.a, targetAlpha, timer / duration);
            Color color = initialColor;
            color.a = alpha;
            GetComponent<SpriteRenderer>().color = color;

            yield return null;
        }

        // Установка окончательного масштаба и прозрачности
        transform.localScale = new Vector3(targetScale, targetScale, targetScale);
        Color finalColor = initialColor;
        finalColor.a = targetAlpha;
        GetComponent<SpriteRenderer>().color = finalColor;
        Destroy(gameObject);
    }


}