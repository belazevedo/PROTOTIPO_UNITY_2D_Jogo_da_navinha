using UnityEngine;

public class LaserdoJogador : MonoBehaviour
{

    public GameObject impactoDoLaserDoJogador;

    private float velocidadeDoLaser = 13f;

    private float duracao = 2.5f;

    private int danoParaDar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, duracao);

        danoParaDar = 1;
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            other.gameObject.GetComponent<Inimigos>().MachucarInimigo(danoParaDar);

            Instantiate(impactoDoLaserDoJogador, transform.position, transform.rotation);

            EfeitosSonoros.instance.somDeImpacto.Play();

            Destroy(this.gameObject);
        }
    }
    
}
