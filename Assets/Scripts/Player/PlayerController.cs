using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerController : MonoBehaviour
{
    Camera mainCam;
    Vector3 offSet;

    float maxLeft, maxRight, maxTop, maxBottom;
    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(nameof(SetCamBoundaries));
    }

    IEnumerator SetCamBoundaries()
    {
        yield return new WaitForSeconds(.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(.1f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(.9f, 0)).x;

        maxTop = mainCam.ViewportToWorldPoint(new Vector2(0, .95f)).y;
        maxBottom = mainCam.ViewportToWorldPoint(new Vector2(0, .05f)).y;
    }

    void Update()
    {
        if (Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;
            touchPos = mainCam.ScreenToWorldPoint(touchPos);

            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                offSet = touchPos - transform.position;
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                transform.position = new Vector2(touchPos.x - offSet.x, touchPos.y - offSet.y);
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
            {
                transform.position = new Vector2(touchPos.x - offSet.x, touchPos.y - offSet.y);
            }

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, maxLeft, maxRight),
                                            Mathf.Clamp(transform.position.y, maxBottom, maxTop));

        }
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
}
