using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsBox : MonoBehaviour
{
    public int type = 0;
    Vector3 destination;

    float speed = 15f;

    bool isCatch = false;

    int id = 0;
    MeshRenderer color;

    Rigidbody rigidbody;

    Vector3 velocity = new Vector3(0, 0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
       // transform.rotation = Quaternion.Euler(-90, 0, 23);
    }

    // Update is called once per frame
    void Update()
    {

        MoveUpdate();
    }

    void MoveUpdate()
    {
        if (isCatch == false)
        {

            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

            rigidbody.AddForce(velocity);

            
        }
    }

    public void setUp(int _type, Vector3 _destination)
    {
        type = _type;

        destination = _destination;

        color = GetComponentInChildren<MeshRenderer>();



        switch (type)
        {
            case 0:
                break;
            case 1:
                {
                    color.material.color = Color.red;
                    break;
                }
            case 2:
                {
                    color.material.color = Color.blue;
                    break;
                }
        }
    }
    public void MeetPlayer()
    {

        isCatch = true;
        rigidbody.velocity = Vector3.zero;


    }
    public void setTruck(Vector3 _destination)
    {
        destination = _destination;

        isCatch = false;


    }
}
