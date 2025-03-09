using UnityEngine;

public class BulletEffector : MonoBehaviour
{
    public float damage = 10;

    private void ImposeDamage(Transform transform)
    {
        IProperty target = transform.GetComponent<IProperty>();
        if (target != null)
        {
            target.Health -= damage;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ImposeDamage(collision.transform);
        Destroy(gameObject);
    }
}
