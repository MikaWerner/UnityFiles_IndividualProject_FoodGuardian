using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public GameObject DeliveredOrder_Particles;
    
    public enum TriggerType    //more options than bool
    {
        WIN, 
        LOOSE,
        CATCH
    }
    public TriggerType type = TriggerType.WIN;

    public FoodBallPhysics.BallType OrderType;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FoodBall")
        {
            switch (type)
            {
                case TriggerType.WIN:
                    FoodBallPhysics bp = other.gameObject.GetComponent<FoodBallPhysics>();
                    if (bp.balltype == OrderType)
                    {
                        UI_Score.scoreValue += 1;
                        Instantiate(DeliveredOrder_Particles, transform.position, Quaternion.identity);
                        PlayerShooting.RandomizeBallEvent.Invoke();
                        Debug.Log("goalllllllllllll");
                        Destroy(other.gameObject);
                    }
                    break;

                case TriggerType.LOOSE:
                    Debug.Log("you fucking disgrace");
                    HeartSystem.DamageEvent.Invoke();
                    PlayerShooting.RandomizeBallEvent.Invoke();
                    Destroy(other.gameObject);
                    break;

                case TriggerType.CATCH:
                    FoodBallPhysics Ballphysics = other.gameObject.GetComponent<FoodBallPhysics>();
                    if(Ballphysics.lifeTime >= 0.5f)
                    {
                        Debug.Log("catch the baby");
                        Destroy(other.gameObject);
                    }
                    break;
            }
        }
    }
}