using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 버튼 비활성화 기능 사용하기 위함
using UnityEngine.Video; // 초기화 영상 제어


/* 씬 번호
 * 0 : 메인(Main)
 * 1 : 게임 선택 메뉴(Menu)
 * 2 : 매뉴얼(manual)
 * 3 : 외줄타기 게임(game_2)
 * 4 : 성공화면(Success)
 * 5 : 실패화면(Fail)
 * 6 : 물로켓 게임(WaterRocket)
 * 7 : 썰매 게임(썰매 게임)
 */


public class move_scene : MonoBehaviour {

    public AudioClip sndPause; // 일시정지 버튼 효과음
    public AudioClip sndPauseButton; // 일시정지 메뉴 내의 버튼 효과음

    public Button PauseButton; // 일시정지 버튼
    //int isInitializing = 0; // 초기화 중인지 검사
    public float _time = 0.0f; // 타이머 변수 초기화

    bool soundOnce = false; // 메뉴 출력 사운드 한 번만

    //9월 11일 초기화 추가
    private GameObject rocketcontrol;
    private GameObject target;
    private GameObject rocketmaincamera;

    private GameObject Game2Position;

    // 9 - 11 썰매 초기화
    private GameObject sleighRestart;


    public int HowtoTime = 0; // 검은화면 버튼을 몇 번 눌렀는지 검사

    // 메인 화면
    public void SceneChange1()
    {
        SceneManager.LoadScene("Main");
    }


    // 게임 선택 화면으로 이동
    public void SceneChange2()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SceneToManual()
    {
        SceneManager.LoadScene("manual");
    }

    public void SceneToGame1()
    {
        HowtoTime = 0;

        SceneManager.LoadScene("썰매 게임");
    }

    // 외줄타기 허리운동게임 선택 버튼(게임 시작부터 하기)
    public void SceneToGame2_Play()
    {
        HowtoTime = 0;

        soundOnce = false;

        SceneManager.LoadScene("game_2");
    }

    public void SceneToGame3()
    {
        HowtoTime = 0;

        SceneManager.LoadScene("WaterRocket");
    }


    // 검은 화면
    public void Howto()
    {
        HowtoTime++;

        // ? 버튼을 한 번 누르면 켜지고, 또 다시 한 번 누르면 꺼진다
        if (HowtoTime % 2 != 0) // 킴
        {
            if (SceneManager.GetActiveScene().buildIndex == 3) // 외줄타기
            {
                GameObject.Find("movingButton").transform.Find("HowtoCanvas").gameObject.SetActive(true);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 6) // 로켓
            {
                GameObject.Find("HowtoParent").transform.Find("Howto").gameObject.SetActive(true);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 7) // 썰매
            {
                GameObject.Find("buttonCanvas").transform.Find("Howto").gameObject.SetActive(true);
            }
        } else // 끔
        {
            if (SceneManager.GetActiveScene().buildIndex == 3) // 외줄타기
            {
                GameObject.Find("movingButton").transform.Find("HowtoCanvas").gameObject.SetActive(false);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 6) // 로켓
            {
                GameObject.Find("HowtoParent").transform.Find("Howto").gameObject.SetActive(false);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 7) // 썰매
            {
                GameObject.Find("buttonCanvas").transform.Find("Howto").gameObject.SetActive(false);
            }
        }
        
    }


    // 재시작 버튼
    public void ReStart()
    {
        pause_GoOn();
        if (SceneManager.GetActiveScene().buildIndex == 3) // 외줄타기
        {
            /*
            Game2Position = GameObject.Find("movingPerson");

            Game2Position.GetComponent<Ardunity.Game2>().Life = 4;
            Game2Position.GetComponent<Ardunity.Game2>()._time = 0.0f;
            */
            //Game2Position = GameObject.Find("movingPerson");

            Game2Position = this.transform.parent.gameObject;

            if(Game2Position.GetComponent<Ardunity.Game2>().PauseButton.interactable == true)
            {
                Game2Position.GetComponent<Ardunity.Game2>().RestartPosition();
            }
            
        }
        else if(SceneManager.GetActiveScene().buildIndex == 6) // 로켓
        {
            //9월 11일 초기화 추가
            rocketcontrol = GameObject.Find("RocketControl");
            rocketcontrol.GetComponent<Ardunity.RocketMove>().Start();

            target = GameObject.Find("targetset");
            target.GetComponent<Ardunity.TargetCollision>().Start();

            rocketmaincamera = GameObject.Find("Main Camera");
            rocketmaincamera.GetComponent<GameDirector>().Start();

            rocketmaincamera = GameObject.Find("GameUI");
            rocketmaincamera.GetComponent<RocketGameUI>().Start();
        }
        else if(SceneManager.GetActiveScene().buildIndex == 7) // 썰매
        {
            
            //9-11 썰매 재시작 추가
            sleighRestart = GameObject.Find("사람");
            sleighRestart.GetComponent<Ardunity.Player>().Start();
            sleighRestart.GetComponent<Ardunity.Player>().Start();
            sleighRestart.GetComponent<Ardunity.Player>().Start();
            sleighRestart = GameObject.Find("Game_UI");
            sleighRestart.GetComponent<GameUI>().Start();
            sleighRestart.GetComponent<GameUI>().Start();
            sleighRestart.GetComponent<GameUI>().Start();
        }
    }

    // 종료 버튼 기능
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 유니티 에디터 상에서 동작
#else
        Application.Quit(); // pc 및 모바일에서 동작
#endif
    }


    public void Pause()
    {
        /*
        if (null != GameObject.FindWithTag("Initialize"))
        {
            isInitializing = 1; // 초기화 중이었다
            Destroy(GameObject.FindWithTag("Initialize")); // 초기화 영상 삭제
        }
        */

        // 일시정지 버튼 비활성화
        PauseButton.interactable = false;

        // 화면을 어둡게 한다
        //Light light = GameObject.FindWithTag("Light").GetComponent<Light>();
        //light.intensity = -3; // -1로 할 수록 밝아짐


        // 화면을 정지시킨다 (초기화 영상 나오고 있는 경우는 적용되지 않음)
        //Time.timeScale = 0; // 일시정지


        if(SceneManager.GetActiveScene().buildIndex == 7) // 썰매 게임
        {
            GameObject.Find("BtnCanvas").transform.Find("PauseMenu").gameObject.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3) // 외줄타기 게임
        {
            //GetComponent<AudioSource>().Pause(); // 배경음 일시정지

            if(soundOnce == false)
            {
                AudioSource.PlayClipAtPoint(sndPause, transform.position); // 효과음 출력

                soundOnce = true;
            }

            GameObject.Find("movingButton").transform.Find("PauseMenu").gameObject.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 6) // 물로켓 게임
        {
            GameObject.Find("GameUI").transform.Find("PauseMenu").gameObject.SetActive(true);
        }

    } 

    // 메뉴닫기 버튼
    public void pause_GoOn()
    {
        soundOnce = false;
        PauseButton.interactable = true;
        //GetComponent<AudioSource>().UnPause(); // 배경음 다시 재생

        /*
        if (isInitializing == 1) // 초기화 중이었다면
        {
            GameObject obj = Instantiate(Resources.Load("Initializing")) as GameObject; // 초기화 영상 다시 불러오기

            if (done > 0f)
            {
                done -= Time.deltaTime;
            }
            else
            {
                Destroy(GameObject.FindWithTag("Initialize"));
            }
        }
        */

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            GameObject.Find("BtnCanvas").transform.Find("PauseMenu").gameObject.SetActive(false);
            GameObject.Find("BtnCanvas").transform.Find("EndMenu").gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3) // 외줄타기 게임
        {
            GameObject.Find("movingButton").transform.Find("PauseMenu").gameObject.SetActive(false);
            GameObject.Find("movingButton").transform.Find("EndMenu").gameObject.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            GameObject.Find("GameUI").transform.Find("PauseMenu").gameObject.SetActive(false);
            GameObject.Find("GameUI").transform.Find("EndMenu").gameObject.SetActive(false);
        }
            
        /*
        PauseButton.interactable = true;
        Light light = GameObject.FindWithTag("Light").GetComponent<Light>();


        // 라이트 다시 밝게 함
        if(SceneManager.GetActiveScene().buildIndex == 7)
        {
            light.intensity = +0.5f;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 6)
        {

            light.intensity = +1;
        } 
        */

        //Time.timeScale = 1;
        
        AudioSource.PlayClipAtPoint(sndPauseButton, transform.position);
    }
}
