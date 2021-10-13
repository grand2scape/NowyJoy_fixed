using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    GameManager gm;
    public SpriteRenderer sprRend;
    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Rabbit"))
        {
            OnDamaged();
        }
    }

    public void OnDamaged()
    {
        Debug.Log("�÷��̾� ü�� : " + gm.HP);

        gm.HP--;

        gameObject.layer = 7;
        transform.parent.gameObject.layer = 7;

        sprRend.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged", 1.5f);
    }

    void OffDamaged()
    {
        gameObject.layer = 6;
        transform.parent.gameObject.layer = 6;

        sprRend.color = new Color(1, 1, 1, 1);
    }
}
