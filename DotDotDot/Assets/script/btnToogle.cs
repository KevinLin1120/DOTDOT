using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnToogle : MonoBehaviour
{
    private bool isClick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ref: https://jingyan.baidu.com/article/0bc808fc385a911bd485b91a.html

    void OnClick(){
        if(!isClick){
            this.GetComponent<Sprite>().name = "按鈕2";
            isClick = true;
            System.Console.WriteLine("click");
        }
        else{
            this.GetComponent<Sprite>().name = "按鈕1";
            isClick = false;
        }
    }
}
