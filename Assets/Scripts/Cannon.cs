using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Cannon : MonoBehaviour {
	public GameObject bulletPrefab;
	public float timer;
    public GameObject player;
    public AudioSource song;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        song = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (player.transform.position.y >= transform.position.y - 6 && player.transform.position.y < transform.position.y + 6)
        {
            if (timer > 2)
            {
                song.Play();
                GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                timer = 0;
            }
        }
    }
}
