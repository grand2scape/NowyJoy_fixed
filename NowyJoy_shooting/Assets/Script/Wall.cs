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
       
        Vector3 Spacepos = Camera.main.ScreenToWorldPoint(transform.position);
        Vector3 Down = Camera.main.ScreenToWorldPoint(new Vector3(540, 1938, Spacepos.z));
        Vector3 Up = Camera.main.ScreenToWorldPoint(new Vector3(540, -20, Spacepos.z));
        Vector3 Left = Camera.main.ScreenToWorldPoint(new Vector3(1088, 960, Spacepos.z));
        Vector3 Right = Camera.main.ScreenToWorldPoint(new Vector3(-9.6f, 960, Spacepos.z));

        Walls[0].transform.position = Up;
        Walls[1].transform.position = Right;
        Walls[2].transform.position = Down;
        Walls[3].transform.position = Left;
        

     //   Debug.Log(Camera.main.WorldToScreenPoint(Walls[3].transform.position));

    }
}
