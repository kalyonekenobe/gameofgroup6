using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private PlayerData player;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = player.GetHealth();
        slider.maxValue = player.GetMaxHealth();
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health != player.GetHealth())
        {
            health = player.GetHealth();
            slider.value = health;
        }
    }
}
