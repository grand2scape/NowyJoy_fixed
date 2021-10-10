using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletA : MonoBehaviour
{
    public float rotateSpeed;
    public float moveSpeed;
    
    GameObject target;
    public Rigidbody2D rb;

    private void Awake()
    {
        target = GameObject.Find("Player").gameObject;
    }
    private void OnEnable()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2(
                transform.position.x - target.transform.position.x,
                transform.position.y - target.transform.position.y
        );
            /*
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            Quaternion rotation = Quaternion.Euler(angleAxis.x,angleAxis.y,angleAxis.z);
            transform.rotation = rotation;*/
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * 10 * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BulletWall"))
        {
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        if(collision.CompareTag("Flamingo"))
        {
            gameObject.SetActive(false);
        }
    }

}
