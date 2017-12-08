using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float velUp;
    public float velDown;
    public float vel;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

	public bool elevator;
    void Start()
    {
        maxX = 109.28f;
        maxY = 62.11f;

        minX = -2.6f;
        minY = 0.3f;

        player = GameObject.FindGameObjectWithTag("Player");
        offset = 2f;
        velUp = 1.5f;
        velDown = -4.5f;
        vel = 4.5f;
    }

    void Update()
    {
        if (transform.position.x > maxX)
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);

        if (transform.position.y > maxY)
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);

        if (player.transform.position.x < maxX)
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);


        if (transform.position.x < minX)
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);

        if (transform.position.y < minY)
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);

		if (elevator == false) {
			if (player.transform.position.x > minX && player.transform.position.x < maxX)
				transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);

			if (player.transform.position.y > transform.position.y + offset)
				transform.Translate (0, vel * Time.deltaTime, 0);

			if (player.transform.position.y < transform.position.y - offset && transform.position.y > minY)
				transform.Translate (0, -vel * Time.deltaTime * 15, 0);
		}

		if (elevator == true) {
			transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
		}
    }
}