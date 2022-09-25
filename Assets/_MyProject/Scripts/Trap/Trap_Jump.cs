using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }
}
