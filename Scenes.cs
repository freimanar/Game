using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
        Spawner.waveIndex = 0;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
