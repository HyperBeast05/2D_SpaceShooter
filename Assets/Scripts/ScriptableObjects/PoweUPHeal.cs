using UnityEngine;

public class PoweUPHeal : MonoBehaviour
{
    [SerializeField] private int powerUpHealth;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.AddHealth(powerUpHealth);
            AudioManager.instance.PlayPowerUp();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
