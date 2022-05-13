using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Wave : MonoBehaviour
{
    public Text waveText;
    void Update()
    {
        waveText.text = Spawner.waveIndex.ToString();// текст будет равен значению денег
    }
}