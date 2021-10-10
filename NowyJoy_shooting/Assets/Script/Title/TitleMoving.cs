using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMoving : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    float moveX, moveY;
    public GameObject TitlePlayer;
    Rigidbody2D rb;
    [Header("이동속도 조절")]
    [SerializeField] [Range(1f, 150f)] float moveSpeed = 20f;

    [SerializeField]
    private Touch touchZero; // 첫번째 터치
    bool onTouch; // 터치중인지 검사하는 bool형 변수

    public Vector3 m_curPos; // 플레이어의 현재 위치
    public Vector3 m_prevPos; // 플레이어의 이전 위치
    CircleCollider2D Playercollider; // collider
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Playercollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            OnDrag();

            TitlePlayerMove();


        }
    }

    private void TitlePlayerMove()
    {
        moveX = Input.GetAxis("Horizontal") * (moveSpeed * 5) * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * (moveSpeed * 5) * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }

    private void OnDrag()
    {
        if (Input.touchCount == 1) // 터치 입력이 하나일 때
        {
            touchZero = Input.GetTouch(0); // 현재 입력받은 위치를 첫번째 터치로 저장
            if (touchZero.phase == TouchPhase.Began) // 첫번째 터치의 phase가 Began(시작)이라면
            {
                onTouch = true; // onTouch를 true로 (이동 o)
                m_prevPos = m_curPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); // 이동시키기
            }
            else if (touchZero.phase == TouchPhase.Ended) // 첫번째 터치의 phase가 Ended(끝)이라면
            {
                onTouch = false; // onTouch를 false로 (이동 x)
            }
        }
        
        if (onTouch)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            m_curPos = mousePosition; // 현재 터치 위치
            Vector3 gap = m_curPos - m_prevPos; // 기존 위치와 현재 위치 차 계산

            transform.position += gap; // position에 gap만큼을 추가해 이동시킴
            m_prevPos = m_curPos; // 기존 위치를 현재 위치로 변경
        }
    }

}
