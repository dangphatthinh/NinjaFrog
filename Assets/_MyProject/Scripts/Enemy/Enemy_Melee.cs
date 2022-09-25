using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee : MonoBehaviour
{
    [Header("Atack Parameter")]
    [SerializeField] private float atackCoolDown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameter")]
    [SerializeField] private float colliderDistance;  
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Atack Sounds")]
    [SerializeField] private AudioClip atackSound;

    //references
    private Player_Health playerHealth;
    private Animator animator;
    private Enemy_Patrol enemyPatrol;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<Enemy_Patrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Atack only when see player
        if (PlayerInsight())
        {
            if(cooldownTimer >= atackCoolDown && playerHealth.currentHealth > 0)
            {
                cooldownTimer = 0;
                animator.SetBool("Moving", false);
                animator.SetTrigger("Atack");
                SoundsManager.instance.PlaySound(atackSound);
            }
        }  
        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInsight();
        }
    }
    private bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right*range * transform.localScale.x*colliderDistance,
           new Vector3(boxCollider.bounds.size.x*range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
           0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Player_Health>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+transform.right * range * transform.localScale.x*colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if (PlayerInsight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
