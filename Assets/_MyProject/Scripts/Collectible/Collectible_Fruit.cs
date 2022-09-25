using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Fruit : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip scoreSound;
    private Animator animator;
    private BoxCollider2D box;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("Collected");
            SoundsManager.instance.PlaySound(scoreSound);
            box.enabled = false;
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
