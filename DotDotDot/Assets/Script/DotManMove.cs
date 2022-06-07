using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotManMove : MonoBehaviour
{
    public GameManager gameManager;
    public float moveSpeed = 3; //速度
    private Vector3 v;
    private bool facingRight = false; //儲存DotMan的方向
    private Animator DotMan1Anim; //DotMan動畫物件
    private Rigidbody2D DotDotMan; //DotMan腳色組件

    public float minPosX = -8.62f;
    public float maxPosX = 8.18f;
    public float minPosY = -4.27f;
    public float maxPosY = 2.26f;
    // private Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        DotMan1Anim = GameObject.Find("DotMan").GetComponent<Animator>();
        DotDotMan = GameObject.Find("DotMan").GetComponent<Rigidbody2D>(); //取得DotDotMan角色控制器
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) //向右走的按鍵被按下時
        {
            v = Vector3.right * moveSpeed; //移動只需要往右並且帶上水平的移動速度Vector3(1,0,0)
                                           // newPos =(Mathf.Clamp( v*Time.deltaTime, minPosX, maxPosX),0,0);
                                           // newPos =(Mathf.Clamp(DotDotMan.X + (moveSpeed*Time.deltaTime), minPosX, maxPosX), DotDotMan.Y, DotDotMan.Z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //向左走的按鍵被按下時
        {
            v = Vector3.left * moveSpeed; //Vector3(-1,0,0)
        }
        else if (Input.GetKey(KeyCode.UpArrow)) //向上走的按鍵被按下時
        {
            v = Vector3.up * moveSpeed; //Vector3(-1,0,0)
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //向下走的按鍵被按下時
        {
            v = Vector3.down * moveSpeed; //Vector3(-1,0,0)
        }
        else
        {
            v = Vector3.zero; //歸零Vector3(0,0,0) 不動
        }


        DotDotMan.velocity = v * Time.deltaTime;
        // DotDotMan.Move(newPos); //每秒的移動

        if (!facingRight && v.x > 0) //當facingRight為false且面向右邊
        {
            TrunAround();
        }
        else if (facingRight && v.x < 0) //當facingRight為true且面向左邊
        {
            TrunAround();
        }

        //新的座標
        // Vector3 newPos = new Vector3 (Mathf.Clamp(transform.position.x + (moveSpeed*Time.deltaTime), minPosX, maxPosX), transform.position.y, transform.position.z);

        // //把座標設為新的座標
        // transform.position = newPos;
    }

    private void TrunAround() //改變轉向(向左或向右)
    {
        facingRight = !facingRight; //設定facingRight = flase
        Vector3 scale = DotDotMan.transform.localScale; //取得物件尺寸
        scale.x *= -1; //將x設為-1 (-1,0,0)
        DotDotMan.transform.localScale = scale; //傳回轉向值
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            gameManager.triggerBall(collision);
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DotManMove : MonoBehaviour
//{

//    public float moveSpeed = 3; //速度
//     private Vector3 v;
//    private bool facingRight = false; //儲存DotMan的方向
//    private Animator DotMan1Anim; //DotMan動畫物件
//    //===========
//    //private CharacterController DotDotMan; //DotMan腳色組件
//    private CapsuleCollider2D DotDotMan; //DotMan腳色組件

//    public float minPosX = -8.62f;
//    public float maxPosX = 8.18f;
//    public float minPosY = -4.27f;
//    public float maxPosY = 2.26f;
//    // private Vector3 newPos;
//    // Start is called before the first frame update
//    void Start()
//    {
//        DotMan1Anim = GameObject.Find("DotMan").GetComponent<Animator>();
//        //=============
//        //DotDotMan = GameObject.Find("DotMan").GetComponent<CharacterController>(); //取得DotDotMan角色控制器
//        DotDotMan = GameObject.Find("DotMan").GetComponent<CapsuleCollider2D>(); //取得DotDotMan角色控制器
//    }

//    // Update is called once per frame
//    void Update()
//    { 
//            if(Input.GetKey(KeyCode.RightArrow)) //向右走的按鍵被按下時
//            {
//                v = Vector3.right* moveSpeed; //移動只需要往右並且帶上水平的移動速度Vector3(1,0,0)
//                // newPos =(Mathf.Clamp( v*Time.deltaTime, minPosX, maxPosX),0,0);
//                // newPos =(Mathf.Clamp(DotDotMan.X + (moveSpeed*Time.deltaTime), minPosX, maxPosX), DotDotMan.Y, DotDotMan.Z);
//            }
//            else if(Input.GetKey(KeyCode.LeftArrow)) //向左走的按鍵被按下時
//            {
//                v = Vector3.left* moveSpeed; //Vector3(-1,0,0)
//            }
//            else if(Input.GetKey(KeyCode.UpArrow)) //向上走的按鍵被按下時
//            {
//                v = Vector3.up* moveSpeed; //Vector3(-1,0,0)
//            }
//            else if(Input.GetKey(KeyCode.DownArrow)) //向下走的按鍵被按下時
//            {
//                v = Vector3.down* moveSpeed; //Vector3(-1,0,0)
//            }
//            else 
//            {
//                v = Vector3.zero; //歸零Vector3(0,0,0) 不動
//            }

//        //==========
//        //DotDotMan.Move(v*Time.deltaTime); //每秒的移動
//        DotDotMan. += v * Time.deltaTime;
//        // DotDotMan.Move(newPos); //每秒的移動

//        if (!facingRight && v.x>0) //當facingRight為false且面向右邊
//        {
//            TrunAround();
//        }
//        else if(facingRight && v.x<0) //當facingRight為true且面向左邊
//        {
//            TrunAround();
//        }

//        //新的座標
//        // Vector3 newPos = new Vector3 (Mathf.Clamp(transform.position.x + (moveSpeed*Time.deltaTime), minPosX, maxPosX), transform.position.y, transform.position.z);

//        // //把座標設為新的座標
//		// transform.position = newPos;
//    }

//    private void TrunAround() //改變轉向(向左或向右)
//    {
//        facingRight = ! facingRight; //設定facingRight = flase
//        Vector3 scale =DotDotMan.transform.localScale; //取得物件尺寸
//        scale.x*=-1; //將x設為-1 (-1,0,0)
//        DotDotMan.transform.localScale = scale; //傳回轉向值
//    }
//}
