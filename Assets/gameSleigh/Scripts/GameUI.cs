using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 텍스트 표시, 버튼 비활성화에 사용
using UnityEngine.SceneManagement; // 씬 전환에 사용

public class GameUI: MonoBehaviour
{
    public float _time = 0.0f; // 타이머 변수 초기화

    public Text _timerText; // 진행 시간 표시될 텍스트
    public Text txtScore;
    public Text txtBestScore;
    public Text txtCorner;
    public Text txtGameOverMs;
    public Text txtCount;

    public int corner;
    public float startTime;

    bool finish;
    Transform tr;
    //public float done = 13.0f; // 컨트롤러 초기화 영상 재생될 시간

    // Use this for initialization
    public void Start()
    {
        finish = false;
        _time = 0.0f;
        corner = 4;
        txtGameOverMs.text = "";
        txtCount.text = "";
        float bestTime = PlayerPrefs.GetFloat("BestScore");
        if (bestTime < 20f) // 설마 20초안에 들어온 사람이 없을거니까 이 때는 최고 기록을 5분으로 초기화함
        {
            bestTime = 300f;
            PlayerPrefs.SetFloat("BestScore", bestTime);
            PlayerPrefs.Save();
        }
            
        txtBestScore.text = "Best time : " +
        ((int)bestTime / 60) + " : " + ((int)bestTime % 60) + " : " + (int)((bestTime % 1) * 100);

        startTime = GameObject.FindWithTag("Player").GetComponent<Ardunity.Player>().startTime;
    }

    public void ChangeCorner(int Corner)
    {
        corner = Corner;

        txtCorner.text = "현재 남은 Corner : " + corner.ToString();
    }

    public void ChangeScore(float time)
    {
        txtScore.text = "Current time : " +
            ((int)time/60) + " : " + ((int)time%60) + " : " + (int)((time % 1) * 100) ;
    }

    public void ChangeBest()
    {
        if (_time < PlayerPrefs.GetFloat("BestScore"))
        {
            txtCount.text = "축하합니다! 최고 기록 갱신입니다!";
            PlayerPrefs.SetFloat("BestScore", _time);
            PlayerPrefs.Save();
            txtBestScore.text = "Best time : " +
            ((int)_time / 60) + " : " + ((int)_time % 60) + " : " + (int)((_time % 1) * 100);
        }
    }

    public void ChangeCount(int time) // 원래는 시간초에 따라서 하는건데 그냥 메시지 띄우는 함수로 바꿈
    {
        if (time == 0)
        {
            txtCount.text = "실패 ㅜㅜ";
            Invoke("txtClear", 2f);
        }
        else if (time > 0 && time < 6)
        {
            txtCount.text = "제한시간 " + time.ToString() + " 초 남았습니다.";
        }
        else if(time > 6 && time < 8)
        {
            txtCount.text = "장애물에 부딪혔어요 ㅜㅜ";
            Invoke("txtClear", 2f);
        }
        else if(time >= 8 && time < 10)
        {
            txtCount.text = "코너 도는 중..";
            Invoke("txtClear", 1f);
        }
        else if(time >= 11 && time < 13)
        {
            txtCount.text = "성공!";
            Invoke("txtClear", 1f);
        }
        else if (time >= 13)
        {
            txtGameOverMs.text = "잠시 후 게임이 시작 됩니다!\n 준비해 주세요!";
        }
    }

    public void txtClear()
    {
        txtGameOverMs.text = "";
        txtCount.text = "";
    }

    public void ChangeGameOver(int mode)
    {
        finish = true;
        if(mode == 0)   // 라이프가 없음
        {
            txtGameOverMs.text = "목숨이 더 이상 없네요 ㅜㅜ 화이팅!";
        }
        else if(mode == 1) // 맵을 다 돌음
        {
            txtCount.text = "";
            txtGameOverMs.text = "골인 입니다! 수고하셨어요!";
            ChangeBest();
        }
    }

    void Update()
    {
        bool isStart = GameObject.FindWithTag("Player").GetComponent<Ardunity.Player>().isStart;
        startTime = GameObject.FindWithTag("Player").GetComponent<Ardunity.Player>().startTime;
        // 진행 시간 표시
                
        if(isStart && !finish)
        {
            _time += Time.deltaTime; // 초
            int minute = (int)_time / 60;
            _timerText.text = minute.ToString();
            ChangeScore(_time);
        }
            
    }
}
