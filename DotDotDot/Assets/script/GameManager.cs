using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

public class GameManager : MonoBehaviour
{
    public GameObject LBall, RBall, AnsBall; //Balls in nav
    public GameObject wrongAns;
    public GameObject[] gameBalls;
    public GameObject fruits;
    public GameObject[] fanAnim;
    public Sprite[] balls; //red ora yel gre blu pur blgr whi
    private int[] ansColor = {3, 5, 6};
    private bool isSetL = false; //L ball's statements

    //public GameObject toggle;
    public Sprite[] btns; //On Off

    // Start is called before the first frame update
    void Start()
    {
        //Initial L/R ball
        resetLRBall();
        AnsBall.GetComponent<SpriteRenderer>().sprite =
            balls[ansColor[Random.Range(0, ansColor.Length)]];
    }

    // Update is called once per frame
    void Update()
    {
        //if(isLose) resetLRBall();
    }

    //When dot man hit the color ball
    public void triggerBall(Collider2D ball)
    {
        //Debug.Log(ball.gameObject.GetComponent<SpriteRenderer>().sprite.name);
        if(ball.gameObject.GetComponent<SpriteRenderer>().sprite.name == "白色球")
        {
            resetLRBall();
        }
        else
        {
            if (!isSetL)
            {
                LBall.GetComponent<SpriteRenderer>().sprite =
                    ball.gameObject.GetComponent<SpriteRenderer>().sprite;
                isSetL = true;
                
            }
            else
            {
                RBall.GetComponent<SpriteRenderer>().sprite =
                    ball.gameObject.GetComponent<SpriteRenderer>().sprite;

                switch (AnsBall.GetComponent<SpriteRenderer>().sprite.name)
                {
                    case "綠色球":
                        if ((LBall.GetComponent<SpriteRenderer>().sprite.name == "藍色球" &&
                            RBall.GetComponent<SpriteRenderer>().sprite.name == "黃色球") ||
                            (LBall.GetComponent<SpriteRenderer>().sprite.name == "黃色球" &&
                            RBall.GetComponent<SpriteRenderer>().sprite.name == "藍色球"))
                        {
                            Debug.Log("You Win!");
                        }
                        else
                        {
                            Debug.Log("Enable");
                            wrongAns.SetActive(true);
                            StartCoroutine(resetStatus(1));
                            //ExecuteAfterTime(1000);
                            Debug.Log("You Lose!");
                        }
                        break;
                    case "紫色球":
                        if ((LBall.GetComponent<SpriteRenderer>().sprite.name == "藍色球" &&
                            RBall.GetComponent<SpriteRenderer>().sprite.name == "紅色球") ||
                            (LBall.GetComponent<SpriteRenderer>().sprite.name == "紅色球" &&
                            RBall.GetComponent<SpriteRenderer>().sprite.name == "藍色球"))
                        {
                            Debug.Log("You Win!");
                        }
                        else
                        {
                            StartCoroutine(resetStatus(1));
                            //wrongAns.SetActive(true);
                            //ExecuteAfterTime(1000);
                            Debug.Log("You Lose!");
                        }
                        break;
                    case "藍綠色球":
                        if ((LBall.GetComponent<SpriteRenderer>().sprite.name == "藍色球" &&
                            RBall.GetComponent<SpriteRenderer>().sprite.name == "綠色球") ||
                            (LBall.GetComponent<SpriteRenderer>().sprite.name == "綠色球" &&
                            RBall.GetComponent<SpriteRenderer>().sprite.name == "藍色球"))
                        {
                            Debug.Log("You Win!");
                        }
                        else
                        {
                            StartCoroutine(resetStatus(1));
                            //wrongAns.SetActive(true);
                            //ExecuteAfterTime(1000);
                            Debug.Log("You Lose!");
                        }
                        break;
                }
            }
        }
    }

    public void btnToggle(Collider2D toggle)
    {
        //Btn On
        if (toggle.GetComponent<SpriteRenderer>().sprite.name == "按鈕1")
        {
            print("toogle Off");
            toggle.GetComponent<SpriteRenderer>().sprite = btns[1];
            foreach(GameObject b in gameBalls)
            {
                b.GetComponent<SpriteRenderer>().sprite = balls[Random.Range(0, 5)];
            }
            StartCoroutine(toggleSwitch(0.3f, toggle));
        }
    }
    public void fruitFall(Collision2D collision)
    {
        fruits.GetComponent<Animator>().enabled = true;
    }
    public void fanToggle(Collision2D collision)
    {
        foreach(GameObject a in fanAnim)
        {
            a.GetComponent<Animator>().enabled = !a.GetComponent<Animator>().enabled;
        }
    }
    IEnumerator toggleSwitch(float time, Collider2D toggle)
    {
        yield return new WaitForSeconds(time);
        toggle.GetComponent<SpriteRenderer>().sprite = btns[0];
    }

    // Code to execute after the delay
    IEnumerator resetStatus(float time)
    {
        wrongAns.SetActive(true);
        yield return new WaitForSeconds(time);
        resetLRBall();
        wrongAns.SetActive(false);

    }
    private void resetLRBall()
    {
        RBall.GetComponent<SpriteRenderer>().sprite = balls[7];
        LBall.GetComponent<SpriteRenderer>().sprite = balls[7];
        isSetL = false;
        //wrongAns.SetActive(false);
    }
}