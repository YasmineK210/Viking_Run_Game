using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coin;
    public static GameManager inst;
    public bool isGameOver;

    //public Text gameOverText;

    public Text coinText;
    public Text gameOverText;

    public void setGameOver() {
        isGameOver = true;
        gameOverText.enabled = true;
    }

    public void incrementScore() {
        coin++;
        coinText.text = "Coins: " + coin;
    }
    // Start is called before the first frame update
    void Awake()
    {
        inst = this;
    }
    void Start()
    {
        coin = 0;
        isGameOver = false;
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
