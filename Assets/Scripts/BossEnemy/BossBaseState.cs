using System.Collections;
using UnityEngine;

public class BossBaseState : MonoBehaviour
{
   protected Camera mainCam;
   protected float maxLeft, maxRight, maxTop, maxBottom;
    [SerializeField] protected BossController bossController;

    private void OnEnable()
    {
        mainCam = Camera.main;
    }
    protected virtual void Start()
    {
        StartCoroutine(nameof(SetCamBoundaries));
    }

    IEnumerator SetCamBoundaries()
    {
        yield return new WaitForSeconds(.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(.3f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(.8f, 0)).x;

        maxTop = mainCam.ViewportToWorldPoint(new Vector2(0, .9f)).y;
        maxBottom = mainCam.ViewportToWorldPoint(new Vector2(0, .6f)).y;
    }

    public virtual void RunState()
    {

    }
    public virtual void StopState()
    {
        StopAllCoroutines();
    }
  

}
