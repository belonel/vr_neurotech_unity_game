using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PointCounter : MonoBehaviour
{
    public static int points;
    public Rigidbody cube;
    public State state;
    public float groundLevelY = 0.16f;
    public enum State {OnGround, InAir}
    public Renderer cubeMaterial;
    public Material onGroundCubeMaterial;
    public Material inAirCubeMaterial;
    // Start is called before the first frame update
    void Start()
    {
        //onGroundCubeMaterial = Resources.Load("Assets/box_material.mat", typeof(Material)) as Material;
        //inAirCubeMaterial = Resources.Load("Assets/ground_material.mat", typeof(Material)) as Material;
        cubeMaterial = cube.GetComponent<Renderer>();
        state = isOnGround() ? State.OnGround : State.InAir;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.InAir && isOnGround())
        {
            points++;
            state = State.OnGround;
        } 
        else if (state == State.OnGround && !isOnGround())
        {
            points--;
            state = State.InAir;
        }

        cubeMaterial.material = state == State.InAir ? inAirCubeMaterial : onGroundCubeMaterial;
            

    }

    bool isOnGround()
    {
        return cube.position.y <= groundLevelY;
    }
}
