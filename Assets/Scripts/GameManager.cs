using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int cavePass;
    public bool controle;

    public GameObject warning;

    public bool BluePowerUpActivated;
    public bool GreenPowerUpActivated;
    public bool RedPowerUpActivated;
    public bool YellowPowerUpActivated;

    public float timerBlue;
    public float timerGreen;
    public float timerRed;
    public float timerYellow;

    public float PowerUpMaxTime;


    // Use this for initialization
    void Start () {
        instance = this;
        DontDestroyOnLoad(gameObject);

        controle = true;

        PowerUpMaxTime = 60;

        if (PlayerPrefs.HasKey("CavePassed"))
        {
            //We had a previopus session ( Ja jogou antes )
            cavePass = PlayerPrefs.GetInt("CavePassed");
        }

        else
            Save();
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            cavePass = 0;
            Save();
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerPrefs.SetInt("CavePassed", 0);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitWarning();
            }

            if (Input.GetKeyDown(KeyCode.Return) && warning.activeSelf == false || Input.GetKeyDown(KeyCode.Space) && warning.activeSelf == false)
            {
                StartGame();
            }

            if (Input.GetKeyDown(KeyCode.Return) && warning.activeSelf == true)
            {
                Exit();
            }

            Cursor.visible = true;
        }
        else
            Cursor.visible = false;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CavePassed", cavePass);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitWarning()
    {
        warning.SetActive(!warning.activeSelf);
    }
}
