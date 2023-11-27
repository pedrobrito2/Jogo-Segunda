using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameManager gameManager;
    public Transform playerTransform;


    void Update()
    {
        if (playerTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(0, playerTransform.position.y, -10);
        }

        if (playerTransform.position.y < transform.position.y - 6)
        {
            // Game Over
            gameManager.GameOver();
        }
    }
}

