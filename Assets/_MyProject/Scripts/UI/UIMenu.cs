using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public Animator fadeanimator;
    public Animator caroanimator;
    public Animator close;
    [SerializeField] private GameObject settingScreen;

    public void LoadGame()
    {
        LoadSceneCaro(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        settingScreen.SetActive(true);
    }
    public void Close()
    {
        StartCoroutine(CloseSetting());
    }
    public void ReturnAbout()
    {
        LoadSceneCaro(0);
    }
    public void About()
    {
        LoadSceneCaro(1);
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
    IEnumerator CloseSetting()
    {
        close.SetTrigger("Closed");
        yield return new WaitForSeconds(1);
        settingScreen.SetActive(false);
    }
}
