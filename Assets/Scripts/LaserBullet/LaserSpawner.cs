using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] private Transform baseShootPoint;

    [Header("SpawnPoints")]
    [SerializeField] private Transform leftShootPoint;
    [SerializeField] private Transform leftShootPoint1;
    [SerializeField] private Transform rightShootPoint;
    [SerializeField] private Transform rightShootPoint1;

    [Header("SpawnRotationPoints")]
    [SerializeField] private Transform leftRotationPoint;
    [SerializeField] private Transform rightRotationPoint;

    [SerializeField] private float spawnTime;
    [SerializeField] private float timer;

    int upgradeShootPoint;

    private void Awake()
    {
    }
    void Start()
    {
        EndGameManager.instance.RegisterLaserSpawner(this);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnLaser();
            timer = 0;
        }
    }

    public void IncreaseUpgradeShootPoint()
    {
        upgradeShootPoint++;
        if (upgradeShootPoint >= 4)
            upgradeShootPoint = 4;
    }


    public void DecreaseUpgradeShootPoint()
    {
        upgradeShootPoint--;
        if (upgradeShootPoint <= 0)
            upgradeShootPoint = 0;
    }

    private void ShootLaser(Transform spawnPos)
    {
        //if (spawnPos == null) return;
        GameObject laser = LaserObjPool.instance.GetLaser();
        laser.SetActive(true);
        if (laser != null)
        {
            laser.transform.SetPositionAndRotation(spawnPos.position, Quaternion.identity);
        }
    }

    private void SpawnLaser()
    {
        AudioManager.instance.PlayLaser();
        switch (upgradeShootPoint)
        {
            case 0:
                ShootLaser(baseShootPoint);
                break;
            case 1:
                ShootLaser(leftShootPoint);
                ShootLaser(rightShootPoint);
                break;
            case 2:
                ShootLaser(baseShootPoint);
                ShootLaser(leftShootPoint);
                ShootLaser(rightShootPoint);
                break;
            case 3:
                ShootLaser(baseShootPoint);
                ShootLaser(leftShootPoint);
                ShootLaser(rightShootPoint);
                ShootLaser(leftShootPoint1);
                ShootLaser(rightShootPoint1);
                break;
            case 4:
                ShootLaser(baseShootPoint);
                ShootLaser(leftShootPoint);
                ShootLaser(rightShootPoint);
                ShootLaser(leftShootPoint1);
                ShootLaser(rightShootPoint1);
                ShootLaser(leftRotationPoint);
                ShootLaser(rightRotationPoint);
                break;
            default: break;
        }
    }
}
