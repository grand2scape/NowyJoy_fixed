using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject[] Walls = new GameObject[4];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
      //  Vector3 Spacepos = Camera.main.ScreenToWorldPoint(transform.position);
        Vector3 Down = Camera.main.WorldToViewportPoint(new Vector2(0,-5));
        Vector3 Up = Camera.main.WorldToViewportPoint(new Vector2(0, 5));
        Vector3 Left = Camera.main.WorldToViewportPoint(new Vector2(-2.8f, 0));
        Vector3 Right = Camera.main.WorldToViewportPoint(new Vector2(2.8f, 0));

        Walls[0].transform.position = Up;
        Walls[1].transform.position = Right;
        Walls[2].transform.position = Down;
        Walls[3].transform.position = Left;
        

     //   Debug.Log(Camera.main.WorldToScreenPoint(Walls[3].transform.position));

    }
}
