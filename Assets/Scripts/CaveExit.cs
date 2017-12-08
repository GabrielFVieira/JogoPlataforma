using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveExit : MonoBehaviour {
    public GameManager manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Game");
            manager.cavePass = 1;
            manager.Save();
        }
    }
}
