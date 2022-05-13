using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTower : MonoBehaviour
{
    void Update()
    {
        if (Enemy.Health <= 0)
        {
            SceneManager.LoadScene("losescene", LoadSceneMode.Single);
            Enemy.Health = 100;
            Spawner.waveIndex = 0;
        }
    }
}
