using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform_UD : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField] private int speed;
    [SerializeField] private Transform upPos;
    [SerializeField] private Transform downPos;
    private bool movingDown;
    private float spikeHead;

    private void Awake()
    {
        spikeHead = transform.position.y;
    }
    private void Update()
    {
        if (movingDown)
        {
            if (transform.position.y >= downPos.position.y)
            {
                MoveInDirection(-1);
            }
            else
            {
                movingDown = !movingDown;
            }
        }
        else
        {
            if (transform.position.y <= upPos.position.y)
            {
                MoveInDirection(1);
            }
            else
            {
                movingDown = !movingDown;
            }
        }
    }
    private void MoveInDirection(int _direction)
    {
        //Move in that direction
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * _direction * speed, transform.position.z);
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
