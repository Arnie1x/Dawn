using UnityEngine;
/// <summary>
/// This is a Base Class for all destructible objects in the game, including players and enemies
/// </summary>
public class DestructibleBase: MonoBehaviour
{
    [HideInInspector] public int Health { get; set; }
    private int _health;
    public bool invincible = false;

    public virtual void Start()
    {
        ResetHealth();
    }
    public virtual void TakeDamage(int dmg)
    {
        if (invincible) dmg = 0;

        _health -= dmg;
        if (_health <= 0) {
            _health = 0;
            Die();
        }
    }
    public void ResetHealth()
    {
        _health = Health;
    }
    public virtual void Die() {
        Debug.Log("Dead: " + gameObject.name, this);
    }
}