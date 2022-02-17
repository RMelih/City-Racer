using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGold : MonoBehaviour
{
    //adding audiosource variable
    [SerializeField] AudioSource collectSound;

    private void Update()
    {
        //call methods
        rotateCoins();
    }
    private void OnTriggerEnter(Collider other)
    {
        //playing sounds at contact with object
        collectSound.Play();
        //removing object after collecting it
        Destroy(gameObject);

      
    }

    private void rotateCoins()
    {
        //rotate coins
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }
}
