using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomSwitch : MonoBehaviour
{
    [SerializeField] PolygonCollider2D room1Confiner;
    [SerializeField] PolygonCollider2D room2Confiner;

    [SerializeField] PolygonCollider2D startConfiner = new PolygonCollider2D();
    [SerializeField] PolygonCollider2D endConfiner = new PolygonCollider2D();
    [SerializeField] PolygonCollider2D transitionConfiner = new PolygonCollider2D();

    [SerializeField] Vector2[] testVector1;
    [SerializeField] Vector2[] testVector2;

  //  [SerializeField] PolygonCollider2D currentConfiner;

    [SerializeField] float transitionSpeed = 1;
    [SerializeField] CinemachineConfiner cinemachineConfiner;

    //is switch requested should cleared once transition is completed
    public bool isSwitchRequested;

    private void Start()
    {
       // startConfiner = new PolygonCollider2D();
        //endConfiner = new PolygonCollider2D();
        //transitionConfiner = new PolygonCollider2D();

        startConfiner.points = room1Confiner.points;
        endConfiner.points = room1Confiner.points;
        transitionConfiner.points = room1Confiner.points;

        testVector1 = new Vector2[3];
        testVector2 = new Vector2[3];
        Debug.Log ("Is equal" + testVector1==testVector2.ToString());
    }
    private void Update()
    {
        if (!transitionConfiner.points.Equals(endConfiner.points))
        {
            Debug.Log ("transitioning camera");
            for (int i = 0; i< transitionConfiner.points.Length; i++)
            {
                if (transitionConfiner.points[i] != endConfiner.points[i])
                {
                    transitionConfiner.points[i] = Vector2.Lerp(transitionConfiner.points[i], endConfiner.points[i], transitionSpeed * Time.unscaledDeltaTime);
                }
            }

        }
    }

}
