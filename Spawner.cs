using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour

{
    public Transform EnemyOrefab; //образец объекта для клонирования
    public Transform spawnPoint;
    public float timeBetweerWaves = 15f; // время через которое произойдет создание нового объекта
    private float countdown = 1f;
    public static int waveIndex = 0;
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweerWaves;
        }
        countdown -= Time.deltaTime;// с каждым кадром переменная будет уменьшатся
        if (Input.GetKey(KeyCode.O))
        {
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
        if (waveIndex == 11)
        {
            SceneManager.LoadScene("winscene", LoadSceneMode.Single);
            waveIndex= 0;
            Enemy.Health = 100;
        }
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKey(KeyCode.I))
        {
            Time.timeScale = 1;
        }

    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < 10; i++)
        { // после каждого появления объекта к нему будет добавляться еще один объект
            i = Random.Range(1, 10);
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f); // через определенное время
        }   

    }

    void SpawnEnemy()
    {
        Instantiate(EnemyOrefab, spawnPoint.position, spawnPoint.rotation); // создание объекта на сцене
    }

}