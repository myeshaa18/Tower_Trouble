using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
        Debug.Log("Player died");
        animator.SetBool("IsDead", true); // Play die animation
        this.enabled = false; // Disable player script
        GetComponent<Collider2D>().enabled = false; // Disable player collider
    }
}
