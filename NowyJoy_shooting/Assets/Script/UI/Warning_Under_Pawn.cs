using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_Under_Pawn : MonoBehaviour
{
    public GameObject[] Warning_UI;
    public GameObject[] target;
     

    private void Update()
    {
        Warning_UI[0].transform.position = target[0].transform.position;
        Warning_UI[1].transform.position = target[1].transform.position;
        Warning_UI[2].transform.position = target[2].transform.position;
    }

}
