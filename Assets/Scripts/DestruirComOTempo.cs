using UnityEngine;

public class DestruirComOTempo : MonoBehaviour
{
    public float duracao;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, duracao);
    }
}
