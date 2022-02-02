using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour
{
    //references 
    public Transform PosFront;
    public GameObject[] ballPool; //create a pool in which the balls are randomly pulled from

    //variables
    public float FoodBallForce = -300f;
    //private bool thrown = false; //if ball is thrown
    //private int availableShots = 5;
    public GameObject activeBall;
    public GameObject nextBall;

    private void Start()
    {
        PickBall();
        RandomizeBallEvent.AddListener(PickBall);
    }

    private void Update()
    {    
                                                 //event ball destroy(win or loose)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public static UnityEvent RandomizeBallEvent = new UnityEvent();
    public static UnityEvent<GameObject> AfterBallPickedEvent = new UnityEvent<GameObject>();


    void Shoot()
    {
        if(activeBall == null)
        {
            //setActive(true)?
            GameObject ball = Instantiate(nextBall, PosFront.position, PosFront.rotation); //spawn random ball
            activeBall = ball; 
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(PosFront.forward * FoodBallForce, ForceMode.Impulse); //simulating shooting by adding force
        }
    }

    void PickBall()
    {
        System.Random rnd = new System.Random(); //Random Generator
        GameObject ballPrefab = ballPool[rnd.Next(ballPool.Length)]; //Pick a random ball Prefab from list
        nextBall = ballPrefab;
        AfterBallPickedEvent.Invoke(ballPrefab);
    }
}


    /*//references
    public Transform PosFront;
    public Transform FoodBall_Ramen;
    public GameObject FoodBall_RamenPrefab;

    //variables
    public float FoodBall_RamenForce = 1000f;
    private bool BallInHands = false;
    private Rigidbody rbBall;

    private void Start()
    {
        rbBall = FoodBall_RamenPrefab.transform.gameObject.GetComponent<Rigidbody>();
        Debug.Log(rbBall);
    }

    private void Update()
    {
        if (!BallInHands)
        {
            GameObject FoodBall_Ramen = Instantiate(FoodBall_RamenPrefab, PosFront.position, PosFront.rotation); //spawning a Foodball to shoot
            FoodBall_Ramen.GetComponent<Rigidbody>();

            BallInHands = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            print("zzzz");
        }
    }

    void Shoot()
    {
        //access foodball s rigidbody
        rbBall.AddForce(PosFront.up * FoodBall_RamenForce, ForceMode.Impulse);
        //rbBall.AddForce(0, 0, -1000f);//add force to imitate shooting
    }*/

