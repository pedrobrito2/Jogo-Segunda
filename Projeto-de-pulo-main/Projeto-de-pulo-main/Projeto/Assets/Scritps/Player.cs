using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rig;
    public float jumpForce;
    public float speed;

    public TMP_Text pontuacaoText;
    public int pontos = 0;

    void Update()
    {
        if (rig.bodyType == RigidbodyType2D.Static)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(x * speed, rig.velocity.y);

        if (transform.position.x < -3)
        {
            transform.position += Vector3.right * 6;
        }
        else if (transform.position.x > 3)
        {
            transform.position += Vector3.left * 6;
        }

        if (transform.position.y > pontos)
        {
            pontos = (int)transform.position.y;
            pontuacaoText.text = "Pontos: " + pontos.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //colidiu com a plataforma
        {
            if (rig.velocity.y < 0)
            {
                rig.velocity = new Vector2(0, jumpForce);
            }
        }

        if (collision.gameObject.layer == 7) //colidiu com a mosca
        {
            gameManager.GameOver();
        }
    }
}