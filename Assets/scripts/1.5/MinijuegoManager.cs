using UnityEngine;
using UnityEngine.SceneManagement;

public class MinijuegoManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject prefabGuardian;
    public GameObject prefabID;
    public float tiempoParaID = 15f;
    public float intervaloSpawn = 1f;

    private float cronometro = 0f;
    private bool idSoltada = false;

    void Start()
    {
        Time.timeScale = 1f; // Nos aseguramos de que el tiempo corra
        InvokeRepeating("SpawnGuardian", 0.5f, intervaloSpawn);
    }

    void Update()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= tiempoParaID && !idSoltada)
        {
            idSoltada = true;
            CancelInvoke("SpawnGuardian");
            SpawnID();
        }
    }

    void SpawnGuardian()
    {
        // Ajusta el -2f, 2f según el ancho de tu recuadro blanco
        Vector3 pos = new Vector3(Random.Range(-2f, 2f), 6f, 0f);
        Instantiate(prefabGuardian, pos, Quaternion.identity);
    }

    void SpawnID()
    {
        Vector3 pos = new Vector3(Random.Range(-2f, 2f), 6f, 0f);
        Instantiate(prefabID, pos, Quaternion.identity);
    }

    public void Perder()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f; // Congela el juego al perder
    }

    public void Ganar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EscenaMansionTrasera"); // Asegúrate de que el nombre sea exacto
    }

    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}