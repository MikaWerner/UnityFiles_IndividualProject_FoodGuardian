using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBallPhysics : MonoBehaviour 
{
    //references
    public Vector3 direction = new Vector3(0f, 0f, -1f);    //gravity force pushing -z axis to have gravity on a horizontal plane
    public Rigidbody rb;
    public GameObject BallBounceEffect;

    //variables
    [HideInInspector]
    public float lifeTime = 0f; 
    public enum BallType
    {
        SUSHI,
        RAMEN,
        BAOZI
    }
    public BallType balltype = BallType.SUSHI;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)  //add more bounce on collision
    {
        Vector3 bounceDir = collision.impulse.normalized;   
        float bounceScalar = 200f;

        Instantiate(BallBounceEffect, transform.position, Quaternion.identity);

        rb.AddForce(bounceDir * bounceScalar);

    }

    void Update()
    {
        rb.AddForce(direction);

        float maxSpeed = 30f;

        if (rb.velocity.magnitude > maxSpeed) //limit speed
        {
           rb.velocity = rb.velocity / rb.velocity.magnitude * maxSpeed;
        }

        lifeTime += Time.deltaTime; //check how long ball is existing
    }
}
