using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    public float RunSpeed;
    public float RunAnimationSpeed = 2f;
    private bool isRunning;
    public GameManager manager;

    Rigidbody2D rigid;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;

    //////����/////

    public float DreamGauge;
    public GameObject[] Equipments;
    public bool[] hasEquip; // 0.������Ǯ 1.���� 2.å 3.�к�
    GameObject equipEquipment;
    GameObject nearObject;
    int equipEquipmentIndex = -1;
    bool sDown1;
    bool sDown2;
    bool sDown3;
    bool sDown4;
    bool iDown;
    public item equip; //���� ������ 



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    /*void GetInput()
    {
        sDown1 = Input.GetButtonUp("Swap1");
        sDown2 = Input.GetButtonUp("Swap2");
        sDown3 = Input.GetButtonUp("Swap3");
        sDown4 = Input.GetButtonUp("Swap4");
    }*/
    // Update is called once per frame
    void Update()
    {
        //GetInput();
        //Swap();
        // move value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool shiftDown = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);       //
        bool shiftUp = Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift);

        //Check button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        iDown = Input.GetButtonDown("interaction");
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
        sDown4 = Input.GetButtonDown("Swap4");

        if (sDown1 == true)
            Debug.Log("!!");

        // Check Horizontal Move

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        // Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);

        // Direction
        if (vDown && v == 1)
        {
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
        }

        if (shiftDown)      //
        {
            isRunning = true;
            anim.SetBool("isChange", true);
            anim.SetBool("isRun", true);
            anim.speed = RunAnimationSpeed;
        }
        else if (shiftUp)
        {
            isRunning = false;
            anim.SetBool("isChange", true);
            anim.SetBool("isRun", false);
            anim.speed = 1f;
        }

        // Scan Object
        if (Input.GetKey(KeyCode.E) && scanObject != null && scanObject.CompareTag("GoToOutDoor"))
        {
            //Debug.Log("This is :" + scanObject.name);
            this.transform.position = new Vector3(0, -46, 0);
            //manager.Action(scanObject);
        }

        if (Input.GetKey(KeyCode.E) && scanObject != null && scanObject.CompareTag("GoToInsideDoor"))
        {
            //Debug.Log("This is :" + scanObject.name);
            this.transform.position = new Vector3(-6, -9, 0);
            //manager.Action(scanObject);


        }

        //Swap �Լ�
        if (sDown1 && (!hasEquip[0] || equipEquipmentIndex == 0)) return;
        if (sDown2 && (!hasEquip[1] || equipEquipmentIndex == 1)) return;
        if (sDown3 && (!hasEquip[2] || equipEquipmentIndex == 2)) return;
        if (sDown4 && (!hasEquip[3] || equipEquipmentIndex == 3)) return;


        int EquipIndex = -1;
        if (sDown1)
        {
            EquipIndex = 0;
            Debug.Log("sDown1");
        }
        if (sDown2) EquipIndex = 1;
        if (sDown3) EquipIndex = 2;
        if (sDown4) EquipIndex = 3;

        if (sDown1 || sDown2 || sDown3 || sDown4)
        {
            if (equipEquipment != null)
                equipEquipment.SetActive(false);
            Debug.Log("equipEquipmentIndex");
            equipEquipmentIndex = EquipIndex;
            equipEquipment = Equipments[EquipIndex];
            equipEquipment.SetActive(true);
        }

        if (iDown && scanObject != null && !scanObject.CompareTag("GoToInsideDoor") && !scanObject.CompareTag("GoToOutDoor"))
            //manager.Action(scanObject);

        //interaction �Լ�

        if (iDown && nearObject != null)
        {
            if (nearObject.tag == "SnailGrass")
            {
                hasEquip[0] = true;
                Debug.Log("������ Ǯ�� �����!");
                Destroy(nearObject);
            }
            else if (nearObject.tag == "key")
            {
                hasEquip[1] = true;
                Debug.Log("���踦 �����!");
                Destroy(nearObject);
            }
            else if (nearObject.tag == "book")
            {
                hasEquip[2] = true;
                Debug.Log("å�� �����!");
                Destroy(nearObject);
            }
            else if (nearObject.tag == "candle")
            {
                hasEquip[3] = true;
                Debug.Log("�ʸ� �����!");
                Destroy(nearObject);
            }


        }

    }

    void FixedUpdate()
    {
        // Move
        float currentSpeed = isRunning ? RunSpeed : Speed;
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * currentSpeed;

        // Ray
        Debug.DrawRay(rigid.position, dirVec * 1.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
    /*void Swap()
    {
        
        if (sDown1 && (!hasEquip[0] || equipEquipmentIndex == 0)) return;
        if (sDown2 && (!hasEquip[1] || equipEquipmentIndex == 1)) return;
        if (sDown3 && (!hasEquip[2] || equipEquipmentIndex == 2)) return;
        if (sDown4 && (!hasEquip[3] || equipEquipmentIndex == 3)) return;


        int EquipIndex = -1;
        if (sDown1) { EquipIndex = 0;
            Debug.Log("sDown1");
        }
        if (sDown2) EquipIndex = 1;
        if (sDown3) EquipIndex = 2;
        if (sDown4) EquipIndex = 3;

        if (sDown1||sDown2||sDown3||sDown4)
        {
            if(equipEquipment != null)
                equipEquipment.SetActive(false);
            Debug.Log("equipEquipmentIndex");
            equipEquipmentIndex = EquipIndex;
            equipEquipment = Equipments[EquipIndex];
            equipEquipment.SetActive(true);
        }

    }*/
    void OnTriggerStay2D(Collider2D collision) /////�浹 üũ ���� �ذ�
    {

        if (collision.CompareTag("SnailGrass"))
        {
            nearObject = collision.gameObject;
            Debug.Log("Snail");
            Debug.Log(nearObject.tag);
        }
        if (collision.CompareTag("key"))
        {
            nearObject = collision.gameObject;
            Debug.Log("key");
            Debug.Log(nearObject.tag);
        }
        if (collision.CompareTag("book"))
        {
            nearObject = collision.gameObject;
            Debug.Log("book");
            Debug.Log(nearObject.tag);
        }
        if (collision.CompareTag("candle"))
        {
            nearObject = collision.gameObject;
            Debug.Log("candle");
            Debug.Log(nearObject.tag);
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Equipment")
            nearObject = null;
    }

}
