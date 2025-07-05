using Unity.VisualScripting;
using UnityEngine;

public class LaserDoInimigo : MonoBehaviour
{
    public GameObject impactoDoLaserDoInimigo;

    private float velocidadeDoLaser = 14f;

    private float duracao = 2.5f;

    private int danoParaDar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, duracao);
    }

    // Update is called once per frame
    void Update()
    {
        MovimentacaoLaser();
    }

    private void MovimentacaoLaser()
    {
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DanoDoInimigo();
            other.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoParaDar);

            Instantiate(impactoDoLaserDoInimigo, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }

    private void DanoDoInimigo()
    {
        if (this.gameObject.name.Contains("Azul"))
        {
            danoParaDar = 1;
        }
        else
        {
            danoParaDar = 2;
        }
    }
}
 