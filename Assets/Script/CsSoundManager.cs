using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsSoundManager : MonoBehaviour
{
    public static CsSoundManager instance;
    // Start is called before the first frame update

    AudioSource myAudio;
    AudioClip truckSound;
    AudioClip boxSound;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
        truckSound = Resources.Load<AudioClip>("Sound/truckSound") as AudioClip;
        boxSound = Resources.Load<AudioClip>("Sound/boxSound") as AudioClip;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playTruckSound()
    {
       // myAudio.PlayOneShot(truckSound);
    }
    public void playBoxSound()
    {
        //myAudio.PlayOneShot(boxSound);
    }
}
