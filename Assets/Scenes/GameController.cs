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
        if(Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(_touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag.Equals("Restart"))
                {
                    Debug.Log("Starta Om");
                    SceneManager.LoadScene(0);
                }

            }

        }

    }

    public void VicToryPlayer(bool player1)
    {
        if (player1 == true)
            _victoryPlayer.text = "Victory: " + _player1.text;
        else
            _victoryPlayer.text = "Victory: " + _player2.text;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        _endGameMenu.SetActive(true);
        
    }


    // Update is called once per frame
    void Update()
    {
        RestartGame();
        
    }
}
