using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngineSounds : MonoBehaviour
{
    //variables
    [SerializeField] float topSpeedAudio = 100f; // km per hour
    [SerializeField] float currentSpeedAudio = 0f;
    private float pitch = 0f;

    //variable rigidbody
    private Rigidbody rigidbody;

    private void Start()
    {
        //Getting acces to rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        //call method
        CarEngineSound();
    }

    private void CarEngineSound()
    {
        // getting access to rigidbody value and multiple that by 3.6 so whe get kmph 
        currentSpeedAudio = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        // updating sound pitch based on rigidbody currentspeed and rigidbody topspeed
        pitch = currentSpeedAudio / topSpeedAudio;
        //getting acces to audiosource and adding updated pitch to audiosource pitch.
        transform.GetComponent<AudioSource>().pitch = pitch;
    }

}


