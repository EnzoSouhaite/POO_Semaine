using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damageAmount = 20;
    public Transform playerTransform;
    public Animator animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attacking");

        RaycastHit hit;
        Vector3 rayDirection = playerTransform.forward;

        if (Physics.Raycast(playerTransform.position, rayDirection, out hit, 5f))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
                Debug.Log("Ennemi touché, dégâts infligés !");
            }
        }
        else
        {
            Debug.Log("Pas d'ennemi détecté par le Raycast");
        }

        Debug.DrawRay(playerTransform.position, rayDirection * 5f, Color.red, 1f);
    }
}
