using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour {

    private float gazeTimer;
    private Vector3 ScreenCenter;
    public GameObject hpgaze;

    public GameObject rocketcontrol;
    private GameObject Game2Position;

    private float hpGazeNum = 1.0f;

    // Use this for initialization
    void Start()
    {
        gazeTimer = 0.0f;
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        hpgaze.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        RaycastHit hit;
        hpgaze.SetActive(true);

        if (Physics.Raycast(ray, out hit, 10000.0f))
        {
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                //9월 11일 추가코드
                if (hit.transform.tag == "target" || hit.transform.tag == "target (1)" || hit.transform.tag == "target (2)" || hit.transform.tag == "target (3)")
                {
                    rocketcontrol.GetComponent<Ardunity.RocketMove>().setTarget(hit.transform.gameObject);
                    RocketGameUI ui = GameObject.Find("GameUI").GetComponent<RocketGameUI>();
                    ui.ChangeMs(5);
                }
                else
                {
                    GameObject tar = GameObject.FindWithTag("fake_target");
                    rocketcontrol.GetComponent<Ardunity.RocketMove>().setTarget(tar);
                }
            }

            //SceneToGame1()
            if (hit.transform.tag == "button_replaygame1")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().SceneToGame1();
                    gazeTimer = 0;
                }
            }

            //SceneToGame2()
            else if (hit.transform.tag == "button_replay")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().SceneToGame2_Play();
                    gazeTimer = 0;
                }
            }

            //SceneToGame3()
            else if (hit.transform.tag == "button_replaygame3")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().SceneToGame3();
                    gazeTimer = 0;
                }
            }

            //SceneChange2()
            else if (hit.transform.tag == "button_back")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().SceneChange2();
                    gazeTimer = 0;
                }
            }

            //Pause
            else if (hit.transform.tag == "button_menu")
            {
                // 외줄타기 게임
                if (SceneManager.GetActiveScene().buildIndex == 3) 
                {
                    Game2Position = this.transform.parent.gameObject;

                    if (Game2Position.GetComponent<Ardunity.Game2>().PauseButton.interactable == true)
                    {
                        hpgaze.SetActive(true);
                        gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                        hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                        Debug.Log(gazeTimer);
                        if (gazeTimer >= 1)
                        {
                            GetComponent<move_scene>().Pause();
                            gazeTimer = 0;
                        }
                    }
                    
                } else
                {
                    hpgaze.SetActive(true);
                    gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                    hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                    Debug.Log(gazeTimer);
                    if (gazeTimer >= 1)
                    {
                        GetComponent<move_scene>().Pause();
                        gazeTimer = 0;
                    }
                }
                
            }

            //SceneToGame2_Play()
            else if (hit.transform.tag == "button_start")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().SceneToGame2_Play();
                    gazeTimer = 0;
                }
            }

            //SceneToManual()
            else if (hit.transform.tag == "button_manuel")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().SceneToManual();
                    gazeTimer = 0;
                }
            }

            //Exit()
            else if (hit.transform.tag == "button_exit")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().Exit();
                    gazeTimer = 0;
                }
            }

            //Exit()
            else if (hit.transform.tag == "button_exit")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().Exit();
                    gazeTimer = 0;
                }
            }

            //SceneChange1()
            else if (hit.transform.tag == "button_backgame")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().SceneChange1();
                    gazeTimer = 0;
                }
            }

            //Manual_Arm()
            else if (hit.transform.tag == "button_manual_arm")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<Manual>().Manual_Arm();
                    gazeTimer = 0;
                }
            }

            //Manual_Leg()
            else if (hit.transform.tag == "button_manual_leg")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<Manual>().Manual_Leg();
                    gazeTimer = 0;
                }
            }

            //Manual_Waist()
            else if (hit.transform.tag == "button_manual_waist")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<Manual>().Manual_Waist();
                    gazeTimer = 0;
                }
            }

            //ReStart()
            else if (hit.transform.tag == "button_restart")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().ReStart();
                    gazeTimer = 0;
                }
            }

            //pause_GoOn()
            else if (hit.transform.tag == "button_goon")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().pause_GoOn();
                    gazeTimer = 0;
                }
            }

            //Howto()
            else if (hit.transform.tag == "button_howto")
            {
                hpgaze.SetActive(true);
                gazeTimer += 1.0f / hpGazeNum * Time.deltaTime;
                hpgaze.GetComponent<Image>().fillAmount -= 1.0f / hpGazeNum * Time.deltaTime;
                Debug.Log(gazeTimer);
                if (gazeTimer >= 1)
                {
                    GetComponent<move_scene>().Howto();
                    gazeTimer = 0;
                }
            }

            else
            {
                gazeTimer = 0;
                hpgaze.GetComponent<Image>().fillAmount = 1;
            }
        }
        else
        {
            gazeTimer = 0;
            hpgaze.SetActive(true);
            hpgaze.GetComponent<Image>().fillAmount = 1;
        }
    }
}
