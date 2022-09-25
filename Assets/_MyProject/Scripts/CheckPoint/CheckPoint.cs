using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Player_Health playerHealth;
    private UIManager uiManager;


    private void Awake()
    {
        playerHealth = GetComponent<Player_Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        if (playerHealth.currentLife == 0)
        {
            uiManager.GameOver();
        }
        else
        {
            playerHealth.Respawn(); //Restore player health and reset animation
            transform.position = currentCheckpoint.position; //Move player to checkpoint location      
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            currentCheckpoint = collision.transform;
            SoundsManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }
}
