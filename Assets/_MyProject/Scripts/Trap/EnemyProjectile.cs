using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    [SerializeField] private int damage;
    private float lifeTime;

    private bool hit;
    private BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjecttile()
    {
        hit = false;
        lifeTime = 0;
        gameObject.SetActive(true);
        box.enabled = true;
    }
    private void Update()
    {
        if (hit) return;
        transform.Translate(speed * Time.deltaTime, 0, 0);
        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            hit = true;
            collision.GetComponent<Player_Health>().TakeDamage(damage);
            box.enabled = false;
            gameObject.SetActive(false);
        }
        else if(collision.tag == "Wall"||collision.tag == "Ground")
        {
            hit = true;
            box.enabled = false;
            gameObject.SetActive(false);
        }       
    }
}
