using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatermelonController : MonoBehaviour
{
    [SerializeField]
    private double cooldown = 20;
    private double currentTime;

    [SerializeField]
    private Button button;
    [SerializeField]
    private GameObject waterMelon;

    private bool placeRain = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = cooldown;
        button.enabled = true;
        button.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (placeRain)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceMelonor();
                button.enabled = false;
                placeRain = false;
            }
        }
        else
        {
            if (currentTime <= 0)
            {
                button.enabled = true;
                button.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }
    }

    public void ActivateRain()
    {
        placeRain = true;
        button.enabled = false;
        button.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        currentTime = cooldown;
    }

    private void PlaceMelonor()
    {
        Vector3 objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objPos.z = 1;
        Instantiate(waterMelon, objPos, Quaternion.identity);
    }
}
