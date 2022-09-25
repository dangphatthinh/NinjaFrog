using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FatChicken : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private float checkTimer;
    private Vector3 destination;
    [SerializeField] private Vector3 originalPos;
    private bool _isStop;

    private Animator animator;

    private bool atacking;

    [Header("SFX")]
    [SerializeField] private AudioClip impactSound;

    private Vector3[] direction = new Vector3[4];
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Stop();
    }
    private void Start()
    {
        originalPos = transform.position;
    }
    private void Update()
    {
        if (atacking)
        {
            transform.Translate(destination * Time.deltaTime * speed);
            animator.SetTrigger("Fall");
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }
        if (_isStop)
        {
            Invoke("Return", 1);
        }
    }
    private void CheckForPlayer()
    {
        CalculateDirection();
        for (int i = 0; i < direction.Length; i++)
        {
            Debug.DrawRay(transform.position, direction[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction[i], range, playerLayer);

            if (hit.collider != null && !atacking)
            {
                atacking = true;
                destination = direction[i];
                checkTimer = 0;
            }
        }

    }
    private void CalculateDirection()
    {
        //direction[0] = transform.right * range;
        //direction[1] = -transform.right * range;
        //direction[2] = transform.up * range;
        direction[3] = -transform.up * range;
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Health>().TakeDamage(1);
            Stop();
            SoundsManager.instance.PlaySound(impactSound);
        }
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Enemy"))
        {
            Stop();
            SoundsManager.instance.PlaySound(impactSound);
        }
    }

    private void Stop()
    {
        destination = transform.position; // set the destinaton as current position so it doesn't move
        atacking = false;
        _isStop = true;
        animator.SetTrigger("Ground");
    }
    private void Return()
    {
        float distance = Vector2.Distance(transform.position, originalPos);
        transform.Translate(transform.up * distance * Time.deltaTime * speed);
        _isStop = false;
    }
}
