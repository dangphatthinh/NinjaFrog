using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Plant : MonoBehaviour
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
            }
        }
    }
    public void DestroyPlant()
    {
        Destroy(gameObject);
    }
}
