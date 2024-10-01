using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource laser, Explosion, PowerUP;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayLaser()
    {
        //if (laser.isPlaying) return;
        laser.Play();
    }

    public void PlayExplosion()
    {
        Explosion.Play();
    }
    public void PlayPowerUp()
    {
        //if (PowerUP.isPlaying) return;
        PowerUP.Play();
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
