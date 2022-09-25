using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bee : MonoBehaviour
{
    [SerializeField] private float atackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;

    private Animator animator;
    private float cooldownTimer;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Atack()
    {
        cooldownTimer = 0;
        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjecttile();
        animator.SetTrigger("Atack");
    }
    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= atackCooldown)
        {
            Atack();
        }
    }
}
