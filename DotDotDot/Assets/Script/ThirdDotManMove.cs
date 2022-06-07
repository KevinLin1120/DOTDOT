using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdDotManMove : MonoBehaviour
{
    public float runSpeed = 7; //奔跑速度
    public float jumpSpeed = 23; //跳躍速度
    public float gravity = 2; //重力
    private Vector3 v; //儲存速度
    // private bool facingRight = false; //儲存的方向
    private Animator DotMan1Anim; //動畫物件
    // private CharacterController DotDotMan; //DotMan腳色組件
    private Rigidbody2D DotDotMan; //DotMan腳色組件
    // var disToGround: float;

    // Start is called before the first frame update
    void Start()
    {
        DotMan1Anim = GameObject.Find("DotMan").GetComponent<Animator>();
        DotDotMan = GameObject.Find("DotMan").GetComponent<Rigidbody2D>(); //取得DotDotMan角色控制器
        // disToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // void  OnCollisionStay2D(Collision2D collider) {
    //     CheckIfGround();
    // }

    // void  OnCollisionExit2D(Collision2D collider) {
    //    isGround = false;
    // }

    // private void CheckIfGround()
    // {

    // }

    // function IsGrounded():boolean{
    //     return Physics.Raycast(transform.position,)
    // }

    // Update is called once per frame
    void Update()
    {
        // if(DotDotMan.isGround) //在地面上
        // {
            DotMan1Anim.SetBool("isGround" , true); //開啟動畫條件 isGround = true
            //在地面,右移動,跳躍,靜止
            if(Input.GetKey(KeyCode.RightArrow)) //向右走的按鍵被按下時
            {
                if(Input.GetKey(KeyCode.Space)) //當空白鍵也觸發跳躍時
                {
                    v = new Vector3(runSpeed,jumpSpeed,0); //設定腳色的移動速度是需要包含向上跳躍的力道
                }
                else //如果沒有跳躍
                {
                    v = Vector3.right* runSpeed; //移動只需要往右並且帶上水平的移動速度Vector3(1,0,0)
                }
            }
            else if(Input.GetKey(KeyCode.Space)) //只有按下空白鍵
            {
                v = Vector3.up*jumpSpeed;//Vector3(0,1,0) 成上  垂直的力量
            }
            else 
            {
                v = Vector3.zero; //歸零Vector3(0,0,0) 不動
            }
        // }
        // else
        // {
        //     v.y -= gravity; //y值為 -gravity
        //     DotMan1Anim.SetBool("isGround",false); //設定isGround的動畫條件為false
        // }
        // DotMan1Anim.SetFloat("vSpeed",v.y); //設定Vector3的值為("vSpeed",v.y,0)
        // DotMan1Anim.SetFloat("hSpeed",Mathf.Abs(v.x)); //設定Vector3的值為("hSpeed",Mathf.Abs(v.x),0) note:Mathf.Abs()取絕對值 左右移動是有負值
        // // DotDotMan.Move(v*Time.deltaTime); //每秒的移動
        // DotDotMan.velocity = v * Time.deltaTime;

        
    }

}


//  void Update()
//     {
//         if(DotDotMan.isGround) //在地面上
//         {
//             DotMan1Anim.SetBool("isGround" , true); //開啟動畫條件 isGround = true
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
//             DotMan1Anim.SetBool("isGround",false); //設定isGround的動畫條件為false
//         }
//         DotMan1Anim.SetFloat("vSpeed",v.y); //設定Vector3的值為("vSpeed",v.y,0)
//         DotMan1Anim.SetFloat("hSpeed",Mathf.Abs(v.x)); //設定Vector3的值為("hSpeed",Mathf.Abs(v.x),0) note:Mathf.Abs()取絕對值 左右移動是有負值
//         // DotDotMan.Move(v*Time.deltaTime); //每秒的移動
//         DotDotMan.velocity = v * Time.deltaTime;

        
//     }

// }

