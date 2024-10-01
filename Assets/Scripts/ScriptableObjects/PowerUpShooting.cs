using UnityEngine;

public class PowerUpShooting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LaserSpawner>(out LaserSpawner spawner))
        {
            spawner.IncreaseUpgradeShootPoint();
            AudioManager.instance.PlayPowerUp();
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
