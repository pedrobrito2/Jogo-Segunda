using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosca : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float deslocamento;
    public float speed;

    float limiteDireita;
    float limiteEsquerda;

    bool indoParaDireita = true;

    private void Start()
    {
        limiteDireita = transform.position.x + deslocamento;
        limiteEsquerda = transform.position.x - deslocamento;
    }

    void Update()
    {
        if (indoParaDireita)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x > limiteDireita) //chegou no limite da direita
            {
                indoParaDireita = false;
                sprite.flipX = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x < limiteEsquerda) //chegou no limite da esquerda
            {
                indoParaDireita = true;
                sprite.flipX = true;
            }
        }
    }
}
