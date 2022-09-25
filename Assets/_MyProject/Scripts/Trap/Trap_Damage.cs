using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Damage : MonoBehaviour
{
    [SerializeField] protected int damage = 1;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Health>().TakeDamage(damage);
        }
    }
}
