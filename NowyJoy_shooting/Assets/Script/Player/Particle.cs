using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject target;

    

    Vector3 Pos;

    void Update()
    {
       Pos = new Vector3(target.transform.position.x, target.transform.position.y,target.transform.position.z);
       transform.position = Pos;
    }
   
}
