using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool ismovingLeft;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    private void Update()
    {
        Moving();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player_Health>().TakeDamage(damage);
        }
    }
    private void Moving()
    {
        if (ismovingLeft)
        {
            if (transform.position.x > leftEdge.position.x)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

            }
            else
            {
                ismovingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge.position.x)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

            }
            else
            {
                ismovingLeft = true;
            }
        }
    }
}
