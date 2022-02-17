using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarMove : MonoBehaviour
{
    //Input Player
    private float horizontalInputPlayer;
    private float verticalInputPlayer;

    //variable SteeringAngle
    private float carSteeringAngle;

    //variable for Wheelcollider 
    [SerializeField] WheelCollider frontDriverWheel, frontPassengerWheel;
    [SerializeField] WheelCollider rearDriverWheel, rearPassengerWheel;
    //Transform versions for modifer rotation
    [SerializeField] Transform frontDriverTransfrom, frontPassengerTransform;
    [SerializeField] Transform rearDriverTransform, rearPassengerTransform;

    //controls steerlingAngle so example:how fast turn
    [SerializeField] float maxSteerAngle = 30f;

    //variable how fast can the car go
    [SerializeField] float motorForce = 2400f;

    //variable rigidbody
    Rigidbody rigidbody;

    //varable center of mass
    private Vector3 centerOfMass;

    public void GetInput()
    {
        //getting input unity Input Manager
        horizontalInputPlayer = Input.GetAxisRaw("Horizontal");
        verticalInputPlayer = Input.GetAxisRaw("Vertical");
    }

    private void Start()
    {
        //getting access to object rigidbody
        rigidbody = GetComponent<Rigidbody>();
        //calcuate center of mass car
        rigidbody.centerOfMass = centerOfMass;
    }

    private void Steer()
    {
        //Define maxSteerAngle to the postion where te car is going left or right
        carSteeringAngle = maxSteerAngle * horizontalInputPlayer;
        //  Set steerAngle value to car Rotation Angle value
        //  Rotaion of the angle at rotaton left or right car
        frontDriverWheel.steerAngle = carSteeringAngle;
        frontPassengerWheel.steerAngle = carSteeringAngle;
    }

    private void Accelerate()
    {
        //Adding Speed to the 2 front wheels car
        frontDriverWheel.motorTorque = verticalInputPlayer * motorForce;
        frontPassengerWheel.motorTorque = verticalInputPlayer * motorForce;
    }

    //Update position look of the Wheels  
    //example: look of the wheels going up after you are at higher postion example: top of a rock 
    private void UpdateWheelPoses()
    {
        //Calling the methods 4 times 1 time for every wheel with the TRANSFORM AND THE COLLIDERS
        UpdateWheelPose(frontDriverWheel, frontDriverTransfrom);
        UpdateWheelPose(frontPassengerWheel, frontPassengerTransform);
        UpdateWheelPose(rearDriverWheel, rearDriverTransform);
        UpdateWheelPose(rearPassengerWheel, rearPassengerTransform);
    }

    //Update position collider Wheels 
    //Taking information form the colliders wheel and apply it to the transform so the look from the wheels
    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        //store position
        //Make vector 
        Vector3 myPosition = transform.position;
        //store rotation
        // make Quaternion
        Quaternion rotationQuaternion = transform.rotation;

        //add Values to Vector3 and Quaternion
        //out = Unity modifiles this parameters for you  so you dont have to postion = .... 
        collider.GetWorldPose(out myPosition, out rotationQuaternion);

        //after getting value back from out transforming to new transfrom position
        transform.position = myPosition;
        transform.rotation = rotationQuaternion;
    }


    //Run Methodes
    private void FixedUpdate()
    {
        //calling methodes
        GetInput();
        Accelerate();
        Steer();
        UpdateWheelPoses();
    }
   
}
