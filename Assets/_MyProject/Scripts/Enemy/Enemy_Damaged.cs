using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damaged : MonoBehaviour
{
    [SerializeField] protected int damage = 1;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player_Health>().TakeDamage(damage);
        }
    }
}
