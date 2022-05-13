using UnityEngine;
using System.Collections;
public class Stats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    void Start()
    {
        Money = startMoney;
    }
}