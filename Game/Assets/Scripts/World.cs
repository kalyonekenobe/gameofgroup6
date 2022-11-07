using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> waves;
    private int index = 0;
    private bool needToWait = true;
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

    // Start is called before the first frame update
    void Start()
    {

       for (int i = 0; i < waves.Count; i++)
        {
            if(waves[i] != null)
                waves[i].GetComponent<Wave>().world = this;        
        }

        if(waves.Count > 0)
            waves[0].GetComponent<Wave>().enabled = true;
    }

}
