using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Time_UI : MonoBehaviour
{
    int min;
    float sec;
    public bool isClear;

   
    Text txt;
   
    private void Awake()
    {
     
        txt = transform.GetChild(1).GetComponent<Text>();

    }

    void Update()
    {
        time();     
    }

    void time()
    {
        sec += Time.deltaTime;
        if (sec >= 60)
        {
            sec = 0;
            min += 1;
        }
        txt.text = string.Format("{0}:{1:D2}", min, (int)sec);
        
    }
   
    
}
