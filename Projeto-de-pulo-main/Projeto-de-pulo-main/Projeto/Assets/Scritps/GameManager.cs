using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public TMP_Text pressioneEspaco;
    public TMP_Text titulo;
    public TMP_Text pressioneQualquerTecla;
    public TMP_Text credito;
    public TMP_Text melhorText;

    int melhorPontuacao;

    public Gerador gerador;
    public Player player;

    public Rigidbody2D playerRig;

    bool jogando = false;

    // Start is called before the first frame update
    void Start()
    {
        melhorPontuacao = PlayerPrefs.GetInt("melhorPontuacao");
        melhorText.text = "Melhor: " + melhorPontuacao;

        gameOverText.gameObject.SetActive(false);
        pressioneEspaco.gameObject.SetActive(false);

        titulo.gameObject.SetActive(true);
        credito.gameObject.SetActive(true);
        melhorText.gameObject.SetActive(true);
        pressioneQualquerTecla.gameObject.SetActive(true);
        playerRig.bodyType = RigidbodyType2D.Static;
    }

    void Inicia()
    {
        titulo.gameObject.SetActive(false);
        credito.gameObject.SetActive(false);
        melhorText.gameObject.SetActive(false);
        pressioneQualquerTecla.gameObject.SetActive(false);
        jogando = true;
        playerRig.bodyType = RigidbodyType2D.Dynamic;
        gerador.Iniciar();
    }

    
    void Update()
    {
        if (jogando == false)
        {
            if (Input.anyKeyDown)
            {
                Inicia();
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        playerRig.bodyType = RigidbodyType2D.Static;
        gameOverText.gameObject.SetActive(true);
        melhorText.gameObject.SetActive(true);
        pressioneEspaco.gameObject.SetActive(true);

        if (player.pontos > melhorPontuacao)
        {
            melhorPontuacao = player.pontos;
            melhorText.text = "Melhor: " + melhorPontuacao;
            PlayerPrefs.SetInt("melhorPontuacao", melhorPontuacao);
        }
    }
}
