using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public float speed;		//遊戲速度
    GameObject player;		//玩家物件
    GameObject cameraObj;	//攝影機物件
    GameObject timeText;	//時間物件
    Vector3 camera2player;	//攝影機與玩家相對距離
    Vector3 startPos;		//玩家起點距離
    float gameStartTime;	//遊戲開始時間

    // 遊戲起始
    void Start()
    {
        timeText = GameObject.Find("timeText");
        player = GameObject.Find("player");
        cameraObj = GameObject.Find("cam");
        startPos = player.transform.position;
        camera2player = cameraObj.transform.position - player.transform.position;
        speed = 0.5f;
        gameStartTime = Time.time;
    }

    // 遊戲主迴圈
    void Update()
    {
        cameraFollow();
        gameControl();
        countTime();
    }

    //顯示時間
    void countTime()
    {
        player.transform.position += new Vector3(0, 0, 0.6f);
        timeText.GetComponent<UnityEngine.UI.Text>().text = (Time.time - gameStartTime).ToString("F0");
    }

    //重置遊戲
    public void restart()
    {
        player.transform.position = startPos;
        gameStartTime = Time.time;
    }

    //攝影機跟隨
    void cameraFollow()
    {
        cameraObj.transform.position = player.transform.position + camera2player;
    }

    //遊戲控制
    void gameControl()
    {
        if (Input.GetKey("w"))
        {
            player.transform.position += new Vector3(0, 0, speed);
        }
        if (Input.GetKey("s"))
        {
            player.transform.position += new Vector3(0, 0, -speed);
        }
        if (Input.GetKey("a"))
        {
            player.transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            player.transform.position += new Vector3(speed, 0, 0);
        }
    }
}