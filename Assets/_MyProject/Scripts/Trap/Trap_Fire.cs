using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Fire : MonoBehaviour
{
    [SerializeField] private int damage;

    [Header("FireTrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    [Header("SFX")]
    [SerializeField] private AudioClip fireSound;

    private Animator animator;
    private Player_Health player;

    private bool triggered; // when the trap gets triggered
    private bool active; // when the trap active and can hurt player

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (active && player != null)
            player.TakeDamage(damage);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFireTrap());

            player = collision.GetComponent<Player_Health>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player = null;
    }
    private IEnumerator ActivateFireTrap()
    {
        //turn the sprite to red to notify the player and trigger the trap
        triggered = true;
        animator.SetTrigger("Trigger");

        //wait for delay, activate trap, turn on animation, return the color back to normal
        yield return new WaitForSeconds(activationDelay);
        active = true;
        animator.SetBool("Activated", true);
        SoundsManager.instance.PlaySound(fireSound);

        //wait for activationDelay time and turn off the trap
        yield return new WaitForSeconds(activeTime);
        triggered = false;
        active = false;
        animator.SetBool("Activated", false);
    }
}
