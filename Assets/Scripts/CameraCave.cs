using UnityEngine;
using System.Collections;

public class CameraCave : MonoBehaviour
{
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        minX = -2.49f;
        minY = 0.12f;
        maxX = 40.5f;
        maxY = 23.03f;
    }

    void LateUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        if (posX < minX)
            posX = minX;

        if (posY < minY)
            posY = minY;

        if (posX > maxX)
            posX = maxX;

        if (posY > maxY)
            posY = maxY;

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}