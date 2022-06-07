using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

public class GameManager : MonoBehaviour
{
    public GameObject LBall, RBall, AnsBall; //Balls in nav
    public GameObject[] balls; //red ora yel gre blu pur whi
    public Sprite[] ans;
    private bool isSetL = false, isSetR = false; //L/R ball's statements

    // Start is called before the first frame update
    void Start()
    {
        //AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/BirdHeroSprite.png");
        //spriteHandle.Completed += LoadSpritesWhenReady;
        LBall.GetComponent<SpriteRenderer>().color = new Color32(60, 60, 60, 255);
        RBall.GetComponent<SpriteRenderer>().color = new Color32(60, 60, 60, 255);
        AnsBall.GetComponent<SpriteRenderer>().sprite =
            ans[Random.Range(0, ans.Length)];
        //AnsBall.GetComponent<SpriteRenderer>().sprite =
        //    balls[Random.Range(0, balls.Length)].GetComponent<SpriteRenderer>().sprite;
        //AnsBall.GetComponent<SpriteRenderer>().sprite =
        //    newSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When dot man hit the color ball
    public void triggerBall(Collider2D ball)
    {
        //Debug.Log(ball.gameObject.GetComponent<SpriteRenderer>().sprite.name);
        if(ball.gameObject.GetComponent<SpriteRenderer>().sprite.name == "w")
        {
            RBall.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            LBall.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            if (isSetL)
            {
                RBall.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                RBall.GetComponent<SpriteRenderer>().sprite =
                    ball.gameObject.GetComponent<SpriteRenderer>().sprite;
                isSetR = true;
            }
            else
            {
                LBall.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                LBall.GetComponent<SpriteRenderer>().sprite =
                    ball.gameObject.GetComponent<SpriteRenderer>().sprite;
                isSetL = true;
            }
        }
    }
    public void hitFan()
    {

    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

//public class GameManager : MonoBehaviour
//{
//    public GameObject LBall, RBall, AnsBall; //Balls in nav
//    public GameObject[] balls; //red ora yel gre blu pur whi
//    public Sprite[] spriteArray;

//    // Start is called before the first frame update
//    void Start()
//    {
//        AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/關卡一/紫色球.png");
//        spriteHandle.Completed += LoadSpritesWhenReady;
//        spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/關卡一/綠色球.png");
//        spriteHandle.Completed += LoadSpritesWhenReady;

//        LBall.GetComponent<SpriteRenderer>().color = new Color32(60, 60, 60, 255);
//        RBall.GetComponent<SpriteRenderer>().color = new Color32(60, 60, 60, 255);
//        System.Console.WriteLine(spriteArray.Length);
//        AnsBall.GetComponent<SpriteRenderer>().sprite =
//            spriteArray[Random.Range(0, spriteArray.Length)];
//        //AnsBall.GetComponent<SpriteRenderer>().sprite =
//        //    newSprite;
//    }
//    void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
//    {
//        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
//        {
//            spriteArray = handleToCheck.Result;
//        }
//    }
//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
