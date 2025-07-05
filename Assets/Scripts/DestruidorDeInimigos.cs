using UnityEngine;

public class DestruidorDeInimigos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject);
        }
    }
}
