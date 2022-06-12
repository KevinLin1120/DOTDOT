using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdDotManMove : MonoBehaviour
{

    [SerializeField] private LayerMask borderdownLayerMask;

    private Animator DotManAnim; //動畫物件
    private Rigidbody2D rigidbody2d; //DotMan腳色組件
    private BoxCollider2D boxCollider2d;
    public GameState gameState;
    

    
    private void Start()
    {
        DotManAnim = GameObject.Find("DotMan").GetComponent<Animator>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
         boxCollider2d = transform.GetComponent<BoxCollider2D>();
       
    }
  
    private void Update()
    {
       if(IsGrounded() && Input.GetKey(KeyCode.Space)) 
        {
           float jumpVelocity = 100f;
           rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        // DotManAnim.SetFloat("vSpeed",v.y); //設定Vector2的值為("vSpeed",v.y,)
        // DotManAnim.SetFloat("hSpeed",v.x); //設定Vector2的值為("hSpeed",Mathf.Abs(v.x)) note:Mathf.Abs()取絕對值 左右移動是有負值
        // // DotDotMan.Move(v*Time.deltaTime); //每秒的移動
        // DotDotMan.velocity = v * Time.deltaTime;

        
    }

    private void FixedUpdate()
    {
       float moveSpeed = 40f;
       rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
       if(Input.GetKey(KeyCode.RightArrow)) 
        {
           rigidbody2d.velocity =new Vector2(+moveSpeed, rigidbody2d.velocity.y);
        }
        else
        {
           rigidbody2d.velocity =new Vector2(0, rigidbody2d.velocity.y);
        //    rigidbody2d.constraints =RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        
    }



    private bool IsGrounded() {


        // return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
        float extraHeightText = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast( boxCollider2d.bounds.center,boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, borderdownLayerMask); 
        Color rayColor;
        if (raycastHit.collider != null){
            Debug.Log(raycastHit.collider);
            rayColor = Color.green;
        }else{
            rayColor = Color.red;
        }
        Debug.DrawRay( boxCollider2d.bounds.center+new Vector3(boxCollider2d.bounds.extents.x,0), Vector2.down * ( boxCollider2d.bounds.extents.y + extraHeightText) ,rayColor);
        Debug.DrawRay( boxCollider2d.bounds.center+new Vector3(boxCollider2d.bounds.extents.x,0), Vector2.down * ( boxCollider2d.bounds.extents.y + extraHeightText),rayColor); 
        Debug.DrawRay( boxCollider2d.bounds.center+new Vector3(boxCollider2d.bounds.extents.x, boxCollider2d.bounds.extents.y + extraHeightText), Vector2.right * ( boxCollider2d.bounds.extents.x + extraHeightText),rayColor);  
        // Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    private void PlayAnimations(bool isGrounded){
        
        
        
        //根據不同狀態設置Animator參數來切換狀態
        switch (gameState)
        {
            case GameState.runRight:
                DotManAnim.SetBool("ReadyToRun",true);
                DotManAnim.SetBool("RunToJump",false);
                break;
            case GameState.readyJump:
            case GameState.jumpRight:
                DotManAnim.SetBool("ReadyToJump",true);
                DotManAnim.SetBool("RunToJump",true);
                break;  
            default:
               DotManAnim.SetBool("ReadyToRun",false);
                DotManAnim.SetBool("ReadyToJump",false);
                break;  
        }

    }

}



























// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ThirdDotManMove : MonoBehaviour
// {
//     public float runSpeed = 200; //奔跑速度
//     public float jumpSpeed = 100; //跳躍速度
//     public float gravity = 0; //重力
//     private Vector3 v; //儲存速度
//     // private bool facingRight = false; //儲存的方向
//     private Animator DotManAnim; //動畫物件
//     private Rigidbody2D DotDotMan; //DotMan腳色組件
//     bool Grounded = false ;

    
//     void Start()
//     {
//         DotManAnim = GameObject.Find("DotMan").GetComponent<Animator>();
//         DotDotMan = GameObject.Find("DotMan").GetComponent<Rigidbody2D>(); //取得DotDotMan角色控制器
       
//     }

//     private void OnTriggerStay2D(Collider2D collision)
//     {
//         if(collision.gameObject.tag == "borderdown")
//         {
//            Grounded = true;
//            Debug.Log("1123");
//         }
//     }

    
//     void Update()
//     {
//         movement();

//         DotManAnim.SetFloat("vSpeed",v.y); //設定Vector2的值為("vSpeed",v.y,)
//         DotManAnim.SetFloat("hSpeed",v.x); //設定Vector2的值為("hSpeed",Mathf.Abs(v.x)) note:Mathf.Abs()取絕對值 左右移動是有負值
//         // DotDotMan.Move(v*Time.deltaTime); //每秒的移動
//         DotDotMan.velocity = v * Time.deltaTime;

        
//     }

//     private void movement()
//     {
//         if(Grounded = true) //在地面上
//         {
//             DotManAnim.SetBool("isGround" , true); //開啟動畫條件 isGround = true
//             //在地面,右移動,跳躍,靜止
//             if(Input.GetKey(KeyCode.RightArrow)) //向右走的按鍵被按下時
//             {
//                 if(Input.GetKey(KeyCode.Space)) //當空白鍵也觸發跳躍時
//                 {
//                     v = new Vector3(runSpeed,jumpSpeed,0); //設定腳色的移動速度是需要包含向上跳躍的力道
//                 }
//                 else //如果沒有跳躍
//                 {
//                     v = Vector3.right* runSpeed; //移動只需要往右並且帶上水平的移動速度
//                     // v = new Vector2(runSpeed,0);
//                 }
//             }
//             else if(Input.GetKey(KeyCode.Space)) //只有按下空白鍵
//             {
//                 v = Vector3.up*jumpSpeed;//成上垂直的力量
//                 //  v = new Vector2(0,jumpSpeed);
//             }
//             else 
//             {
//                 v = Vector3.zero; //歸零 不動
//                 //  v = new Vector2(0,0);
//             }
//         }
//         else
//         {
//             v.y -= gravity; //y值為 -gravity
//             DotManAnim.SetBool("isGround",false); //設定isGround的動畫條件為false
//         }
//     }

// }
//////////////////////////////////////////原本

//  void Update()
//     {
//         if(DotDotMan.Grounded) //在地面上
//         {
//             DotMan1Anim.SetBool("Grounded" , true); //開啟動畫條件 Grounded = true
//             //在地面,右移動,跳躍,靜止
//             if(Input.GetKey(KeyCode.RightArrow)) //向右走的按鍵被按下時
//             {
//                 if(Input.GetKey(KeyCode.Space)) //當空白鍵也觸發跳躍時
//                 {
//                     v = new Vector3(runSpeed,jumpSpeed,0); //設定腳色的移動速度是需要包含向上跳躍的力道
//                 }
//                 else //如果沒有跳躍
//                 {
//                     v = Vector3.right* runSpeed; //移動只需要往右並且帶上水平的移動速度Vector3(1,0,0)
//                 }
//             }
//             else if(Input.GetKey(KeyCode.Space)) //只有按下空白鍵
//             {
//                 v = Vector3.up*jumpSpeed;//Vector3(0,1,0) 成上  垂直的力量
//             }
//             else 
//             {
//                 v = Vector3.zero; //歸零Vector3(0,0,0) 不動
//             }
//         }
//         else
//         {
//             v.y -= gravity; //y值為 -gravity
//             DotMan1Anim.SetBool("Grounded",false); //設定Grounded的動畫條件為false
//         }
//         DotMan1Anim.SetFloat("vSpeed",v.y); //設定Vector3的值為("vSpeed",v.y,0)
//         DotMan1Anim.SetFloat("hSpeed",Mathf.Abs(v.x)); //設定Vector3的值為("hSpeed",Mathf.Abs(v.x),0) note:Mathf.Abs()取絕對值 左右移動是有負值
//         // DotDotMan.Move(v*Time.deltaTime); //每秒的移動
//         DotDotMan.velocity = v * Time.deltaTime;

        
//     }

// }


///////
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     Rigidbody2D playerRigidbody2D;

//     [Header("目前的水平速度")]
//     public float speedX;

//     [Header("目前的水平方向")]
//     public float horizontalDirection;//數值會在 -1~1之間

//     const string HORIZONTAL = "Horizontal";

//     [Header("水平推力")]
//     [Range(0, 150)]
//     public float xForce;

//     //目前垂直速度
//     float speedY;

//     [Header("最大水平速度")]
//     public float maxSpeedX;

//     [Header("垂直向上推力")]
//     public float yForce;

//     [Header("感應地板的距離")]
//     [Range(0, 0.5f)]
//     public float distance;

//     [Header("偵測地板的射線起點")]
//     public Transform groundCheck;

//     [Header("地面圖層")]
//     public LayerMask groundLayer;

//     public bool grounded;

//     public void ControlSpeed()
//     {
//         speedX = playerRigidbody2D.velocity.x;
//         speedY = playerRigidbody2D.velocity.y;
//         float newSpeedX = Mathf.Clamp(speedX, -maxSpeedX, maxSpeedX);
//         playerRigidbody2D.velocity = new Vector2(newSpeedX, speedY);
//     }

//     public bool JumpKey
//     {
//         get
//         {
//             return Input.GetKeyDown(KeyCode.Space);
//         }
//     }

//     void TryJump()
//     {
//         if (IsGround && JumpKey)
//         {
//             playerRigidbody2D.AddForce(Vector2.up * yForce);
//         }
//     }

//     //在玩家的底部射一條很短的射線 如果射線有打到地板圖層的話 代表正在踩著地板
//     bool IsGround
//     {
//         get
//         {
//             Vector2 start = groundCheck.position;
//             Vector2 end = new Vector2(start.x, start.y - distance);

//             Debug.DrawLine(start, end, Color.blue);
//             grounded = Physics2D.Linecast(start, end, groundLayer);
//             return grounded;
//         }
//     }

//     void Start()
//     {
//         playerRigidbody2D = GetComponent<Rigidbody2D>();
//     }

//     /// <summary>水平移動</summary>
//     void MovementX()
//     {
//         horizontalDirection = Input.GetAxis(HORIZONTAL);
//         playerRigidbody2D.AddForce(new Vector2(xForce * horizontalDirection, 0));
//     }

//     void Update()
//     {
//         MovementX();
//         ControlSpeed();
//         TryJump();
//         //speedX = playerRigidbody2D.velocity.x;
//     }
// }
