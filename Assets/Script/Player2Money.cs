﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Money : MonoBehaviour
{

    public GameObject GlobalVariable;

    public Text MoneyText;

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "Money : " + GlobalVariable.GetComponent<GlobalVariable>().Player2Money.ToString() + " K";
    }
}
