using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Acid : MonoBehaviour {
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Dead", true);
        }

        if (collision.gameObject.tag == "FallingPlatform")
        {
            Destroy(collision.gameObject);
        }
    }
}
