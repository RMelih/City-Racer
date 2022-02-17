using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarRest : MonoBehaviour
{
    // adding text variable
    [SerializeField] Text currentSpeedText;
    // variable for speed
    private float speed;

    // variable for time left and ui text 
    [SerializeField] float timeLeft = 60;
    [SerializeField] Text timeLeftText;

    //adding variable rigidbody
    Rigidbody rigidbody;

    private void Start()
    {
        //getting acces to rigidbodu
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //calling not physics methods
        RestartGame();
        AngularDragChange();
    }

    private void FixedUpdate()
    {
        //calling physics methods
        SpeedCar();
        TimeLeft();
    }
    void RestartGame()
    {
        //asking player position
        if (rigidbody.position.y < -3f)
        {
            //ending game if player is below 3f
            FindObjectOfType<GameManager>().EndGame();
        }
        //asking player input
        else if (Input.GetKey(KeyCode.M))
        {
            //ending game if keycode is pressed
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void AngularDragChange()
    {
        //asking info about speed rigidbody
        // if speed rigidbody is below or equal 0.1 change rigidbody angularDrag
        if (rigidbody.velocity.magnitude <= 0.1)
        {
            //changing angularDrag
            rigidbody.angularDrag = 500f;
        }
        else if (rigidbody.velocity.magnitude >= 0.5)
        {
            // changing angularDrag
            rigidbody.angularDrag = 0.05f;
        }
    }

    void SpeedCar()
    {
        //calculate speed of rigidbody 
        // tranforming rigidbody speed to kmph
        speed = rigidbody.velocity.magnitude * 3.6f;

        //getting text component 
        //transforming float to int
        //transforming int to string
        currentSpeedText.GetComponent<Text>().text = ((int)speed).ToString();
    }


    void TimeLeft()
    {
        //variable minTime
        float minTime = 0;

        //getting text component
        //transforming float to int
        //transforming int to string
        timeLeftText.GetComponent<Text>().text = ((int)timeLeft).ToString();

        //time.delta is the time beween the current and previous frame
        //time counter
        timeLeft -= Time.deltaTime;

        //asking info about timeleft 
        if (timeLeft < minTime)
        {
            //setting time left to min value 0 so whe don't see -value , !!levelcomplete game delay
            timeLeft = minTime;
            //ending game
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
