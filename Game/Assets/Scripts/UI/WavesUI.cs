using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    private World world;
    private int counter = 0;
    private int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        maxValue = world.GetWavesCount();
        slider.maxValue = maxValue;
        slider.value = 0;
        textMeshPro.text = $"{counter}/{maxValue}";
    }

    // Update is called once per frame
    void Update()
    {
        if (counter != world.GetIndex())
        {
            counter = world.GetIndex();
            slider.value = counter;
            textMeshPro.text = $"{counter}/{maxValue}";
        }
    }
}
