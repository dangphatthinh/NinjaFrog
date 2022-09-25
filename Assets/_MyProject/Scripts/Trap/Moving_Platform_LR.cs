using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform_LR : MonoBehaviour
{
    [SerializeField] private float speed;

    private bool ismovingLeft;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    private void Update()
    {
        Moving();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
