using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{
    private Slider barraDeVidaDoJogador;

    private Slider barraDeEnergiaDoEscudo;
    public GameObject escudoDoJogador;

    public GameObject efeitoDeExplosao;

    private int vidaMaximaDoJogador = 15;
    public int vidaAtualDoJogador;

    public int vidaMaximaDoEscudo = 5;
    public int vidaAtualDoEscudo;

    public bool temEscudo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        barraDeVidaDoJogador = GameObject.Find("Barra de Vida do Jogador").GetComponent<Slider>();
        barraDeVidaDoJogador.maxValue = vidaMaximaDoJogador;
        barraDeVidaDoJogador.value = vidaAtualDoJogador;

        barraDeEnergiaDoEscudo = GameObject.Find("Barra de Energia do Escudo").GetComponent<Slider>();
        barraDeEnergiaDoEscudo.maxValue = vidaMaximaDoEscudo;
        barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

        barraDeEnergiaDoEscudo.gameObject.SetActive(false);

        escudoDoJogador = GameObject.Find("Escudo do Jogador");
        escudoDoJogador.SetActive(false);
        temEscudo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarEscudo()
    {
        barraDeEnergiaDoEscudo.gameObject.SetActive(true);

        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

        escudoDoJogador.SetActive(true);

        temEscudo = true;
    }

    public void GanharVida(int vidaParaReceber)
    {
        if ((vidaAtualDoJogador + vidaParaReceber) <= vidaMaximaDoJogador)
        {
            vidaAtualDoJogador += vidaParaReceber;
        }

        else
        {
            vidaAtualDoJogador = vidaMaximaDoJogador;
        }

        barraDeVidaDoJogador.value = vidaAtualDoJogador;
    }

    public void MachucarJogador(int danoParaReceber)
    {
        if (temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;

            barraDeVidaDoJogador.value = vidaAtualDoJogador;

            if (vidaAtualDoJogador <= 0)
            {
                Debug.Log("Game Over");

                Instantiate(efeitoDeExplosao, transform.position, transform.rotation);

                EfeitosSonoros.instance.somDaExplosao.Play();

                Destroy(this.gameObject);

                GameManager.instance.GameOver();
            }
        }

        else
        {
            vidaAtualDoEscudo -= danoParaReceber;
            barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

            if (vidaAtualDoEscudo <= 0)
            {
                escudoDoJogador.SetActive(false);

                temEscudo = false;

                barraDeEnergiaDoEscudo.gameObject.SetActive(false);
            }
        }
    }

}
