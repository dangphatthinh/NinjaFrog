using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_SpikeHead : MonoBehaviour
{   
    [Header("Movement parameters")]
    [SerializeField] private int speed;
    [SerializeField] private Transform upPos;
    [SerializeField] private Transform dowPos;
    private bool movingDown;

    private void Update()
    {
        if (movingDown)
        {
            if (transform.position.y >= dowPos.position.y)
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
        transform.position = new Vector3(transform.position.x , transform.position.y + Time.deltaTime * _direction * speed, transform.position.z);
    }
}
