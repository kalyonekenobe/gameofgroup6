using UnityEngine;

public class WMController : MonoBehaviour
{
    [SerializeField]
    private double livingTime = 5;
    [SerializeField]
    private double hitTime = 0.3;
    [SerializeField]
    private Animator animator;
    private double currentLife;
    private double currentHit;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private bool isInitialized;
    private int power = 1;

    public void Initialize()
    {
        currentLife = livingTime;
        currentHit = 0;
        isInitialized = true;
    }

    public void SetPower(int power)
    {
        this.power = power;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInitialized)
        {
            return;
        }
        currentLife -= Time.deltaTime;
        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (currentHit <= 0)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (collision.gameObject.GetComponent<Enemy>().IsAlive())
                {
                    collision.gameObject.GetComponent<Enemy>().Hit(power);
                }
            }
            currentHit = hitTime;
        }
        else
        {
            currentHit -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentHit = 0;
    }
}
