using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score;
    

    [SerializeField] private GameObject fruit1;
    [SerializeField] private GameObject fruit2;
    [SerializeField] private GameObject fruit3;

    private void Awake()
    {
        score = 0;
        if (instance == null)
            instance = this;
        IsGameStartForTheFistTime();
    }
    void IsGameStartForTheFistTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartForTheFistTime"))
        {
            PlayerPrefs.SetInt("highscore1", 0);
            PlayerPrefs.SetInt("highscore2", 0);
            PlayerPrefs.SetInt("highscore3", 0);
            PlayerPrefs.SetInt("IsGameStartForTheFistTime", 0);
        }
    }

    /*private void Start()
    {
        if (!PlayerPrefs.HasKey("highscore1"))
        {
            PlayerPrefs.SetInt("highscore1", 0);
        }
        if (!PlayerPrefs.HasKey("highscore2"))
        {
            PlayerPrefs.SetInt("highscore2", 0);
        }
        if (!PlayerPrefs.HasKey("highscore3"))
        {
            PlayerPrefs.SetInt("highscore3", 0);
        }
    }*/
    private void Update()
    {
        CheckScore();
        HighScore();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Score")
        {
            score = Mathf.Clamp(score+=1, 0, 3);
        }
    }

    private void CheckScore()
    {
        switch (score)
        {
            case 0:
                fruit1.SetActive(false);
                fruit2.SetActive(false);
                fruit3.SetActive(false);
                return;
            case 1:
                fruit1.SetActive(true);
                return;
            case 2:
                fruit2.SetActive(true);
                return;
            case 3:
                fruit3.SetActive(true);
                return;
        }    
    }
    public void HighScore()
    {      
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            if (this.score > GetHighScore(1))
            {
                SetHighScore(1,this.score);
                Debug.Log("aaaaaaaaa");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (this.score > GetHighScore(2))
            {
                SetHighScore(2, this.score);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (this.score > GetHighScore(3))
            {
                SetHighScore(3, this.score);
            }
        }
    }
    public void SetHighScore(int index, int score)
    {
        PlayerPrefs.SetInt("highscore"+index, score);
    }
    public int GetHighScore(int index)
    {
        return PlayerPrefs.GetInt("highscore"+index);
    }
}
