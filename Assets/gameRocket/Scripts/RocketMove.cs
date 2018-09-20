using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Ardunity
{
    public class RocketMove : MonoBehaviour {

        public GameObject target; //타겟
        public GameObject explosion;
        private float angle;  //물로켓의 각도
        private float speed; //로켓 속도
        private bool rocketLaunchReady; //물로켓 발사 준비
        private bool exerciseRight; //운동을 하고 있는 지 확인
        public float timer; //시간초
        private float timer_check; //시간초 체크를 위한 저장
        private float timer_game = 0;
        public GameObject mainCamera; //메인 카메라
        public GameObject subCamera;  //로켓 카메라
        public GameObject activeCamera; //액션 카메라
        private Vector3 rocket_init_pos;
        private Quaternion rocket_init_rot;
        private Vector3 player_init_pos;
        public GameObject player;
        private Animator animator;

        private int Life;
        private GameObject life_img1, life_img2, life_img3, life_img4;

        /**추가된 부분***/
        private AudioSource audioSource; // 효과음 재생용 객체
        private RocketGameUI gameUI;    // UI스크립트 객체
        public bool gameStart = false;

        // Use this for initialization
        public void Start() {
            angle = 30f;
            speed = 30f;
            rocketLaunchReady = false;
            exerciseRight = false;
            timer = 0;
            if(timer_game != 0)
                timer_game = 60;
            mainCameraOn();
            rocket_init_pos = transform.position;
            rocket_init_rot = transform.rotation;
            player_init_pos = player.transform.position;
            animator = player.GetComponent<Animator>();
            animator.SetBool("kickstate", true);

            Life = 4;
            life_img1 = GameObject.FindWithTag("Life1");
            life_img2 = GameObject.FindWithTag("Life2");
            life_img3 = GameObject.FindWithTag("Life3");
            life_img4 = GameObject.FindWithTag("Life4");
            //9월 11일 초기화 추가
            GameObject.Find("hpCanvas").transform.Find("Life" + 4).gameObject.SetActive(true);
            GameObject.Find("hpCanvas").transform.Find("Life" + 3).gameObject.SetActive(true);
            GameObject.Find("hpCanvas").transform.Find("Life" + 2).gameObject.SetActive(true);
            GameObject.Find("hpCanvas").transform.Find("Life" + 1).gameObject.SetActive(true);

            // 추가된 부분
            gameUI = GameObject.Find("GameUI").GetComponent<RocketGameUI>(); // 객체 초기화
            gameStart = false;
        }

        // Update is called once per frame
        void Update() {
            timer_game += Time.deltaTime;
            distinctionC CCC = GameObject.Find("RocketControl").GetComponent<distinctionC>(); // 1번
            if (CCC.count2 >= 300 && !gameStart)
            {
                RocketGameUI ui = GameObject.Find("GameUI").GetComponent<RocketGameUI>();
                ui.ChangeMs(8);
                gameStart = true;
            }

            if (gameStart)   // 초기화 과정 끝나고 게임 시작
            {
                if (Life <= 0)
                {
                    //게임 끝
                    mainCameraOn();
                    transform.position = rocket_init_pos;
                    transform.rotation = rocket_init_rot;
                    player.transform.position = player_init_pos;
                    timer = 0;
                    //target = GameObject.FindWithTag("target");
                    exerciseRight = false;
                    animator.SetBool("kickstate", true);
                    animator.SetBool("gamestate", false);
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    //GameObject.Find("rocketCamera").transform.Find("Main Camera").gameObject.GetComponent<move_scene>().Pause();
                    GameObject.Find("GameUI").transform.Find("EndMenu").gameObject.SetActive(true);
                }
                else
                {
                    //운동을 수행한다면(발을 올린다면) true, 발을 거의 내린다면 false;
                    
                    if (CCC.waterrocket == true)
                    //if(Input.GetKey(KeyCode.Space))
                    {
                        exerciseRight = true;
                        timer_check = timer; 

                        /*if (mainCamera.GetComponent<GameDirector>().getX() > -0.137 && mainCamera.GetComponent<GameDirector>().getX() < -0.1258)
                            target = GameObject.FindWithTag("target");
                        else if (mainCamera.GetComponent<GameDirector>().getX() > -0.1128 && mainCamera.GetComponent<GameDirector>().getX() < -0.0946)
                            target = GameObject.FindWithTag("target (1)");
                        else if (mainCamera.GetComponent<GameDirector>().getX() > -0.027 && mainCamera.GetComponent<GameDirector>().getX() < -0.0012)
                            target = GameObject.FindWithTag("target (2)");
                        else if (mainCamera.GetComponent<GameDirector>().getX() > 0.063 && mainCamera.GetComponent<GameDirector>().getX() < 0.0894)
                            target = GameObject.FindWithTag("target (3)");
                        else
                            target = GameObject.Find("fake_target");*/

                        animator.SetBool("gamestate", true);
                    }
                    else
                    {
                        exerciseRight = false;
                    }

                    print(exerciseRight);

                    //운동이 정상적으로 시행된다면, 로켓의 준비 및 발사
                    if (exerciseRight)
                    {
                        rocketLaunchReady = true;
                    }

                    if (rocketLaunchReady) // 로켓 발사 준비 완료
                    {
                        timer += Time.deltaTime;
                        Debug.Log(timer);

                        if (animator.GetBool("kickstate") && animator.GetBool("gamestate"))
                        {
                            activeCameraOn();
                        }

                        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.kick") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.83f)
                        {
                            animator.SetBool("kickstate", false);
                            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                            /**추가된 부분**/
                            audioSource = GameObject.Find("StartSound").GetComponent<AudioSource>();
                            audioSource.Play();
                        }

                        if (animator.GetBool("kickstate") == false && animator.GetBool("gamestate") == true)
                        {
                            subCameraOn();
                            try
                            {
                                Launch(target.transform.position, speed);
                            }
                            catch (Exception e)
                            {
                                target = GameObject.Find("fake_target");
                                Launch(target.transform.position, speed);
                            }

                            if (exerciseRight == false && timer_check < 5) // 5초 미만이면 실패
                            {
                                //9월 11일 초기화 추가

                                GameObject.Find("rocketCamera").transform.Find("Main Camera").transform.Find("hpCanvas").transform.Find("Life" + Life).gameObject.SetActive(false);
                                //Destroy(GameObject.Find("Life" + Life));

                                //로켓을 폭발시키자
                                GameObject newExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation) as GameObject;
                                rocketLaunchReady = false;

                                /**추가된 부분**/
                                audioSource = GameObject.Find("FailSound").GetComponent<AudioSource>();
                                audioSource.Play(); // 효과음 재생
                                gameUI.ChangeMs(0); // 실패 문구 띄움

                                Life--;
                            }
                            //else if (exerciseRight == false && timer_check >= 4 && timer_check <= 6)
                            //{
                            //    Launch(target.transform.position, speed);
                            //}
                        }
                    }
                    else
                    {
                        mainCameraOn();
                        transform.position = rocket_init_pos;
                        transform.rotation = rocket_init_rot;
                        player.transform.position = player_init_pos;
                        timer = 0;
                        //target = GameObject.FindWithTag("target");
                        exerciseRight = false;
                        animator.SetBool("kickstate", true);
                        animator.SetBool("gamestate", false);
                        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    }

                    if (timer >= 6)
                    {
                        mainCameraOn();
                    }

                    if (timer >= 11)
                    {
                        rocketLaunchReady = false;
                    }
                }
            }
        }

        private void Launch(Vector3 posit, float speed)
        {
            Vector3 pos = transform.position;
            Vector3 target_pos = posit;

            float dist = Vector3.Distance(pos, target_pos);

            transform.LookAt(target_pos);

            float Vi = Mathf.Sqrt(dist * -Physics.gravity.y / Mathf.Sin(Mathf.Deg2Rad * angle * 2));
            float Vy, Vz;
            Vy = Vi * Mathf.Sin(Mathf.Deg2Rad * angle);
            Vz = Vi * Mathf.Cos(Mathf.Deg2Rad * angle);

            Vector3 localVelocity = new Vector3(0f, Vy, Vz);

            Vector3 globalVelocity = transform.TransformVector(localVelocity);

            if (timer < 6)
                GetComponent<Rigidbody>().velocity = globalVelocity * Time.deltaTime * speed;
            else if (timer >= 6)
                GetComponent<Rigidbody>().velocity = globalVelocity * Time.deltaTime * speed * 5;
        }

        public void mainCameraOn()
        {
            mainCamera.SetActive(true);
            subCamera.SetActive(false);
            activeCamera.SetActive(false);
            GameObject.Find("RocketControl").transform.Find("RocketCamera").transform.Find("RocketCanvas").transform.Find("TextCount").gameObject.SetActive(false);
        }

        public void subCameraOn()
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
            activeCamera.SetActive(false);
            GameObject.Find("RocketControl").transform.Find("RocketCamera").transform.Find("RocketCanvas").transform.Find("TextCount").gameObject.SetActive(true);
        }

        public void activeCameraOn()
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(false);
            activeCamera.SetActive(true);
        }

        public bool getRocketLaunchReady()
        {
            return rocketLaunchReady;
        }

        public void setRocketLaunchReady(bool ready)
        {
            rocketLaunchReady = ready;
        }

        public void setTarget(GameObject tar)
        {
            target = tar;
        }
    }
}