using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsBoxController : MonoBehaviour
{

    enum DIRECTION
    {
        IDLE,
        LEFT,
        RIGHT
    }


    public GameObject box;

    bool isCatch = false;

    int touch = 0;

    DIRECTION direction;

    public GameObject barrier;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        WorkUpdate();
        if (touch >= 2)
        {
            CsUIControll.instance.FailPannel();
        }

    }


    void WorkUpdate()
    {
        if (isCatch)
        {
            if (box)
            {
                switch (direction)
                {
                    case DIRECTION.IDLE:
                        {

                            barrier.transform.position = new Vector3(0, 0, 1) + transform.position;
                            barrier.transform.rotation = Quaternion.Euler(0, 0, 0);
                            break;
                        }
                    case DIRECTION.LEFT:
                        {
                            // box.GetComponent<CsBox>().setTruck(LTruck.transform.position - new Vector3(0,0,3));
                            box.GetComponent<CsBox>().setTruck(new Vector3(-9.0f,0,-6.5f));
                            box.transform.position =  new Vector3(-0.4f, 1.5f, 0.1f);
                            box.transform.rotation = Quaternion.Euler(0, 52, 0);
                            ResetDirection();
                            break;
                        }
                    case DIRECTION.RIGHT:
                        {
                            //box.GetComponent<CsBox>().setTruck(RTruck.transform.position - new Vector3(0, 0, 3));
                            box.GetComponent<CsBox>().setTruck(new Vector3(+9.0f,0, -6.5f));
                            box.transform.position = new Vector3(0.4f, 1.5f, 0.1f);
                            box.transform.rotation = Quaternion.Euler(0, -52, 0);

                            ResetDirection();
                            break;
                        }
                }
            }

        }
    }

    void ResetDirection()
    {
        isCatch = false;
        touch = 0;
        direction = DIRECTION.IDLE;

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Box")
        {
            touch++;

            box = collision.gameObject;

            collision.gameObject.GetComponent<CsBox>().MeetPlayer();

            isCatch = true;
        }
    }

    public void setDirection(int _direction)
    {
        direction = (DIRECTION)_direction;
        switch (direction)
        {
            case DIRECTION.IDLE:
                {

                    barrier.transform.position = new Vector3(0, 0, 1) + transform.position;
                    barrier.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                }
            case DIRECTION.LEFT:
                {
                    // box.GetComponent<CsBox>().setTruck(LTruck.transform.position - new Vector3(0,0,3));
                   
                    barrier.transform.position = new Vector3(1f, 0, -0.45f) + transform.position;
                    barrier.transform.rotation = Quaternion.Euler(0, -50, 0);

                    break;
                }
            case DIRECTION.RIGHT:
                {
                    //box.GetComponent<CsBox>().setTruck(RTruck.transform.position - new Vector3(0, 0, 3));
                  
                    barrier.transform.position = new Vector3(-1f, 0, -0.45f) + transform.position;
                    barrier.transform.rotation = Quaternion.Euler(0, 50, 0);

                    break;
                }
        }
    }

}
