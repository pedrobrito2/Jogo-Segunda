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

    public float superJumpForce; //super pulo da maça
    bool estaNoSuperPulo = false; //esta no super pulo e esta imortal
    public float tempoDoSuperPulo;
    private float tempoAtualDoSuperPulo = 0f;

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

        if (tempoAtualDoSuperPulo < tempoDoSuperPulo)
        {
            tempoAtualDoSuperPulo += Time.deltaTime;
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
            if (tempoAtualDoSuperPulo < tempoDoSuperPulo)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                gameManager.GameOver();
            }
        }

        if (collision.gameObject.layer == 8) //colidiu com a maça
        {
            tempoAtualDoSuperPulo = 0f;
            estaNoSuperPulo = true;
            rig.velocity = new Vector2(0, superJumpForce);
            Destroy(collision.gameObject);
        }
    }
}