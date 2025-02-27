using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red; // Warna saat tertabrak
    private Color originalColor;
    public float colorChangeDuration = 0.5f; // Durasi warna berubah

    public GameObject[] Weapon;

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
        StartCoroutine(ChangeColorTemporarily());
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
