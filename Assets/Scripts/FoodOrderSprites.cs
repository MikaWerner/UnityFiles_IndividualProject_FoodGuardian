using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOrderSprites : MonoBehaviour
{
    //changing 

    //references
    public GameObject Sushi_Sprite;
    public GameObject Baozi_Sprite;
    public GameObject Ramen_Sprite;
    public Transform PosOrderType;
   public enum OrderType
    {
        SUSHI,
        RAMEN,
        BAOZI
    }
    public OrderType type = OrderType.SUSHI;

    void Start()
    {
        OrderSelection();
    }

    public void OrderSelection ()
    {
        if(type == OrderType.RAMEN)
        {
            GameObject gameobject= Instantiate(Ramen_Sprite, PosOrderType.position, PosOrderType.rotation);
            gameobject.transform.parent = PosOrderType.transform;
        }
        else if(type == OrderType.BAOZI)
        {
            GameObject gameobject = Instantiate(Baozi_Sprite, PosOrderType.position, PosOrderType.rotation);
            gameobject.transform.parent = PosOrderType.transform;
        }
        else if(type==OrderType.SUSHI)
        {
            GameObject gameobject = Instantiate(Sushi_Sprite, PosOrderType.position, PosOrderType.rotation);
            gameobject.transform.parent = PosOrderType.transform;
        }
    }

}
