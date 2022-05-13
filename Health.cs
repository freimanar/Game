using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    public Text healthText;

    void Update()
    {
        healthText.text = Enemy.Health.ToString();
    }

}