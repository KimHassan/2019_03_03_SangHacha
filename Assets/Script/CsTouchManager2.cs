using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsTouchManager2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    public GameObject Ltruck;

    public GameObject Rtruck;

    Vector2 firstFingerPostion;

    Vector2 lastFingerPosition;

    float angle;

    float swipeDistanceX;
    float swipeDistanceY;

    float SWIPE_DISTANCE_X_CONST = 60;
    float SWIPT_DISTANCE_Y_CONST = 150;

    int touchFingerId = -1;

    private void Start()
    {
        
    }

    private void Update()
    {
        #if (UNITY_EDITOR || UNITY_STANDALONE)
        {
            MouseUpdate();
        }
        #elif (UNITY_ANDROID)
        {
        TouchUpdate();
        }
        #endif
    }
    private void MouseUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            firstFingerPostion = Input.mousePosition;
            lastFingerPosition = Input.mousePosition;

        }
        if(Input.GetMouseButton(0))
        {
            
            lastFingerPosition = Input.mousePosition;
            swipeDistanceX = Mathf.Abs((lastFingerPosition.x - firstFingerPostion.x));
            swipeDistanceY = Mathf.Abs((lastFingerPosition.y - firstFingerPostion.y));
        }
        if(Input.GetMouseButtonUp(0))
        {


            angle = Mathf.Atan2((lastFingerPosition.x - firstFingerPostion.x), (lastFingerPosition.y - firstFingerPostion.y)) * Mathf.Rad2Deg;

            float distance = Vector3.Distance(firstFingerPostion, lastFingerPosition);

            if(distance < 10)
            {
                return;
            }
            if (angle >= -30 && angle < 30)
            {
                if(firstFingerPostion.x < Screen.width/2)
                {
                    
                    Ltruck.GetComponent<CsTruck>().Click();
                    
                }
                else
                {
                    
                    Rtruck.GetComponent<CsTruck>().Click();
                    
                }
                
            }
            else if (angle > 150 || angle < -150)
            {
             
            }
            else if (angle <= -50 && angle >= -110)
            {
                player.GetComponent<CsBoxController>().setDirection(1);
             
            }
            else if (angle >= 50 && angle <= 110)
            {
                player.GetComponent<CsBoxController>().setDirection(2);
             
            }
            Debug.Log(distance);
        }
       
    }
    private void TouchUpdate()
    {
        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                touchFingerId = touch.fingerId;
                firstFingerPostion = touch.position;
                lastFingerPosition = touch.position;
                break;

            case TouchPhase.Moved:
                if (touch.fingerId == touchFingerId)
                {
                    lastFingerPosition = touch.position;
                    swipeDistanceX = Mathf.Abs((lastFingerPosition.x - firstFingerPostion.x));
                    swipeDistanceY = Mathf.Abs((lastFingerPosition.y - firstFingerPostion.y));
                }
                break;
            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                if (touch.fingerId == touchFingerId)
                {
                    touchFingerId = -1;
                    angle = Mathf.Atan2((lastFingerPosition.x - firstFingerPostion.x), (lastFingerPosition.y - firstFingerPostion.y)) * Mathf.Rad2Deg;


                    float distance = Vector3.Distance(firstFingerPostion, lastFingerPosition);

                    if (distance < 10)
                    {
                        return;
                    }

                    if (angle >= -30 && angle < 30)
                    {
                        if (firstFingerPostion.x < Screen.width / 2)
                        {

                            Ltruck.GetComponent<CsTruck>().Click();

                        }
                        else
                        {

                            Rtruck.GetComponent<CsTruck>().Click();

                        }

                    }
                    else if (angle > 150 || angle < -150)
                    {

                    }
                    else if (angle <= -50 && angle >= -110)
                    {
                        player.GetComponent<CsBoxController>().setDirection(1);

                    }
                    else if (angle >= 50 && angle <= 110)
                    {
                        player.GetComponent<CsBoxController>().setDirection(2);

                    }
                }
                break;
        }
    }


}
