using UnityEngine;
using TMPro;

public class GoldTextUI : MonoBehaviour
{
    [SerializeField]
    private PlayerData player;  // REPLACE WITH SCRIPTAVBLE OBJ
    private TextMeshProUGUI textMeshPro;
    private int gold;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        gold = player.GetGold();
        textMeshPro.text = $"{gold}";
    }

    // Update is called once per frame
    void Update()
    {
        if (gold != player.GetGold())
        {
            gold = player.GetGold();
            textMeshPro.text = $"{gold}";
        }
    }
}
