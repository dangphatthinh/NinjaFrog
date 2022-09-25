using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private Animator animator;
    public static bool isWin;
    [Header("SFX")]
    [SerializeField] private AudioClip winSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isWin = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("Win");
            isWin = true;
            SoundsManager.instance.PlaySound(winSound);
        }
    }
}
