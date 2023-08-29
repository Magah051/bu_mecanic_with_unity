using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBu : MonoBehaviour
{
    private bool podeAndar;
    private VerificarDiecaoDoMovimentoDoJogador oVerificarDiecaoDoMovimentoDoJogador;


    private GameObject oJogador;
    [SerializeField] private float velocidadeDoInimigo;

    [SerializeField] private bool indoParaDireita;

    private void Awake()
    {
        oJogador = GameObject.FindGameObjectWithTag("Player");
        oVerificarDiecaoDoMovimentoDoJogador = oJogador.GetComponent<VerificarDiecaoDoMovimentoDoJogador>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
