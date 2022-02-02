using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShowBall : MonoBehaviour
{
    public Sprite Baozi_Sprite;
    public Sprite Ramen_Sprite;
    public Sprite Sushi_Sprite;

    private void Start()
    {
        PlayerShooting.AfterBallPickedEvent.AddListener(OrderSelection);
    }

    public void OrderSelection(GameObject balls)
    {
        FoodBallPhysics.BallType type = balls.GetComponent<FoodBallPhysics>().balltype;

        if (type == FoodBallPhysics.BallType.RAMEN)
        {
            gameObject.GetComponent<Image> ().sprite = Ramen_Sprite;  
        }
        else if (type == FoodBallPhysics.BallType.BAOZI)
        {
            gameObject.GetComponent<Image>().sprite = Baozi_Sprite;
        }
        else if (type == FoodBallPhysics.BallType.SUSHI)
        {
            gameObject.GetComponent<Image>().sprite = Sushi_Sprite;

        }
    }
}
