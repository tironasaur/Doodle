using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    bool isDragging, isMobilePlatform;
    Vector2 TapPoint, swipeDelta;
    float minSwipeDelta = 15; //inchqan qashes matov vor sksi swipey

    public enum SwipeType
    {
        LEFT,
        RIGHT
    }

    public delegate void OnSwipeInput(SwipeType type);
    public static event OnSwipeInput SwipeEvent;

    private void Awake()
    {
        isMobilePlatform = Application.isMobilePlatform;
    }

     private void Update()
    {
        if (!isMobilePlatform)
        {
            if (Input.GetMouseButtonDown(0))
            {

                isDragging = true;
                TapPoint = Input.mousePosition;

            }
            else if (Input.GetMouseButtonUp(0)) ;
               //ResetSwipe();

        }
        else
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                TapPoint = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended) ;

                //ResetSwipe();
        }
        CalculateSwipe(); 
    }

    void CalculateSwipe()
    {
        swipeDelta = Vector2.zero;
        
        if(isDragging)
        {
            if (!isMobilePlatform && Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - TapPoint;
            }
            else if (Input.touchCount > 0)
            {
                swipeDelta = Input.touches[0].position - TapPoint;
            }
        }

        if (swipeDelta.magnitude > minSwipeDelta)
        {
            if (SwipeEvent != null)
            {
                SwipeEvent(swipeDelta.x < 0 ? SwipeType.LEFT : SwipeType.RIGHT);
            }
           // ResetSwipe();  // esi avelacnelov stex qo dragy kdarna swipe, u el ches kara sxmac pahac qashes aj u dzax
        }
    }

    private void ResetSwipe()
    {
        isDragging = false;
        TapPoint = swipeDelta = Vector2.zero;
    }
}
