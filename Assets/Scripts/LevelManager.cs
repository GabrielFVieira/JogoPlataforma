using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager game;

    public GameObject elevator;
    public GameObject player;

    public GameObject bluePowerUp;
    public GameObject greenPowerUp;
    public GameObject redPowerUp;
    public GameObject yellowPowerUp;
    // Use this for initialization
    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<GameManager>();

        player = GameObject.FindGameObjectWithTag("Player");

        if (game.cavePass == 0)
            elevator.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            game.BluePowerUpActivated = game.GreenPowerUpActivated = game.RedPowerUpActivated = game.YellowPowerUpActivated = false;
            game.timerBlue = game.timerGreen = game.timerRed = game.timerYellow = 0;
            game.cavePass = 0;
            game.Save();
            SceneManager.LoadScene("Game");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            game.BluePowerUpActivated = game.GreenPowerUpActivated = game.RedPowerUpActivated = game.YellowPowerUpActivated = false;
            game.timerBlue = game.timerGreen = game.timerRed = game.timerYellow = 0;
            SceneManager.LoadScene("Menu");
        }

        if (game.cavePass == 1 && Application.loadedLevelName == "Game" && game.controle == true)
        {
            elevator.SetActive(true);
            player.transform.position = new Vector3(61.9f, -8.01f, 0);
            game.controle = false;
        }

            bluePowerUp.SetActive(game.BluePowerUpActivated);
            bluePowerUp.GetComponentInChildren<Text>().text = (Mathf.RoundToInt(game.PowerUpMaxTime - game.timerBlue) + " Segs");

            greenPowerUp.SetActive(game.GreenPowerUpActivated);
            greenPowerUp.GetComponentInChildren<Text>().text = (Mathf.RoundToInt(game.PowerUpMaxTime - game.timerGreen) + " Segs");

            redPowerUp.SetActive(game.RedPowerUpActivated);
            redPowerUp.GetComponentInChildren<Text>().text = (Mathf.RoundToInt(game.PowerUpMaxTime - game.timerRed) + " Segs");

            yellowPowerUp.SetActive(game.YellowPowerUpActivated);
            yellowPowerUp.GetComponentInChildren<Text>().text = (Mathf.RoundToInt(game.PowerUpMaxTime - game.timerYellow) + " Segs");
    }
}