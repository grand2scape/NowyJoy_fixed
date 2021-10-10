using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public GameObject RushWarning;
    PolygonCollider2D col;

    private void Awake()
    {
        col = GetComponentInChildren<PolygonCollider2D>(); 
    }

    void OnEnable()
    {
        // StartCoroutine("Dash");
        // StartCoroutine("Jump");

           Invoke("DoPattern", 3f);
    }
    private void Update()
    {
        if (this.gameObject.transform.position.z < -0.15)
        
            OffCollider();
        
        else
            OnCollider();
    }

    void DoPattern()
    {
        int rand = Random.Range(0, 5);

        switch (rand)
        {
            case 0:
                StartCoroutine("Dash");
                break;

            case 1:
                StartCoroutine("Dash");
                break;

            case 2:
                StartCoroutine("Dash");
                break;

            case 3:
                StartCoroutine("Dash");
                break;

            case 4:
                StartCoroutine("Jump");
                break;

        }

       
        
    }

    void OnCollider()
    {
        col.enabled = true;
    }

    void OffCollider()
    {
        col.enabled = false;

    }

    void CuvOut_R()
    {
        StartCoroutine("CurveOut_R");
    }

    void CuvOut_L()
    {
        StartCoroutine("CurveOut_L");
    }

    IEnumerator Dash()
    {
        int RandDir = Random.Range(0, 8);
        int isDouble = Random.Range(0, 3);

        float DashSpeed = 2f;
        float ReturnSpeed = 3.5f;



        switch (RandDir)
        {
            case 0: // 위
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 90);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(1f);
                RushWarning.SetActive(false);
                iTween.MoveTo(this.gameObject, iTween.Hash("y", 7, "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(3f);
                if (isDouble == 0)
                {
                    RushWarning.transform.rotation = Quaternion.Euler(0, 0, 90);
                    RushWarning.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    RushWarning.SetActive(false);
                    iTween.MoveTo(this.gameObject, iTween.Hash("y", 0, "time", DashSpeed, "easeType", "EaseInOutBack"));
                    yield return new WaitForSeconds(3f);
                }
                else
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("y", 0, "time", ReturnSpeed, "easeType", "Linear"));
                    yield return new WaitForSeconds(4f);
                }
                break;

            case 1: // 오른쪽
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 0);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(1f);
                RushWarning.SetActive(false);
                iTween.MoveTo(this.gameObject, iTween.Hash("x", 5, "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(3f);
                if (isDouble == 0)
                {
                    RushWarning.transform.rotation = Quaternion.Euler(0, 0, 0);
                    RushWarning.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    RushWarning.SetActive(false);
                    iTween.MoveTo(this.gameObject, iTween.Hash("x", 0, "time", DashSpeed, "easeType", "EaseInOutBack"));
                    yield return new WaitForSeconds(3f);
                }
                else
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("x", 0, "time", ReturnSpeed, "easeType", "Linear"));
                    yield return new WaitForSeconds(4f);
                }
                break;

            case 2: // 아래
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 270);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(1f);
                RushWarning.SetActive(false);
                iTween.MoveTo(this.gameObject, iTween.Hash("y", -7, "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(3f);
                if (isDouble == 0)
                {
                    RushWarning.transform.rotation = Quaternion.Euler(0, 0, 270);
                    RushWarning.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    RushWarning.SetActive(false);
                    iTween.MoveTo(this.gameObject, iTween.Hash("y", 0, "time", DashSpeed, "easeType", "EaseInOutBack"));
                    yield return new WaitForSeconds(3f);
                }
                else
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("y", 0, "time", ReturnSpeed, "easeType", "Linear"));
                    yield return new WaitForSeconds(4f);
                }
                break;

            case 3: // 왼쪽
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 180);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(1f);
                RushWarning.SetActive(false);
                iTween.MoveTo(this.gameObject, iTween.Hash("x", -5, "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(3f);
                if (isDouble == 0)
                {
                    RushWarning.transform.rotation = Quaternion.Euler(0, 0, 180);
                    RushWarning.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    RushWarning.SetActive(false);
                    iTween.MoveTo(this.gameObject, iTween.Hash("x", 0, "time", DashSpeed, "easeType", "EaseInOutBack"));
                    yield return new WaitForSeconds(3f);
                }
                else
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("x", 0, "time", ReturnSpeed, "easeType", "Linear"));
                    yield return new WaitForSeconds(4f);
                }
                break;

            case 4: // 오른쪽 위
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 60);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(1f);
                RushWarning.SetActive(false);
                iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(3.3f, 6, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(3f);
                if (isDouble == 0)
                {
                    RushWarning.transform.rotation = Quaternion.Euler(0, 0, 60);
                    RushWarning.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    RushWarning.SetActive(false);
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                    yield return new WaitForSeconds(3f);
                }
                else
                {

                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0, 0), "time", ReturnSpeed, "easeType", "Linear"));
                    yield return new WaitForSeconds(4f);
                }
                break;

            case 5: // 오른쪽 아래
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 300);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(1f);
                RushWarning.SetActive(false);
                iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(3.3f, -6, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(3f);
                if (isDouble == 0)
                {
                    RushWarning.transform.rotation = Quaternion.Euler(0, 0, 300);
                    RushWarning.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    RushWarning.SetActive(false);
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                    yield return new WaitForSeconds(3f);
                }
                else
                {

                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0, 0), "time", ReturnSpeed, "easeType", "Linear"));
                    yield return new WaitForSeconds(4f);
                }
                break;

            case 6: // 왼쪽 아래
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 240);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(1f);
                RushWarning.SetActive(false);
                iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(-4f, -6, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(3f);
                if (isDouble == 0)
                {
                    RushWarning.transform.rotation = Quaternion.Euler(0, 0, 240);
                    RushWarning.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    RushWarning.SetActive(false);
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                    yield return new WaitForSeconds(3f);
                }
                else
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0, 0), "time", ReturnSpeed, "easeType", "Linear"));
                    yield return new WaitForSeconds(4f);
                }
                break;

            case 7: // 왼쪽 위
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 120);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(1f);
                RushWarning.SetActive(false);
                iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(-3.5f, 6, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(3f);
                if (isDouble == 0)
                {
                    RushWarning.transform.rotation = Quaternion.Euler(0, 0, 120);
                    RushWarning.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    RushWarning.SetActive(false);
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                    yield return new WaitForSeconds(3f);
                }
                else
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0, 0), "time", ReturnSpeed, "easeType", "Linear"));
                    yield return new WaitForSeconds(4f);
                }
                break;

            default:
                break;

        }
        Invoke("DoPattern", 3f);
    }

    IEnumerator CurveOut_R()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("CurveOut_R"), "time", 3f, "easeType", "Linear"));
        yield return new WaitForSeconds(3f);
        StartCoroutine("CurveOut_L");
    }

    IEnumerator CurveOut_L()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("CurveOut_L"), "time", 3f, "easeType", "Linear"));
        yield return new WaitForSeconds(4f);
        StartCoroutine("Dash");
    }

    IEnumerator Jump()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 2.75f, 0), "time", 1.5f, "easeType", iTween.EaseType.linear));
        yield return new WaitForSeconds(1f);
        iTween.MoveTo(this.gameObject,
        iTween.Hash("path",
        iTweenPath.GetPath("Jump"),
        "speed", 3f,
        "delay", 2f,
        "easeType", iTween.EaseType.easeOutBounce,  
        "movetopath", false));
        yield return new WaitForSeconds(5f);
        iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0, 0), "time", 1f, "easeType", iTween.EaseType.linear));
        Invoke("DoPattern", 3f);
    }

 
}
