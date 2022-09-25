using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject settingScreen;
    [SerializeField] private UIMenu ui;

    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;

    [SerializeField] private GameObject bronze;
    [SerializeField] private GameObject silver;
    [SerializeField] private GameObject gold;

    [SerializeField] public ParticleSystem hanabi;

    public static bool isPauseGame;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        ui = GetComponent<UIMenu>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauseGame)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
        if (End.isWin)
            Win();
    }
    public void Setting()
    {
        pauseScreen.SetActive(false);
        settingScreen.SetActive(true);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundsManager.instance.PlaySound(gameOverSound);
    }
    public void Win()
    {
        winScreen.SetActive(true);
        switch (Score.instance.score)
        {
            case 0:
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
                return;
            case 1:
                star1.SetActive(true);
                bronze.SetActive(true);
                return;
            case 2:
                star1.SetActive(true);
                star2.SetActive(true);
                silver.SetActive(true);
                return;
            case 3:
                star3.SetActive(true);
                star1.SetActive(true);
                star2.SetActive(true);
                gold.SetActive(true);
                return;
        }
        Confeti();
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        isPauseGame = false;
        End.isWin = false;
        ui.LoadSceneFade(0);

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        ui.LoadSceneFade(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        isPauseGame = true;
    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        isPauseGame = false;
    }
    public void RetryGame()
    {
        Score.instance.score = 0;
        Time.timeScale = 1f;
        isPauseGame = false;
        End.isWin = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.instance.PlaySounds("Theme");
    }
    public void Confeti()
    {
        hanabi.Play();
    }
}
