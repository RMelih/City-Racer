using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coins : MonoBehaviour
{
    //adding variables for coins values 
    [SerializeField] int amountGoldLow = 2;
    [SerializeField] int amountGoldMid = 3;
    [SerializeField] int amountGoldHigh = 5;

    private void OnTriggerEnter(Collider other)
    {
        //asking if object touches coins with low value
        if (other.gameObject.tag == "Low")
        {
            //adding the low gold amount to the score at PointSysteem script
            PointSysteem.theScore += amountGoldLow;
        }
        //asking if object touches coins with mid value
        if (other.gameObject.tag == "Mid")
        {
            //adding the mid gold amount to the score at PointSysteem script
            PointSysteem.theScore += amountGoldMid;
        }
        //asking if object touches coins with high value
        if (other.gameObject.tag == "High")
        {
            //adding the high gold amount to the score at PointSysteem script
            PointSysteem.theScore += amountGoldHigh;
        }

    }
}
