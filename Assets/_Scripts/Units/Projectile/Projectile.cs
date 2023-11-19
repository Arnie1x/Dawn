using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public int damage;
    // [HideInInspector] public TrailRenderer trailRenderer;

    // [SerializeField] private ParticleSystem impactEffect;
    private GameObject impact;
    bool projectileReturned = false;

    // Instead of using a trail, use a normal particle system
    //public TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // impactEffect.Clear();
        //rb.velocity = transform.right * speed;
    }
    private void OnEnable()
    {
        // CancelInvoke();
        // Invoke(nameof(ReturnProjectile), 5);
        projectileReturned = false;

    }

    private void OnTriggerEnter(Collider collision)
    {
        // impactEffect.Play();
        // impact = Instantiate(impactEffect.gameObject, transform.position, transform.rotation);
        Destroy(impact);
        DestructibleBase destructible = collision.gameObject.GetComponent<DestructibleBase>();
        if (destructible != null)
        {
            destructible.TakeDamage(damage);
        }
        Destroy(gameObject, 0.1f);
        // ReturnProjectile();

    }

    // void ReturnProjectile()
    // {
    //     if (projectileReturned) return;
    //     enemy.Release(this);
    //     projectileReturned = true;
    // }
}