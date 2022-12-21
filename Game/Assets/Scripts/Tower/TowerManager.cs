using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public GameObject CurrentTower;
    public GameObject towerText;
    
 
    public void SelectTower(GameObject NewTower)
    {
        //метод що спрацьовує при натисканні на кнопку,і присвоює новий префаб для башти
        this.CurrentTower = NewTower;
      towerText.GetComponent<TextMeshProUGUI>().text = CurrentTower.name+  " chosen";


    }
  
}
