using UnityEngine;
using NaughtyAttributes;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;

    [SerializeField, Tooltip("La santé actuelle de l'ennemi (lecture seule)")]
    [ReadOnly] private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("L'ennemi a subi " + damage + " points de dégâts.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("L'ennemi est mort !");
        Destroy(gameObject);
    }
}
