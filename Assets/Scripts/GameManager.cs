using UnityEngine;
using TMPro; // Asegúrate de tener instalado TextMeshPro
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Ajustes de Juego")]
    public float tiempoDeVida = 60f; // Tiempo inicial en segundos
    public int bateriasNecesarias = 5;
    public int bateriasActuales = 0;

    [Header("UI")]
    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoTiempo;
    public GameObject panelVictoria;
    public GameObject panelDerrota;

    private bool juegoTerminado = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (juegoTerminado) return;

        // La vida se acaba con el tiempo
        tiempoDeVida -= Time.deltaTime;
        
        // Actualizar UI
        textoTiempo.text = "Oxígeno: " + Mathf.Ceil(tiempoDeVida).ToString();
        textoContador.text = "Baterías: " + bateriasActuales + " / " + bateriasNecesarias;

        if (tiempoDeVida <= 0)
        {
            GameOver();
        }
    }

    public void RecogerBateria()
    {
        bateriasActuales++;
        // Opcional: Recoger batería te da un poco de tiempo extra
        tiempoDeVida += 10f; 
    }

    public void ComprobarVictoria()
    {
        if (bateriasActuales >= bateriasNecesarias)
        {
            Ganar();
        }
        else
        {
            Debug.Log("Faltan baterías para arrancar la nave");
        }
    }

    void Ganar()
    {
        juegoTerminado = true;
        panelVictoria.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
    }

    void GameOver()
    {
        juegoTerminado = true;
        panelDerrota.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}