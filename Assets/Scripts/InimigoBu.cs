using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBu : MonoBehaviour
{

    private GameObject oJogador;
    [SerializeField] private float velocidadeDoInimigo;

    [SerializeField] private bool indoParaDireita;

    private void Awake()
    {
        oJogador = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SeguirJogador();
    }

    private void SeguirJogador()
    {
        transform.position = Vector2.MoveTowards(transform.position, oJogador.transform.position, velocidadeDoInimigo * Time.deltaTime);
    }
}
