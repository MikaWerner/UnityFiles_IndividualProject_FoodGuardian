using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    //variables
    public float speed = 4f;
    float hitdist = 0.0f;

    //references
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        //movement + automatic rotation
        //code from https://medium.com/eincode/unity-fundamentals-rotate-a-game-object-in-movements-direction-9a62ec10a5c8 

        float horizontalAxis = Input.GetAxis("Horizontal");  

        Vector3 movement = new Vector3(horizontalAxis, 0, 0).normalized; //movement on x and z axis as well as diagonally


        Plane playerPlane = new Plane(Vector3.up, transform.position); //using raycast to calculate where the mouse is pointing to in a 3-Dimensional Space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }

        /*Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);*/   //smooth 360 rotation while walking


        Vector3 newPosition = rb.position + movement * speed * Time.fixedDeltaTime; //movement

        newPosition.x = Mathf.Min(newPosition.x, 22f);  //limiting movement between two coordinates on the x axis
        newPosition.x = Mathf.Max(newPosition.x, -21f);
        rb.MovePosition(newPosition); 

        //rb.MoveRotation(targetRotation); // rotate into moving direction

    }

    
}
