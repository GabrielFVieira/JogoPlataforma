using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

[RequireComponent(typeof(AudioSource))]
public class PickUpPowerUps : MonoBehaviour {

    public AudioSource songBlue;
    public AudioSource songGreen;
    public AudioSource songRed;
    public AudioSource songYellow;

    public bool controle = true;

    public GameManager manager;

    public int lado;
    // Use this for initialization
    void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lado = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x > 0)
            lado = 1;
        else
            lado = -1;

        //Check if the power up is activated and ativate it
        if (manager.BluePowerUpActivated == true)
        {
            GetComponent<PlatformerCharacter2D>().m_JumpForce = 800f;
            manager.timerBlue += Time.deltaTime;
        }

        if(manager.GreenPowerUpActivated == true)
        {
            if (controle == true)
            {
                transform.localScale = new Vector3(0.9f * lado, 0.9f, 1);
                controle = false;
            }
                manager.timerGreen += Time.deltaTime;
        }

        if(manager.RedPowerUpActivated == true)
        {
            manager.timerRed += Time.deltaTime;
        }

        if(manager.YellowPowerUpActivated == true)
        {
            GetComponent<PlatformerCharacter2D>().m_MaxSpeed = 8;
            manager.timerYellow += Time.deltaTime;
        }

        //Desactivate each power up
        if(manager.timerBlue > manager.PowerUpMaxTime)
        {
            manager.BluePowerUpActivated = false;
            GetComponent<PlatformerCharacter2D>().m_JumpForce = 650f;
            manager.timerBlue = 0;
        }

        if (manager.timerGreen > manager.PowerUpMaxTime)
        {
            manager.GreenPowerUpActivated = false;
            transform.localScale = new Vector3(1.771533f, 01.771533f, 1);
            controle = true;
            manager.timerGreen = 0;
        }

        if (manager.timerRed > manager.PowerUpMaxTime)
        {
            manager.RedPowerUpActivated = false;
            manager.timerRed = 0;
        }

        if (manager.timerYellow > manager.PowerUpMaxTime)
        {
            manager.YellowPowerUpActivated = false;
            GetComponent<PlatformerCharacter2D>().m_MaxSpeed = 6;
            manager.timerYellow = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "BluePowerUp")
        {
            songBlue.Play();
            manager.BluePowerUpActivated = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "GreenPowerUp")
        {
            songGreen.Play();
            manager.GreenPowerUpActivated = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "RedPowerUp")
        {
            songRed.Play();
            manager.RedPowerUpActivated = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "YellowPowerUp")
        {
            songYellow.Play();
            manager.YellowPowerUpActivated = true;
            Destroy(col.gameObject);
        }
    }
}
