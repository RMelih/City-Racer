using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSysteem : MonoBehaviour
{
    //adding text varable
    [SerializeField] GameObject scoreText;
    
    //hidding in inspector
    [HideInInspector]
    //score varaible 
    public  static int theScore;
    //varable for maxPoints
    [SerializeField] float maxPoints;

    private void Update()
    {
        //call methodes
        Points();
    }


    private void Points()
    {
        //getting access to text component 
        //adding the score and the value for the maxPoints
        scoreText.GetComponent<Text>().text = "" + theScore + " / " + maxPoints;
        //asking info about info about the score and maxpoints
        if (theScore == maxPoints || theScore > maxPoints)
        {
            //ending game if the score is equal or more than maxpoints
            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }
}
