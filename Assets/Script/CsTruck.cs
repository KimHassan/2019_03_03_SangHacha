using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsTruck : MonoBehaviour
{
    public int type;

    int num;

    int max;

    public GameObject Score;

    public GameObject[] trucks = new GameObject[2];

    Vector3[] truckDestination = new Vector3[3];

    int truckMoveNum = 0;

    bool isTruckMove = false;

    float truckSpeed = 10f;

    int maxNum = 5;

    // Start is called before the first frame update
    void Start()
    {

            truckDestination[0] = new Vector3(0, 0, 9);
        
            truckDestination[1] = new Vector3(0, 0, 0);

            truckDestination[2] = new Vector3(0, 0, -15);

        for(int i=0;i<3;i++)
        {
            truckDestination[i] = transform.rotation * truckDestination[i] + transform.position;
        }
     
        InitMax();

    }

    // Update is called once per frame
    void Update()
    {
        if (type == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
             
                Click();
            }
        }
        if (type == 2)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
 
                Click();
            }
        }
        MoveTruckUpdate();
        Score.GetComponentInChildren<TextMesh>().text = max.ToString();

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Box")
        {
           
            if (collision.gameObject.GetComponent<CsBox>().type == type)
            {
                
            }
            else
            {
                
                CsUIControll.instance.FailPannel();
            }
            Destroy(collision.gameObject);

            num++;

            if (num > max)
            {
                CsUIControll.instance.FailPannel();
            }
        }

    }
    void InitMax()
    {
        CsUIControll.instance.level++;
        LevelUp();
        max = Random.Range(maxNum - 4, maxNum);
        num = 0;

    }

    void LevelUp()
    {
        if(CsUIControll.instance.level % 4 == 0)
        {
            maxNum++;
        }
    }
    public void Click()
    {
        if (max == num)
        {
           
            CsUIControll.instance.ScoreUp(max * 1000);
            MoveTruck();
            InitMax();
            CsSoundManager.instance.playTruckSound();
           
        }
        else
        {
         
            CsUIControll.instance.FailPannel();
        }
    }

    public void  MoveTruck()
    {
        isTruckMove = true;
        truckMoveNum++;
    }
    
    public void MoveTruckUpdate()
    {
        if (isTruckMove)
        {


            if (truckMoveNum % 2 == 0)
            {
                trucks[1].transform.position = Vector3.MoveTowards(trucks[1].transform.position, truckDestination[0], truckSpeed * Time.deltaTime);

                trucks[0].transform.position = Vector3.MoveTowards(trucks[0].transform.position, truckDestination[1], truckSpeed * Time.deltaTime);

                if (trucks[1].transform.position == truckDestination[0]
                    && trucks[0].transform.position == truckDestination[1])
                {
                    trucks[1].transform.position = truckDestination[2];
                    isTruckMove = false;
                }
            }
            else
            {
                trucks[0].transform.position = Vector3.MoveTowards(trucks[0].transform.position, truckDestination[0], truckSpeed * Time.deltaTime);

                trucks[1].transform.position = Vector3.MoveTowards(trucks[1].transform.position, truckDestination[1], truckSpeed * Time.deltaTime);

                if (trucks[0].transform.position == truckDestination[0]
                    && trucks[1].transform.position == truckDestination[1])
                {
                    trucks[0].transform.position = truckDestination[2];
                    isTruckMove = false;
                }
            }
        }
        
    }
}
