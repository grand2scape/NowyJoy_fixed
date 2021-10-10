using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    public Image HP;
    public float hp;
    GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        hp = gm.HP;
    }

    // Update is called once per frame
    void Update()
    {     
        HP.fillAmount = gm.HP / hp;
    }
}
