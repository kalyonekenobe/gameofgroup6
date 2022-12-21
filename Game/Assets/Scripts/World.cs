using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> waves;

    private int index = 0;
    private bool isInvasionOver = false;
    private bool isInvasionStarted = false;
    public void OnDestroyWave()
    {
        Debug.Log("OnDestroyWave");
        index++;
        if (waves.Count > index)
        {
            waves[index].GetComponent<Wave>().enabled = true;
            if (index == waves.Count - 1)
                waves[index].GetComponent<Wave>().isLastWave = true;
        }


    }

    public int GetIndex()
    {
        return index;
    }

    public int GetWavesCount()
    {
        return waves.Count;
    }

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i] != null)
                waves[i].GetComponent<Wave>().world = this;
        }
    }

    public bool IsInvasionOver()
    {
        return isInvasionOver;
    }

    public void Update()
    {
        if(!isInvasionStarted)
        {
            isInvasionStarted = true;
            if (waves.Count > 0)
                waves[0].GetComponent<Wave>().enabled = true;
        }

        if (index < waves.Count)
        {
            Wave wave = waves[index].GetComponent<Wave>();
            if (wave.isLastWave && wave.IsEnemiesDestroyed())
            {
                index++;
                isInvasionOver = true;
            }
        }
    }

}
