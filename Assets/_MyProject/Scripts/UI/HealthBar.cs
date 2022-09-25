using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player_Health playerhealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealth;

    private void Start()
    {
        totalHealth.fillAmount = playerhealth.currentHealth / 10;
    }
    private void Update()
    {
        currentHealth.fillAmount = playerhealth.currentHealth / 10;
    }
}
