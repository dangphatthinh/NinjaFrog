using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; set; }

    [Header("Life")]
    [SerializeField] private float startingLife;
    public float currentLife { get; set; }

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Dead Sounds")]
    [SerializeField] private AudioClip deadSound;
    [SerializeField] private AudioClip hurtSound;

    //IFrames
    private float iFramesDuration = 1;
    private bool dead;

    private Animator animator;

    public static Player_Health instance;
  
    private void Awake()
    {
        currentLife = startingLife;
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        if (instance == null)
            instance = this;
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth += _value, 0, startingHealth);
    }

    public void AddLife(float _value)
    {
        currentLife = Mathf.Clamp(currentLife += _value, 0, 3);
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth -= _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            animator.SetTrigger("Hurt");
            SoundsManager.instance.PlaySound(hurtSound);
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                foreach (Behaviour com in components)
                {
                    com.enabled = false;
                }
                animator.SetTrigger("Die");
                SoundsManager.instance.PlaySound(deadSound);
                dead = true;
                currentLife -= 1;
            }
        }
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);        
        yield return new WaitForSeconds(iFramesDuration);       
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        animator.ResetTrigger("Die");
        animator.Play("Idle");
        StartCoroutine(Invunerability());

        foreach (Behaviour com in components)
        {
            com.enabled = true;
        }
    }
}
