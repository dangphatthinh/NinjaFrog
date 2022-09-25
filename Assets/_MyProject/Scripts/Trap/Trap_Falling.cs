using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Falling : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float falldistance;
    private bool isTrigger;
    private Vector3 pos;
    private Animator animator;

    private void Awake()
    {
        this.pos = transform.position;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(isTrigger)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * speed);
            float distance = Vector3.Distance(pos, transform.position);
            if (distance < falldistance) return;
            isTrigger = false;
            transform.position = this.pos;
            animator.SetBool("Fall", false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
            animator.SetBool("Fall", true);
        }
    }
}
