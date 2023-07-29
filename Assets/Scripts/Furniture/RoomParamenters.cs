using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomParamenters : MonoBehaviour
{
    [SerializeField] GameObject foodInRoom;

    public GameObject FoodInRoom
    {
        get { return foodInRoom; }
    }
}
