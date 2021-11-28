using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;
    void Start()
    {
        FindObjectOfType<PlayerMovement>().OnPlayerDeath += OnGameOver;//Subscribing the OnGameOver method to OnPlayerDeath event.
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);                
            }
        }
    }
    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();//Time.timeSinceLevelLoad -: 0 from time survived when a scene is loaded again.
        gameOver = true;        
    }
}
