using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour

{
    public Transform EnemyOrefab; //������� ������� ��� ������������
    public Transform spawnPoint;
    public float timeBetweerWaves = 15f; // ����� ����� ������� ���������� �������� ������ �������
    private float countdown = 1f;
    public static int waveIndex = 0;
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweerWaves;
        }
        countdown -= Time.deltaTime;// � ������ ������ ���������� ����� ����������
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
        { // ����� ������� ��������� ������� � ���� ����� ����������� ��� ���� ������
            i = Random.Range(1, 10);
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f); // ����� ������������ �����
        }   

    }

    void SpawnEnemy()
    {
        Instantiate(EnemyOrefab, spawnPoint.position, spawnPoint.rotation); // �������� ������� �� �����
    }

}