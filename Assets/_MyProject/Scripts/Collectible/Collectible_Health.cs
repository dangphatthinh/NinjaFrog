using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Health : MonoBehaviour
{
    [SerializeField] private float healthValue;

    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundsManager.instance.PlaySound(pickupSound);
            collision.GetComponent<Player_Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
