using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBu : MonoBehaviour
{
    [Header("Verificação do Andar")]
    private bool podeAndar;
    private VerificarDiecaoDoMovimentoDoJogador oVerificarDiecaoDoMovimentoDoJogador;

    [Header("Movimento do Inimigo")]
    [SerializeField] private float velocidadeDoInimigo;
    [SerializeField] private bool indoParaDireita;
    private GameObject oJogador;

    private void Awake()
    {
        oJogador = GameObject.FindGameObjectWithTag("Player");
        oVerificarDiecaoDoMovimentoDoJogador = oJogador.GetComponent<VerificarDiecaoDoMovimentoDoJogador>();
    }

    private void Start()
    {
        podeAndar = true;
    }

    private void Update()
    {
        VerificarSePodeAndar();
        SeguirJogador();
        EspelharNaHorizontal();
    }

    private void VerificarSePodeAndar()
    {
        if (indoParaDireita)
        {
            if (oVerificarDiecaoDoMovimentoDoJogador.indoParaDireita)
            {
                podeAndar = true;
            }else
            {
                podeAndar = false;
            }
        }
        else
        {
            if (oVerificarDiecaoDoMovimentoDoJogador.indoParaDireita)
            {
                podeAndar = false;
            }
            else
            {
                podeAndar = true;
            }
        }
    }

    private void SeguirJogador()
    {
        if (podeAndar)
        {
            transform.position = Vector2.MoveTowards(transform.position, oJogador.transform.position, velocidadeDoInimigo * Time.deltaTime);
        }
    }

    private void EspelharNaHorizontal()
    {
        if (oJogador.transform.position.x > transform.position.x)
        {
            indoParaDireita = true;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            indoParaDireita = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
