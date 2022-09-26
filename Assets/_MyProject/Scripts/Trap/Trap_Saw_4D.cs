using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw_4D : MonoBehaviour
{
    private bool _isPos1, _isPos2, _isPos3, _isPos4;
    [SerializeField] private float speed;
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private Transform pos3;
    [SerializeField] private Transform pos4;

    private Vector3 target;

    void Start()
    {
        _isPos1 = true;
        _isPos2 = false;
        _isPos3 = false;
        _isPos4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPos1)
        {
            target = pos1.position;
            if (Vector2.Distance(transform.position, pos1.position) < 0.1f)
            {
                _isPos1 = false;
                _isPos2 = true;
                _isPos3 = false;
                _isPos4 = false;

            }
        }
        else if (_isPos2)
        {
            target = pos2.position;
            if (Vector2.Distance(transform.position, pos2.position) < 0.1f)
            {
                _isPos1 = false;
                _isPos2 = false;
                _isPos3 = true;
                _isPos4 = false;

            }
        }
        else if (_isPos3)
        {
            target = pos3.position;
            if (Vector2.Distance(transform.position, pos3.position) < 0.1f)
            {
                _isPos1 = false;
                _isPos2 = false;
                _isPos3 = false;
                _isPos4 = true;

            }
        }
        else if (_isPos4)
        {
            target = pos4.position;
            if (Vector2.Distance(transform.position, pos4.position) < 0.1f)
            {
                _isPos1 = true;
                _isPos2 = false;
                _isPos3 = false;
                _isPos4 = false;

            }
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player_Health>().TakeDamage(damage);
        }
    }
}
