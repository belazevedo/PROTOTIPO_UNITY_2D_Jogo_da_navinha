using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject painelDeGameOver;

    public TextMeshProUGUI textoDePontuacaoAtual;
    public TextMeshProUGUI textoDePontuacaoFinal;
    public TextMeshProUGUI textoDeHighScore;

    public AudioSource musicaDeFundo;
    public AudioSource musicaDeGameOver;

    public int pontuacaoAtual;


    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;

        musicaDeFundo.Play();

        pontuacaoAtual = 0;
        textoDePontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PontuacaoDoJogo(int pontosParaGanhar)
    {
        pontuacaoAtual += pontosParaGanhar;
        textoDePontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }


    public void GameOver()
    {
        Time.timeScale = 0f;

        musicaDeFundo.Stop();
        musicaDeGameOver.Play();

        painelDeGameOver.SetActive(true);
        textoDePontuacaoFinal.text = "PONTUAÇÃO: " + pontuacaoAtual;

        if (pontuacaoAtual > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", pontuacaoAtual);
        }

        textoDeHighScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");
    } 
}
