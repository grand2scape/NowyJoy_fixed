using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public ObjectManager objManager;
    public GameObject Spin_ptn;
    public bool isPatterning = false;

    // ����

    public Transform[] PatternPos;
    public GameObject[] testobj;

    // Ÿ���� ����
    GameObject target;
    public Transform bulletPos;  
    public float BulletAspeed;
    public float shootSpeed_target;
    bool isShooting = false;

    // ���ɼ� ����
    bool isSpin = false;
    public float shootSpeed_spin;

    // ���� ����
   
    [Range(0, 360), Tooltip("������ �� ȸ���� �� �� ����")]  //�ʱ� �߽� : ȸ�� �Ǵ� ����
    public float rot = 0f;

    [Range(3, 7), Tooltip("������ ����� ������� ������ ���ϴ� ��")] //->��~ĥ������ �׳��� �̻� �� �̻����� ���� ������ ����..
    public int Vertex = 3;

    [Range(1, 5), Tooltip("�� ���� �����Ͽ� �ձ� ����, ������ �������� ǥ�� ��")]
    public float sup = 3;

    //���ǵ�
    public float shootSpeed_Shape = 3;//ź��
    public float shootSpeed_shapping; //����

    //������ġ
    public GameObject[] shapePos = new GameObject[4];
    public GameObject[] Warning = new GameObject[4];
    public  bool[] isAble_Shape = new bool[4];
    int Direction;
    int Count = 0;

    // �ö�ְ� ����

    public GameObject flamingo;
    public GameObject thorn;
    public GameObject[] flaPos;
    public bool[] isAble_Flamingo;

    // ü�� �� ����

    public GameObject[] pawn;
    public GameObject Warning_Pawn;
    public Warning_Pawn WarnPawn;
    public Warning_Under_Pawn WarnUnderPawn;

    //��Ÿ �����͵�
    int m;
    float a;
    float phi;
    List<float> v = new List<float>();
    List<float> xx = new List<float>();
    bool isShape = false;

    // ȭ�� ũ��
    public GameObject cam;
    public float[] camZ;


    public GameObject NowyJoy;
    Title title;

    private void Awake()
    {  
        title = GameObject.Find("Trigger").GetComponent<Title>();
        target = GameObject.FindWithTag("Player");
        shapePos[0] = GameObject.Find("bulletPos_U");
        shapePos[1] = GameObject.Find("bulletPos_D");
        shapePos[2] = GameObject.Find("bulletPos_R");
        shapePos[3] = GameObject.Find("bulletPos_L");
        for(int i = 0; i < isAble_Shape.Length; i++)
        {
            isAble_Shape[i] = true;
        }
        ShapeInit();
        InitCamZ();
    }

    private void OnEnable()
    {

        StartCoroutine("Shooting");
        Invoke("DoPattern", 5f);
         DoPtn();
    }
    private void Update()
    {

        if(isPatterning)
        {
            shootSpeed_target = 2.5f;
        }
        else if(!isPatterning)
        {
            shootSpeed_target = 5f;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine("Flamingo");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
         //   NowyJoyCtrl();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine("PawnDrop");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Screen_Scale_Control();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            shapeShooting();
        }
        if(Count == 4)
        {
            for(int i = 0; i < isAble_Shape.Length; i++)
            {
                isAble_Shape[i] = true;
                isAble_Flamingo[i] = true;
            }
            Count = 0;
        }
    }

    void InitCamZ()
    {
        int index = 0;
        for (float i = 0.6f; i <= 1.2f; i += 0.05f)
        {
            camZ[index] = i * (-1);
            index++;
        }
    }
    public void DoPattern()
    {
        int index = Random.Range(0, 4);
        Debug.Log(index);
        /// 0 : �ö�ְ�
        /// 1 : ����
        /// 2 : 5����
        /// 3 : ��
        if(index == 0)
        {
            StartCoroutine("Flamingo");
        }
        else if(index == 1)
        {
            StartCoroutine("spin");
        }
        else if(index == 2)
        {
            shapeShooting();
        }
        else if(index == 3)
        {
            StartCoroutine("PawnDrop");
        }
       
       
    }
    
    public void DoPtn()
    {
        int[] randPos = new int[2];
        Transform[] ptnPos = new Transform[2];
        int[] randPtn = new int[8];

        do
        {
            randPos[0] = Random.Range(0, 4);
            randPos[1] = Random.Range(0, 4);
        }
        while (randPos[0] == randPos[1]);

        ptnPos[0] = PatternPos[randPos[0]];
        ptnPos[1] = PatternPos[randPos[1]];

        do
        {
            randPtn[0] = Random.Range(0, 8);
            randPtn[1] = Random.Range(0, 8);
        }
        while (randPtn[0] == randPtn[1]);


        switch (randPtn[0])
        {
            case 0:
                Screen_Scale_Control();
                break;

            case 1:
                StartCoroutine(test2(ptnPos[0]));
                break;

            case 2:
                StartCoroutine(test3(ptnPos[0]));
                break;

            case 3:
                StartCoroutine(test4(ptnPos[0]));
                break;

            case 4:
                StartCoroutine(test5(ptnPos[0]));
                break;

            case 5:
                StartCoroutine(test6(ptnPos[0]));
                break;

            case 6:
                StartCoroutine(test7(ptnPos[0]));
                break;

            case 7:
                StartCoroutine(test8(ptnPos[0]));
                break;
        }

        
        switch (randPtn[1])
        {
            case 0:
                Screen_Scale_Control();
                break;

            case 1:
                StartCoroutine(test2(ptnPos[1]));
                break;

            case 2:
                StartCoroutine(test3(ptnPos[1]));
                break;

            case 3:
                StartCoroutine(test4(ptnPos[1]));
                break;

            case 4:
                StartCoroutine(test5(ptnPos[1]));
                break;

            case 5:
                StartCoroutine(test6(ptnPos[1]));
                break;

            case 6:
                StartCoroutine(test7(ptnPos[1]));
                break;

            case 7:
                StartCoroutine(test8(ptnPos[1]));
                break;

        }
        Invoke("DoPtn", 10f);
    }

    IEnumerator test1(Transform pos)
    {
        testobj[0].transform.position = pos.position;
        testobj[0].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[0].SetActive(false);
    }

    IEnumerator test2(Transform pos)
    {
        testobj[1].transform.position = pos.position;
        testobj[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[1].SetActive(false);
    }

    IEnumerator test3(Transform pos)
    {
        testobj[2].transform.position = pos.position;
        testobj[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[2].SetActive(false);
    }

    IEnumerator test4(Transform pos)
    {
        testobj[3].transform.position = pos.position;
        testobj[3].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[3].SetActive(false);
    }

    IEnumerator test5(Transform pos)
    {
        testobj[4].transform.position = pos.position;
        testobj[4].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[4].SetActive(false);
    }
    IEnumerator test6(Transform pos)
    {
        testobj[5].transform.position = pos.position;
        testobj[5].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[5].SetActive(false);
    }

    IEnumerator test7(Transform pos)
    {
        testobj[6].transform.position = pos.position;
        testobj[6].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[6].SetActive(false);
    }

    IEnumerator test8(Transform pos)
    {
        testobj[7].transform.position = pos.position;
        testobj[7].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[7].SetActive(false);
    }

 

    public IEnumerator spin()
    {
       
            StartCoroutine("spinning");
            isPatterning = true;
        yield return new WaitForSeconds(2.5f);
            StopCoroutine("spinning");
              isPatterning = false;
             Invoke("DoPattern", 5f);
        
    }

    void ShapeInit()
    {
        //��ҵ��� ��� ���� �� ������ �ʱ�ȭ �ϱ����� Clear�Ѵ�.
        v.Clear();
        xx.Clear();

        //������ �ʱ�ȭ
        m = (int)Mathf.Floor(sup / 2);
        a = 2 * Mathf.Sin(Mathf.PI / Vertex);
        phi = ((Mathf.PI / 2f) * (Vertex - 2f)) / Vertex;
        v.Add(0);
        xx.Add(0);

        for (int i = 1; i <= m; i++)
        {
            //list.Insert(��ġ,���) -> �ش� ��ġ�� ���� ����ֽ��ϴ�.
            v.Add(Mathf.Sqrt(sup * sup - 2 * a * Mathf.Cos(phi) * i * sup + a * a * i * i));
        }

        for (int i = 1; i <= m; i++)
        {
            xx.Add(Mathf.Rad2Deg * (Mathf.Asin(a * Mathf.Sin(phi) * i / v[i])));
        }
    }

    public IEnumerator shapeShoot()
    {
       
        //rot���� ������ ���� �ʵ��� ������ dir���� �����Ͽ���.
        var dir = rot;

        while (true)
        {

            Direction = Random.Range(0, 4);

            if (isAble_Shape[Direction] == true)
                break;

        }

        isAble_Shape[Direction] = false;

     // Warning[Direction].transform.position = shapePos[Direction].transform.position;
        Warning[Direction].SetActive(true);
        yield return new WaitForSeconds(1.25f);
        Warning[Direction].SetActive(false);


        //������ �� ��ŭ ����
        for (int r = 0; r < Vertex; r++)
        {
            for (int i = 1; i <= m; i++)
            {
 
                #region //1�� ����
                //�Ѿ� ����
                GameObject idx1 = objManager.MakeObj("bulletC");

                //�Ѿ� ���� ��ġ�� (0,0) ��ǥ�� �Ѵ�.
                idx1.transform.position = shapePos[Direction].transform.position;
               

                //������ ȸ�� ó���� ����� ����� ����.
                idx1.transform.rotation = Quaternion.Euler(0, 0, dir + xx[i]);

                //������ �ӵ� ó���� ����� ����� ����.
                idx1.GetComponent<BulletC>().speed = v[i] * shootSpeed_Shape / sup;
                #endregion

                #region //2�� ����
                //�Ѿ� ����
                GameObject idx2 = objManager.MakeObj("bulletC");


               

                //�Ѿ� ���� ��ġ�� (0,0) ��ǥ�� �Ѵ�.
                idx2.transform.position = shapePos[Direction].transform.position;

                //������ ȸ�� ó���� ����� ����� ����.
                idx2.transform.rotation = Quaternion.Euler(0, 0, dir - xx[i]);

                //������ �ӵ� ó���� ����� ����� ����.
                idx2.GetComponent<BulletC>().speed = v[i] * shootSpeed_Shape / sup;
                #endregion

                #region //3�� ����
                //�Ѿ� ����
                GameObject idx3 = objManager.MakeObj("bulletC");


               

                //�Ѿ� ���� ��ġ�� (0,0) ��ǥ�� �Ѵ�.
                idx3.transform.position = shapePos[Direction].transform.position;

                //������ ȸ�� ó���� ����� ����� ����.
                idx3.transform.rotation = Quaternion.Euler(0, 0, dir);

                //������ �ӵ� ó���� ����� ����� ����.
                idx3.GetComponent<BulletC>().speed = shootSpeed_Shape;
                #endregion

                //����� �ϼ��Ѵ�.
                dir += 360 / Vertex;
            }
        }
        Count++;
    }

    public void shapeShooting()
    {
      
        StartCoroutine("shapeSht");

      
    }



    IEnumerator Shooting()
    {
        
        while (true)
        {
            int Direction = Random.Range(0, 4);
            float width = Random.Range(-5f, 5f);
            float height = Random.Range(-7f, 7f);

            if(Direction == 0)
            {
                bulletPos.transform.position = new Vector2(width, 6);
            }
            else if(Direction == 1)
            {
                bulletPos.transform.position = new Vector2(width, -6);
            }
            else if (Direction == 2)
            {
                bulletPos.transform.position = new Vector2(-3.5f, height);
            }
            else if (Direction == 3)
            {
                bulletPos.transform.position = new Vector2(3.5f, height);
            }

            GameObject bulletA = objManager.MakeObj("bulletA");
            bulletA.transform.position = bulletPos.transform.position;


            Rigidbody2D rigid = bulletA.GetComponent<Rigidbody2D>();
            Vector3 dir = target.transform.position - bulletA.transform.position;

            rigid.AddForce(dir.normalized * BulletAspeed, ForceMode2D.Impulse);

            yield return new WaitForSeconds(3f / shootSpeed_target);
        }
    }

    IEnumerator spinning()
    {
        while (true)
        {
          
            //�Ѿ� ����
            GameObject temp = objManager.MakeObj("bulletB");

            //�Ѿ� ���� ��ġ�� ���� �Ա��� �Ѵ�.
            temp.transform.position = Spin_ptn.transform.position;

            //�Ѿ��� ������ ������Ʈ�� �������� �Ѵ�.
            //->�ش� ������Ʈ�� ������Ʈ�� 360�� ȸ���ϰ� �����Ƿ�, Rotation�� ������ ��.
            temp.transform.rotation = Spin_ptn.transform.rotation;
            yield return new WaitForSeconds(1f / (shootSpeed_spin * 10));
        }
    }

    IEnumerator shapeSht()
    {
        isPatterning = true;
        int cnt = 0;
        while (cnt < 4)
        {
            StartCoroutine("shapeShoot");   
            yield return new WaitForSeconds(1.25f);
            cnt++;
        }
        isPatterning = false;
        Invoke("DoPattern", 5f);

    }
    public IEnumerator Flamingo()
    {
        int cnt = 0;
        isPatterning = true;
        while (cnt < 4)
        {
            while (true)
            {

                Direction = Random.Range(0, 4);

                if (isAble_Flamingo[Direction] == true)
                    break;

            }

            isAble_Flamingo[Direction] = false;

            Warning[Direction].SetActive(true);
            yield return new WaitForSeconds(1f);
            Warning[Direction].SetActive(false);

            flamingo.SetActive(true);
            thorn.SetActive(true);

            float randPosX = Random.Range(-0.75f, 0.75f);
            float randPosY = Random.Range(-3.2f, 3.2f);
            yield return new WaitForSeconds(0.1f);
            if (Direction == 0)
            {
                flamingo.transform.position = new Vector2(randPosX, flaPos[Direction].transform.position.y);
                flamingo.transform.rotation = Quaternion.Euler(0, 0, 180);
                yield return new WaitForSeconds(0.1f);
                iTween.MoveTo(flamingo, iTween.Hash("y", -5.5f, "time", 3.5f, "easeType", "Linear"));
            }
            else if (Direction == 1)
            {
                flamingo.transform.position = new Vector2(randPosX, flaPos[Direction].transform.position.y);
                flamingo.transform.rotation = Quaternion.Euler(0, 0, 0);
                yield return new WaitForSeconds(0.1f);
                iTween.MoveTo(flamingo, iTween.Hash("y", 5.5f, "time", 3.5f, "easeType", "Linear"));
            }
            else if (Direction == 2)
            {
                flamingo.transform.position = new Vector2(flaPos[Direction].transform.position.x, randPosY);
                flamingo.transform.rotation = Quaternion.Euler(0, 0, 90);
                yield return new WaitForSeconds(0.1f);
                iTween.MoveTo(flamingo, iTween.Hash("x", -3.5f, "time", 3.5f, "easeType", "Linear"));
            }
            else if (Direction == 3)
            {
                flamingo.transform.position = new Vector2(flaPos[Direction].transform.position.x, randPosY);
                flamingo.transform.rotation = Quaternion.Euler(0, 0, -90);
                yield return new WaitForSeconds(0.1f);
                iTween.MoveTo(flamingo, iTween.Hash("x", 3.5f, "time", 3.5f, "easeType", "Linear"));
            }
            Count++;
            cnt++;
            yield return new WaitForSeconds(3.5f);
            flamingo.SetActive(false);
            thorn.SetActive(false);

        }
        isPatterning = false;
        Invoke("DoPattern", 5f);
    }

    IEnumerator PawnDrop()
    {
        isPatterning = true;
        int cnt = 0;
        while(cnt < 3)
        {
            float PosX = Random.Range(-2f, 2f);
            float PosY = Random.Range(3.5f, -4f);
            pawn[cnt].transform.position = new Vector2(PosX, 6);
            WarnPawn.target = pawn[cnt];
            Warning_Pawn.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            Warning_Pawn.gameObject.SetActive(false);
    
            iTween.MoveTo(pawn[cnt], iTween.Hash("y", PosY, "time", 1.5f, "easeType", "EaseOutBounce")); // �� ���
            cnt++;
            if (cnt == 3)
                break;
            yield return new WaitForSeconds(1.75f); // ���� �� ������ �ð�
        }
        yield return new WaitForSeconds(1.5f); // ���� ��� �ð�

        int direction = Random.Range(0, 2);

        if(direction == 0)
        {
            for (int i = 0; i < 3; i++)
                WarnUnderPawn.Warning_UI[i].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(direction == 1)
        {
            for (int i = 0; i < 3; i++)
                WarnUnderPawn.Warning_UI[i].transform.rotation = Quaternion.Euler(0, 0, 180);
        }


        for (int i = 0; i < 3; i++)
            WarnUnderPawn.Warning_UI[i].SetActive(true);

        yield return new WaitForSeconds(1.5f); // ���â ���� �ð�

        for (int i = 0; i < 3; i++)
            WarnUnderPawn.Warning_UI[i].SetActive(false);



        int dir = direction == 0 ? 1 : -1;
      
            for (int i =0; i<3; i++)
            {
                iTween.MoveTo(pawn[i], iTween.Hash("x",  4 * dir, "time", 1.5f, "easeType", "EaseInOutBack")); // �� ����
            }
        yield return new WaitForSeconds(1.5f); 
        isPatterning = false;

        Invoke("DoPattern", 5f);


    }

    void Screen_Scale_Control()
    {
        int randSSC = Random.Range(0, 12);
        //   cam.transform.position = new Vector3(0,0,camZ[randSSC]);

        iTween.MoveTo(cam, iTween.Hash("z", camZ[randSSC], "time", 0.5f, "easeType", "Linear"));
        Invoke("Screen_Scale_Init", 4f);
    }
    void Screen_Scale_Init()
    {
        iTween.MoveTo(cam, iTween.Hash("z", -1, "time", 0.5f, "easeType", "Linear"));
    }
}
