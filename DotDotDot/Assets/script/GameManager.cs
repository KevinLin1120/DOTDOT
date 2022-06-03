using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject LBall, RBall, AnsBall; //Balls in nav
    public GameObject[] balls; //red ora yel gre blu pur whi

    // Start is called before the first frame update
    void Start()
    {
        LBall.GetComponent<SpriteRenderer>().color = new Color32(60, 60, 60, 255);
        RBall.GetComponent<SpriteRenderer>().color = new Color32(60, 60, 60, 255);
        AnsBall.GetComponent<SpriteRenderer>().sprite =
            balls[Random.Range(0, balls.Length)].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
