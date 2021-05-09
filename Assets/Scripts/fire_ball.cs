using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_ball : MonoBehaviour
{
    // private SerialPort stream = new SerialPort("COM34", 9600);
    public float value = 2.5f;
    public Rigidbody sphere;
    public Transform cameraTransform;
    public float max_value = 3.5f;
    public float minAccelerationMultiplerValue = 0.45f;
    public float maxAccelerationMultiplerAddition = 0.1f;
    public float accelerationMultiplier;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // get value from arduino
        // value = float.Parse(stream.ReadLine());
        float muscleK = value/max_value;
        accelerationMultiplier = muscleK * maxAccelerationMultiplerAddition + minAccelerationMultiplerValue;
        // input x, y, z;
        float x = 0;
        float y = 0.5f;
        float z = 1;
        // define direction
        Vector3 force = new Vector3(x, y, z) ;


        if (Input.GetKeyDown("space")) {
            // if player strains more that 75% of muscle, kick the ball
            if (muscleK > 0.75){
                sphere.AddForce(accelerationMultiplier * sphere.mass * force, ForceMode.VelocityChange);
            }
        }

        cameraTransform.position = new Vector3(sphere.position.x, sphere.position.y + 0.25f, sphere.position.z - 1f);
    }
}
