using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_Pawn : MonoBehaviour
{
    public GameObject target;
    Camera cam;
    public float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

             Vector3 screenPos = target.transform.position;
             screenPos.y += offsetY;
        //      cam.WorldToScreenPoint(new Vector2(target.transform.position.x, target.transform.position.y + offsetY));
           transform.position = screenPos;
    
        
    }
}
