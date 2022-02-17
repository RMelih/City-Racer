using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeLights : MonoBehaviour
{
    //Making variable
    [SerializeField] Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //Get Component
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Call Method
        BrakeLightsOnOff();
    }

    private void BrakeLightsOnOff()
    {
        //Enable mesh renderer
        if (Input.GetKey(KeyCode.S))
        {
            rend.enabled = true;
        }
        //disable mesh renderer
        else
        {
            rend.enabled = false;
        }
    }
}
