using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GeradorDeObjetos : MonoBehaviour
{

    public GameObject[] objetosParaSpawnar;

    public Transform[] pontosDeSpawn;

    public float tempoMaximoEntreSpawn;

    public float tempoAtualEntreSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoAtualEntreSpawn = tempoMaximoEntreSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtualEntreSpawn -= Time.deltaTime;

        if (tempoAtualEntreSpawn <= 0)
        {
            SpawnarObjeto();
        }
    }

    private void SpawnarObjeto()
    {

        int objetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
        int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);

        Instantiate(objetosParaSpawnar[objetoAleatorio], pontosDeSpawn[pontoAleatorio].position, Quaternion.Euler(0f, 0f, -90f));

        tempoAtualEntreSpawn = tempoMaximoEntreSpawn;
    }
    
}
