using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red; // Warna saat terkena damage
    private Color originalColor;
    public float colorChangeDuration = 0.5f; // Durasi warna berubah
    public float damageAmount = 10f; // Besar damage

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HealthEntity health = GetComponent<HealthEntity>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
            StartCoroutine(ChangeColorTemporarily());
        }
    }

    IEnumerator ChangeColorTemporarily()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = hitColor;
            yield return new WaitForSeconds(colorChangeDuration);
            spriteRenderer.color = originalColor;
        }
    }
}
