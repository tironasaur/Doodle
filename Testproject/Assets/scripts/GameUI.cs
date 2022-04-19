using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text coinsText;
    public int coins;

    [SerializeField] GameObject uiobject;
    [SerializeField] Text distancemoved;
    [SerializeField] Text MaxScore;

    [SerializeField] GameObject[] lifes;

    private void Start()
    {
        uiobject.SetActive(false);
        showLife(GameManager.instance.life);

        GameManager.instance.onChangeScore += showScore;
        GameManager.instance.onGameOver += showGameOver;
        GameManager.instance.onChangeLife += showLife;
        GameManager.instance.onChangeCoin += showCoins;
        coins = PlayerPrefs.GetInt("Coins");
    }

    private void OnDestroy()
    {
        GameManager.instance.onChangeScore -= showScore;
        GameManager.instance.onGameOver -= showGameOver;
        GameManager.instance.onChangeLife -= showLife;
    }

    public void showLife(int life)
    {
        
            for(int i = 0; i < lifes.Length; i++)
            {
                lifes[i].SetActive(i < life);
            }  

    }

    private void showScore(int score)
    {
        distancemoved.text = "Score: " + score;
        MaxScore.text = "MaxScore: " + PlayerPrefs.GetInt("max_score");
    }
        
    private void showGameOver()
    {
        uiobject.SetActive(true);
        distancemoved.text = "";
    }

    public void showCoins(int coinValue)
    {
        coins += coinValue;
        coinsText.text = "coins: " +  coins.ToString();
    }
    //public int Coins
    //{

    //    get => PlayerPrefs.GetInt("Coins", 10);
    //    set => PlayerPrefs.SetInt("Coins", 15);

    //}

}
