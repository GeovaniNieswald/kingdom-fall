﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColectorItens : MonoBehaviour
{
    
    public int points;

    public Text pointsText;

    void Update() {

    pointsText.text = "Pontos: " + points;    
    
    }




}