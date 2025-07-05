using UnityEngine;

public class EfeitosSonoros : MonoBehaviour
{
    public static EfeitosSonoros instance;

    public AudioSource somDaExplosao, somDoLaserDoJogador, somDeImpacto;

    void Awake()
    {
        instance = this;
    }

}
