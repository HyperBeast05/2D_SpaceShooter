using UnityEngine;

public class PlayerShieldActivator : MonoBehaviour
{
   [SerializeField] Shield shield;
    void Start()
    {
        
    }

    public void ShieldActivate()
    {
        if (!shield.gameObject.activeSelf)
        {
            shield.gameObject.SetActive(true);
        }
        else
        {
            shield.RepairShield();
        }
    }

    void Update()
    {
        
    }
}
