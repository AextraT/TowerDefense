﻿using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 200;

    private void Start()
    {
        money = startMoney;
    }
}
