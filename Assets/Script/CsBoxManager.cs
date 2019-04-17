using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsBoxManager : MonoBehaviour
{
    public GameObject GO_box;
    public GameObject player;


    int current = 0;

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 2)
        {
            CsSoundManager.instance.playBoxSound();
            setBox();
            time = 0;
        }
    }
    void setBox()
    {

        GameObject b = Instantiate(GO_box, this.transform.position, Quaternion.identity) as GameObject;

        b.GetComponent<CsBox>().setUp(Random.Range(1, 3), player.transform.position);

        current++;

    }
}
