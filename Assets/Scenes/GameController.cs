using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject _endGameMenu;
    public Text _player1;
    public Text _player2;
    public Text _victoryPlayer;
 
    void Start()
    {
        Time.timeScale = 1;
        _endGameMenu.SetActive(false);
    }

    public void GetNameForPlayers(string player1, string player2)
    {
        _player1.text = player1;
        _player2.text = player2;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);

    }

    public void EndGame(bool player1)
    {
        Time.timeScale = 0;
        _endGameMenu.SetActive(true);

        if (player1 == true)
            _victoryPlayer.text = "Victory: Player 1" /*+ _player1.text*/;
        else
            _victoryPlayer.text = "Victory: Player 2" /*+ _player2.text*/;

    }


    // Update is called once per frame
    void Update()
    {    
        
    }
}
