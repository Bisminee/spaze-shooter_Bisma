using UnityEngine;

public class HealthEntity : MonoBehaviour, IProperty
{
    public float health = 100;
    public float Health { get => health; set => health = Mathf.Max(value, 0); }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
