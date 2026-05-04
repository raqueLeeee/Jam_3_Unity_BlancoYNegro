using UnityEngine;
using UnityEngine.SceneManagement;

public class MinijuegoManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject prefabGuardian;
    public GameObject prefabID;
    public float tiempoParaID;
    public float intervaloSpawn;

    private float cronometro = 0f;
    private bool idSoltada = false;

    void Start()
    {
        Time.timeScale = 1f; //tiempo
        InvokeRepeating("SpawnGuardian", 1f, intervaloSpawn);//a xsegundos suelta guardianes
    }

    void Update()
    {
        cronometro += Time.deltaTime;//tiempo sumadoe real
        if (cronometro >= tiempoParaID && !idSoltada)//paso el tiempo sufieciente pues suelta la id
        {
            idSoltada = true;
            CancelInvoke("SpawnGuardian");
            SpawnID();
        }
    }

    void SpawnGuardian()
    {
        //caer
        Vector3 pos = new Vector3(Random.Range(-8f, 11f), 6f, 0f);//punto al azaer
        Instantiate(prefabGuardian, pos, Quaternion.identity);//clon
    }

    void SpawnID()
    {
        Vector3 pos = new Vector3(Random.Range(-7f, 9f), 6f, 0f);
        Instantiate(prefabID, pos, Quaternion.identity);
    }

    //SCRIPT DEL GUARDIAN E ID dentro de este q esta dentro del gameobject de minijuego idk

    public void Perder()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f; //Congela el juego al perder
    }

    public void Ganar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EscenaMansionTrasera"); //parte de atras de la mansión
    }

    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}