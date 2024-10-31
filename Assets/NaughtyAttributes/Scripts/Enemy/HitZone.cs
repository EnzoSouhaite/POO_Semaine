using UnityEngine;

public class HitZone : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Damage();
        }
    }

    public void Damage()
    {
        Debug.Log("Damage called, dealing: " + _damage);
        _health.TakeDamage(_damage);
        Debug.Log("Joueur a reçu des dégâts : " + _damage);
    }
}
