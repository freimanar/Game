using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonyUI : MonoBehaviour
{
    public Text moneyText;

    void Update()
    {
        moneyText.text = Stats.Money.ToString();// ����� ����� ����� �������� �����
    }

}