using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{

    private bool powerUpEscudo;

    private bool powerUpLaserDuplo;

    private bool powerUpVida;

    private int vidaGanha = 5;

    private float duracao;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objetoPowerUp();

        Destroy(this.gameObject, duracao);
    }

    private void objetoPowerUp()
    {
        if (this.gameObject.name.Contains("Power-Up de Escudo"))
        {
            powerUpEscudo = true;

            duracao = 6f;
        }

        if (this.gameObject.name.Contains("Power-Up de Laser"))
        {
            powerUpLaserDuplo = true;

            duracao = 6f;
        }

        if (this.gameObject.name.Contains("Power-Up de Vida"))
        {
            powerUpVida = true;

            duracao = 6f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (powerUpEscudo == true)
            {
                other.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();
            }

            if (powerUpLaserDuplo == true)
            {
                other.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = false;
                other.gameObject.GetComponent<ControleDoJogador>().tempoAtualLaserDuplo = other.gameObject.GetComponent<ControleDoJogador>().tempoMaximoLaserDuplo;
                other.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = true;
            }

            if (powerUpVida == true)
            {
                other.gameObject.GetComponent<VidaDoJogador>().GanharVida(vidaGanha);

            }

            Destroy(this.gameObject);
        }
    }
    
}
