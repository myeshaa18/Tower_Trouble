using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float attackRange = 1.5f;
    public Animator animator;

    void Update()
    {
        // Check the distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Trigger attack animation if the player is within attack range
        if (distanceToPlayer <= attackRange)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the attack range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
