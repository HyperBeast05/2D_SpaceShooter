using UnityEngine;

public class PowerUpShield : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerShieldActivator>(out PlayerShieldActivator shieldActivator))
        {
            shieldActivator.ShieldActivate();
            AudioManager.instance.PlayPowerUp();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
