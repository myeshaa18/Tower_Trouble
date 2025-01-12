using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator; // Reference to the Animator component

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>(); // Initialize the animator
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt"); // Play hurt animation
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        animator.SetBool("IsDead", true); // Play die animation
        this.enabled = false; // Disable enemy script
        GetComponent<Collider2D>().enabled = false; // Disable enemy collider
    }
}
