using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILeaderBoard : MonoBehaviour
{
    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;
    public int indexpanel;
    private void Update()
    {
        ShowPanel();
    }
    public void ShowPanel()
    {
        switch (Score.instance.GetHighScore(this.indexpanel))
        {
            case 0:
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
                return;
            case 1:
                star1.SetActive(true);               
                return;
            case 2:
                star1.SetActive(true);
                star2.SetActive(true);
                return;
            case 3:
                star3.SetActive(true);
                star1.SetActive(true);
                star2.SetActive(true);
                return;
        }

    }
}
