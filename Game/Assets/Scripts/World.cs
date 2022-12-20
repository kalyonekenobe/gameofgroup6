using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> waves;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    private int index = 0;
    private bool isInvasionOver = false;
    public void OnDestroyWave()
    {
        Debug.Log("OnDestroyWave");
        index++;
        slider.value = index;
        textMeshPro.text = $"{index}/{waves.Count}";
        if (waves.Count > index)
        {
            waves[index].GetComponent<Wave>().enabled = true;
            if (index == waves.Count - 1)
                waves[index].GetComponent<Wave>().isLastWave = true;
        }


    }

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i] != null)
                waves[i].GetComponent<Wave>().world = this;
        }

        if (waves.Count > 0)
            waves[0].GetComponent<Wave>().enabled = true;

        slider.maxValue = waves.Count;
        slider.value = 0;
        textMeshPro.text = $"{index}/{waves.Count}";
    }

    public bool IsInvasionOver()
    {
        return isInvasionOver;
    }

    public void Update()
    {
        Wave wave = waves[index].GetComponent<Wave>();
        if (wave.isLastWave && wave.IsEnemiesDestroyed())
        {
            isInvasionOver = true;
        }
    }

}
