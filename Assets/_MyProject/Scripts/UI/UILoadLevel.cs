using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoadLevel : MonoBehaviour
{
    public Animator fadeanimator;
    public Animator caroanimator;

    public void LoadLevel1()
    {
        
        LoadSceneFade(3);
    }
    public void LoadLevel2()
    {
        LoadSceneFade(4);
    }
    public void LoadLevel3()
    {
        LoadSceneFade(5);
    }
    public void ReturnMenu()
    {
        LoadSceneCaro(0);
    }
    public void LoadSceneFade(int _index)
    {
        StartCoroutine(FadeTransition(_index));
    }
    IEnumerator FadeTransition(int _levelindex)
    {
        fadeanimator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(_levelindex);
    }
    public void LoadSceneCaro(int _index)
    {
        StartCoroutine(CaroTransition(_index));
    }
    IEnumerator CaroTransition(int _levelindex)
    {
        caroanimator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(_levelindex);
    }
}
