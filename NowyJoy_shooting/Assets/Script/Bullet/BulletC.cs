using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletC : MonoBehaviour {

    public float speed = 10f;

    

    private void Start()
    {
        
      
    }

    private void Update()
    {
        //두번째 파라미터에 Space.World를 해줌으로써 Rotation에 의한 방향 오류를 수정함
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletWall"))
        {
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
