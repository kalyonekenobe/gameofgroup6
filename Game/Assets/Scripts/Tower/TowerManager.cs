using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public GameObject currentTower;
    private GameObject towerAButton;
    private GameObject towerBButton;

    public void Start()
    {
        towerAButton = GameObject.Find("ButtonTowerA");
        towerBButton = GameObject.Find("ButtonTowerB");
        SelectTowerByName(currentTower.name);
    }


    public void SelectTower(GameObject newTower)
    {
        //метод що спрацьовує при натисканні на кнопку,і присвоює новий префаб для башти
        this.currentTower = newTower;
        SelectTowerByName(currentTower.name);
    }

    private void SelectTowerByName(string towerName)
    {
        if (currentTower.name == "Tower A")
        {
            towerAButton.GetComponent<Image>().color = new Color32(125, 170, 200, 255);
            towerBButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (currentTower.name == "Tower B")
        {
            towerAButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            towerBButton.GetComponent<Image>().color = new Color32(125, 170, 200, 255);
        }
    }
  
}
