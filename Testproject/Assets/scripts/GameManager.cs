using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        movespeed = 5f;
        life = 3;
        instance = this;
    }

    public static GameManager instance
    {
        get;
        private set;
    }

    public Action<int> onChangeScore;
    public Action<int> onChangeLife;
    public Action onGameOver;
    public Action<int> onChangeCoin;
    public Action onGetShield;
    
    public float movespeed
    {
         set;
        get;
    }
    public int coins;
    private int score;
    public int life
    {
        private set;
        get;
    }

    public void addScore(int value = 100)
    {
        score += value;
        onChangeScore?.Invoke(score);

        if (maxScore < score)
        {
            maxScore = score;
        }
    }

    public void resetGame()
    {
        score = 0;
        onChangeScore = null;
        onGameOver = null;
    }

    public void reloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //scene-y reload a anum
        resetGame();
    }

    public void addDamage(int damage)
    {
        life -= damage;
        onChangeLife?.Invoke(life);

        if(life <= 0)
        {
            onGameOver?.Invoke();
            Invoke("reloadGame", 2f);
        }
    }

    public int maxScore
    {
        get => PlayerPrefs.GetInt("max_score", 0);
        set => PlayerPrefs.SetInt("max_score", value);

    }

    public void changeCoins(int coinValue)
    {
        coins += coinValue;
        onChangeCoin?.Invoke(coinValue);
        
        
        Coins += coinValue;
      
    }

    public int Coins
    {

        get => PlayerPrefs.GetInt("Coins", 0);
        set => PlayerPrefs.SetInt("Coins", value);

    }

    public void startShield()
    {

        onGetShield?.Invoke();
      
    }
  
}
