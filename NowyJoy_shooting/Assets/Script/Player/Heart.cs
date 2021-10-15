using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    GameManager gm;
    public SpriteRenderer sprRend;
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        anim = GetComponentInParent<Animator>();
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
        anim.SetTrigger("Hit");
    //    sprRend.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged", 1.5f);
    }

    public void OffDamaged()
    {
        gameObject.layer = 6;
        transform.parent.gameObject.layer = 6;

     //   sprRend.color = new Color(1, 1, 1, 1);
    }
}
