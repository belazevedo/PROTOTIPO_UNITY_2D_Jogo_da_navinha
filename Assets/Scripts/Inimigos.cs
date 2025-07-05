using System.Diagnostics.Tracing;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inimigos : MonoBehaviour
{
    private GameObject laserDoInimigo;

    private Transform localDoDisparo;

    public GameObject itemParaDropar;

    public GameObject efeitoDeExplosao;


    private float velocidadeDoInimigo;

    private float tempoMaximoEntreDisparos;

    private float tempoAtualEntreDisparos;


    private int vidaMaximaDoInimigo;

    private int vidaAtualDoInimigo;

    public int pontosParaDar;

    public int chanceParaDropar;

    private int danoDaNave;


    public bool inimigoAtivado;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inimigoAtivado = false;

        Inimigo();

        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentacaoInimigo();

        if (inimigoAtivado == true)
        {
            AtaqueDoInimigo();
        }
    }

    public void AtivarInimigo()
    {
        inimigoAtivado = true;
    }

    private void MovimentacaoInimigo()
    {
        transform.Translate(Vector3.down * velocidadeDoInimigo * Time.deltaTime);
    }

    public void Inimigo()
    {
        if (this.gameObject.name.Contains("Inimigo Azul"))
        {
            laserDoInimigo = Resources.Load<GameObject>("Laser do Inimigo Azul");
            tempoMaximoEntreDisparos = 0.5f;
            localDoDisparo = transform.Find("Local do Disparo Azul").GetComponent<Transform>();
            velocidadeDoInimigo = 9.5f;
            vidaMaximaDoInimigo = 4;
            pontosParaDar = 10;
            danoDaNave = 2;
        }

        else if (this.gameObject.name.Contains("Inimigo Verde"))
        {
            laserDoInimigo = Resources.Load<GameObject>("Laser do Inimigo Verde");
            tempoMaximoEntreDisparos = 0.75f;
            localDoDisparo = transform.Find("Local do Disparo Verde").GetComponent<Transform>();
            velocidadeDoInimigo = 8f;
            vidaMaximaDoInimigo = 3;
            pontosParaDar = 15;
            danoDaNave = 1;
        }

        else
        {
            laserDoInimigo = null;
            velocidadeDoInimigo = 11.5f;
            vidaMaximaDoInimigo = 1;
            pontosParaDar = 5;
            danoDaNave = 4;
        }
    }

    private void AtaqueDoInimigo()
    {
        tempoAtualEntreDisparos -= Time.deltaTime;

        if ((tempoAtualEntreDisparos <= 0) && (laserDoInimigo != null))
        {
            Instantiate(laserDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));

            tempoAtualEntreDisparos = tempoMaximoEntreDisparos;
        }
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

        if (vidaAtualDoInimigo <= 0)
        {
            GameManager.instance.PontuacaoDoJogo(pontosParaDar);

            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);

            EfeitosSonoros.instance.somDaExplosao.Play();

            int numeroAleatorio = Random.Range(0, 100);

            if (numeroAleatorio <= chanceParaDropar)
            {
                Instantiate(itemParaDropar, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }

            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoDaNave);

            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);

            EfeitosSonoros.instance.somDaExplosao.Play();

            Destroy(this.gameObject);
        }
    }

}
