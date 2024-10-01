using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitsToDestroy;
    public bool protection;

    [SerializeField] private GameObject[] shieldIcons;

    private void OnEnable()
    {
        hitsToDestroy = 3;
        protection = true;
        foreach (GameObject item in shieldIcons)
        {
            item.SetActive(true);
        }
    }

    public void DamageShield()
    {
        hitsToDestroy--;
        if (hitsToDestroy <= 0)
        {
            hitsToDestroy = 0;
            protection = false;
            gameObject.SetActive(false);
        }
        UpdateShieldUI();
    }


    private void UpdateShieldUI()
    {
        switch (hitsToDestroy)
        {
            case 0:
                foreach (GameObject item in shieldIcons)
                    item.SetActive(false);
                break;
            case 1:
                shieldIcons[0].SetActive(true);
                shieldIcons[1].SetActive(false);
                shieldIcons[2].SetActive(false);
                break;
            case 2:
                shieldIcons[0].SetActive(true);
                shieldIcons[1].SetActive(true);
                shieldIcons[2].SetActive(false);
                break;
            case 3:
                foreach (GameObject item in shieldIcons)
                    item.SetActive(true);
                break;
            default: break;
        }
    }

    public void RepairShield()
    {
        hitsToDestroy = 3;
        UpdateShieldUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (collision.CompareTag("Boss"))
            {
                hitsToDestroy = 0;
                DamageShield();
                return;
            }
            enemy.TakeDamage(10000);
            DamageShield();
        }
        else
        {
            collision.gameObject.SetActive(false);
            DamageShield();
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
