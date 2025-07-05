using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{

    private Rigidbody2D oRigidBody2D;

    private Vector2 teclasApertadas;

    private GameObject laserDoJogador;

    private Transform localDoDisparoUnico;

    private Transform localDoDisparoDaEsquerda;

    private Transform localDoDisparoDaDireita;

    public float tempoMaximoLaserDuplo = 10f;

    public float tempoAtualLaserDuplo;

    private float velocidadedaNave = 10f;

    public bool temLaserDuplo;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oRigidBody2D = GetComponent<Rigidbody2D>();

        laserDoJogador = Resources.Load<GameObject>("Laser do Jogador");

        localDoDisparoUnico = GameObject.Find("Local do Disparo Único").GetComponent<Transform>();

        localDoDisparoDaEsquerda = GameObject.Find("Local do Disparo da Esquerda").GetComponent<Transform>();

        localDoDisparoDaDireita = GameObject.Find("Local do Disparo da Direita").GetComponent<Transform>();

        temLaserDuplo = false;

        tempoAtualLaserDuplo = tempoMaximoLaserDuplo;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentacaoJogador();

        AtirarLaser();

        if (temLaserDuplo == true)
        {
            tempoAtualLaserDuplo -= Time.deltaTime;

            if (tempoAtualLaserDuplo <= 0)
            {
                DesativarLaserDuplo();
            }
        }
    }

    private void MovimentacaoJogador()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        oRigidBody2D.linearVelocity = teclasApertadas.normalized * velocidadedaNave;
    }

    private void AtirarLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            EfeitosSonoros.instance.somDoLaserDoJogador.Play();
            
            if (temLaserDuplo == false)
            {
                Instantiate(laserDoJogador, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            }

            else
            {
                Instantiate(laserDoJogador, localDoDisparoDaEsquerda.position, localDoDisparoDaEsquerda.rotation);
                Instantiate(laserDoJogador, localDoDisparoDaDireita.position, localDoDisparoDaDireita.rotation);
            }
        }
    }

    public void DesativarLaserDuplo()
    {
        temLaserDuplo = false;

        tempoAtualLaserDuplo = tempoMaximoLaserDuplo;
    }

}
