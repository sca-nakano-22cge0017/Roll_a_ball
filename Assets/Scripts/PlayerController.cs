using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�𑀍삷��Ƃ��͒ǉ����Ȃ���΂Ȃ�Ȃ�

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update�@start�͏���̃t���[���̂݁Aupdate�͖��t���[������

    private float speed = 3; //public�ɂ����inspector����ύX�ł���
    public Text scoreText; //�X�R�A��UI
    public Text winText; //���U���g��UI

    private Rigidbody rb;�@//private�͎w�肳�ꂽ���̂ɓ���
    private int score;

    public float countdown = 5.0f;
    public Text timetext;
    public Text timeup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();�@//GetComponent��Inspector������������Ă���

        //UI��������
        score = 0; 
        SetCountText();
        winText.text = "";

        timeup.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");�@//var�͕ϐ�
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0, moveVertical);�@//Vector3=�O�����̃x�N�g��

        rb.AddForce(movement * speed);

        countdown -= Time.deltaTime;
        timetext.text = countdown.ToString("f1") + "�b";
        if (countdown <= 0)
        {
            timeup.text = "TIMEUP!!";
            timetext.text = "0.0�b";
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
