using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartSceneButtons : MonoBehaviour
{
    public Button playGameButton;
    public Button exitGameButton;
  



    // Update is called once per frame
    void Start()
    {
        playGameButton.onClick.AddListener(startGame);
        exitGameButton.onClick.AddListener(exitGame);

   
    }


    void startGame()
    {
        SceneManager.LoadScene("GameScene");

    }


    void exitGame()
    {
        Application.Quit();
    }
}
