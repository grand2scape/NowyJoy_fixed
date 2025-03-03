using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingMove : MonoBehaviour
{
    Vector2 settingposdown = new Vector2(0, -1.5f);
    Vector2 settingposup = new Vector2(0, 3f);
    public float speed = 7f;
    public Button btn, hidebtn;
    bool isMovedUp = false;
    bool isMovedDown = false;

    void Start()
    {
        btn.onClick.AddListener(movingDown);
        hidebtn.onClick.AddListener(movingUp);
    }

    void movingUp()
    {
        isMovedUp = true;
        StartCoroutine("settingMovingUp");
    }

    void movingDown()
    {
        isMovedDown = true;
        StartCoroutine("settingMovingdown");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StopTrigger"))
        {
            if (isMovedDown)
            {
                StopCoroutine("settingMovingdown");
                isMovedDown = false;
            }
            else if (isMovedUp)
            {
                StopCoroutine("settingMovingUp");
                isMovedUp = false;
            }
            
        }
    }
    IEnumerator settingMovingUp()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0f);
            transform.Translate(settingposup * speed);
        }
    }

    IEnumerator settingMovingdown()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0f);
            transform.Translate(settingposdown * speed);
        }
    }
}
