using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject modeloPlataforma;
    public GameObject modeloMosca;
    public GameObject modeloApple;

    public Transform cameraTransform;

    public List<Transform> plataformas;

    float distancia = 1;
    float chanceDeTerMosca = 5;
    float chanceDeTerApple = 2;
    float chanceDeTerPlataformaQueCai = 5;

    public void Iniciar()
    {
        for (int i = 0; i < 12; i++)
        {
            GerarPlataforma();
        }
    }

    void GerarPlataforma()
    {
        var x = Random.Range(-2.2f, 2.2f);
        var y = plataformas.Last().position.y + 1;
        distancia += 0.01f;
        if (distancia > 3f)
        {
            distancia = 3f;
        }
        var transformPlataforma = Instantiate(modeloPlataforma, new Vector3(x, y), Quaternion.identity).transform;
        plataformas.Add(transformPlataforma);

        float valorSorteado = Random.Range(0f, 100f);
        if (valorSorteado < chanceDeTerMosca)
        {
            Instantiate(modeloMosca, transformPlataforma.position + Vector3.up * 0.7f, Quaternion.identity);
            chanceDeTerMosca += 5;
            if (chanceDeTerMosca > 50)
            {
                chanceDeTerMosca = 50;
            }
        }

        float valorSorteadoApple = Random.Range(0f, 100f);
        if (valorSorteadoApple < chanceDeTerApple)
        {
            Instantiate(modeloApple, transformPlataforma.position + Vector3.up * 0.7f, Quaternion.identity);
            chanceDeTerApple += 2;
            if (chanceDeTerApple > 20)
            {
                chanceDeTerApple = 20;
            }
        }

        float valorPlataformaQueCai = Random.Range(0f, 100f);
        if (valorPlataformaQueCai < chanceDeTerPlataformaQueCai)
        {
            Instantiate(modeloApple, transformPlataforma.position + Vector3.up * 0.7f, Quaternion.identity);
            chanceDeTerPlataformaQueCai += 5;
            if (chanceDeTerPlataformaQueCai > 15)
            {
                chanceDeTerPlataformaQueCai = 15;
            }
        }
    }

    void Update()
    {
        var primeira = plataformas.First();
        if (primeira.position.y < cameraTransform.position.y - 6)
        {
            plataformas.RemoveAt(0);
            Destroy(primeira.gameObject);
            GerarPlataforma();
        }
    }
}
