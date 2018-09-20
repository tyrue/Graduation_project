using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 캔버스 제어

public class RocketGameUI : MonoBehaviour {

    public Text timerText; // 진행 시간 표시될 텍스트
    public Text rocketText;

    // 추가 부분
    public Text GameMsText; // 게임 메시지 텍스트

    public float time = 0.0f; // 타이머 변수 초기화
    public float rockettime = 5.0f;

    public void Start()
    {
        // 초기화 영상 재생
        //GameObject obj = Instantiate(Resources.Load("InitializingRocket")) as GameObject;

        /** 추가된 부분***/
        GameMsText.text = "";
        time = 0.0f;
    }

    /** 추가된 부분***/
    public void ChangeMs(float time)
    {
        if (time > 2f && time <= 4f) // 성공 메시지
        {
            GameMsText.text = "성공!";
            Invoke("txtClear", 2f); // 2초 후에 이 함수를 실행함
        }
        else if(time < 1f) // 실패 메시지
        {
            GameMsText.text = "실패!";
            Invoke("txtClear", 2f);
        }
        else if (time > 4f && time < 6f) // 실패 메시지
        {
            GameMsText.text = "타겟을 조준했습니다.";
            Invoke("txtClear", 0.5f);
        }
        else if (time > 7f && time < 9f) // 실패 메시지
        {
            GameMsText.text = "빨간색 타겟을 제거하라!";
            Invoke("txtClear", 2f);
        }
    }

    // 게임 메시지 초기화하는 함수
    void txtClear()
    {
        GameMsText.text = "";
    }


    /*** 마침 *****/

    // Update is called once per frame
    void Update () {
        // 진행 시간 표시

        if(GameObject.Find("RocketControl").GetComponent<Ardunity.RocketMove>().gameStart)
        {
            time += Time.deltaTime;
            int minute = (int)time / 60;
            timerText.text = (minute.ToString());
        }

        if(rocketText.IsActive())
        {
            rockettime -= Time.deltaTime;
            int second = (int)rockettime;
            rocketText.text = "남은 시간 " + second.ToString() + " 초";
            if(second <= 0)
            {
                rocketText.text = "완료";
            }
        }
        else
        {
            rockettime = 5.0f;
        }

        // 컨초_허리 영상 끝나는 시간이 되면 영상 삭제하기
        if(time >= 19)
        {
            Destroy(GameObject.FindWithTag("Initialize")); // 컨초_허리 영상 제거하기
        }
    }

}
