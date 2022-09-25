using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Destroy : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D box;
    private bool isDie;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isDie)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
                animator.SetTrigger("Die");
                box.enabled = false;
                isDie = true;
                gameObject.GetComponent<Enemy_Patrol>().DestroyComponent();
            }        
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
