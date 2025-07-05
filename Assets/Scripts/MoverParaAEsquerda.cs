using UnityEngine;

public class MoverParaAEsquerda : MonoBehaviour
{

    public float velocidadeDoObjeto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarObjeto();
    }

    private void MovimentarObjeto()
    {
        transform.Translate(Vector3.down * velocidadeDoObjeto * Time.deltaTime);
    }
}
