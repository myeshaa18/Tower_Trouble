using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask towerLayer;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    private void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator is not assigned!");
        }
        if (attackPoint == null)
        {
            Debug.LogError("AttackPoint is not assigned!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    
    private void Attack()
    {
        if (animator != null && attackPoint != null)
        {
            animator.SetTrigger("Attack");
            AttackEnemies();
            AttackTower();
        }
        else
        {
            if (animator == null)
            {
                Debug.LogError("Animator reference is null!");
            }
            if (attackPoint == null)
            {
                Debug.LogError("AttackPoint reference is null!");
            }
        }
    }

    private void AttackEnemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            var enemyComponent = enemy.GetComponent<enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(attackDamage);
                Debug.Log("We hit " + enemy.name);
            }
            else
            {
                Debug.LogError("Enemy component not found on " + enemy.name);
            }
        }
    }

    private void AttackTower()
    {
        Collider2D[] hitTowers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, towerLayer);
        foreach (Collider2D tower in hitTowers)
        {
            var towerHealth = tower.GetComponent<TowerHealth>();
            if (towerHealth != null)
            {
                Debug.Log("Tower before damage: " + towerHealth.health);
                towerHealth.TakeDamage(attackDamage);
                Debug.Log("Tower after damage: " + towerHealth.health);
                Debug.Log("We hit the tower " + tower.name);
            }
            else
            {
                Debug.LogError("TowerHealth component not found on " + tower.name);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
