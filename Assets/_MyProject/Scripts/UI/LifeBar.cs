using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Player_Health playerhealth;
    [SerializeField] private Image currentLife;

    private void Update()
    {
        currentLife.fillAmount = playerhealth.currentLife / 10;
    }
}
