using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_ball : MonoBehaviour
{
    public Rigidbody sphere;
    public Transform cameraTransform; 
    public int accelerationMultiplier = 100;
    public Vector3 force = new Vector3(0f, 0f, 50f);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            sphere.AddForce(accelerationMultiplier * sphere.mass * force, ForceMode.Impulse);
            print("push");
        }
        cameraTransform.position = new Vector3(sphere.position.x, sphere.position.y + 0.25f, sphere.position.z - 1f);
    }
}
