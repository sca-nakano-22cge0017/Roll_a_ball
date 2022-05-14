using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UIを操作するときは追加しなければならない

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update　startは初回のフレームのみ、updateは毎フレーム動作

    private float speed = 3; //publicにするとinspectorから変更できる
    public Text scoreText; //スコアのUI
    public Text winText; //リザルトのUI

    private Rigidbody rb;　//privateは指定された物体に働く
    private int score;

    public float countdown = 5.0f;
    public Text timetext;
    public Text timeup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();　//GetComponentはInspectorから情報を持ってくる

        //UIを初期化
        score = 0; 
        SetCountText();
        winText.text = "";

        timeup.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");　//varは変数
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0, moveVertical);　//Vector3=三次元のベクトル

        rb.AddForce(movement * speed);

        countdown -= Time.deltaTime;
        timetext.text = countdown.ToString("f1") + "秒";
        if (countdown <= 0)
        {
            timeup.text = "TIMEUP!!";
            timetext.text = "0.0秒";
            speed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            score = score + 1;

            SetCountText ();
        }
    }

    void SetCountText()
    {
        scoreText.text = "Count:" + score.ToString();

        if (score >= 3)
        {
            winText.text = "You Win!";
        }
    }
}
