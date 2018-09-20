using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


namespace Ardunity
{

    public class Player : MonoBehaviour
    {
        private GameUI UIObj;      // ui 오브젝트
        private GameObject[] img;
        private StepCtrl stepCtrl;

        public float x;     // 마우스에 따른 x회전 위치
        public int cornerCount = 1;

        public GameObject snowing; // 눈내리는 이벤트
        private GameObject cornertr;
        public GameObject BoostEf; // 부스터 이펙트
        private GameObject newEf;
        private Transform vrCamera;

        NavMeshAgent nvAgent;

        public float nvSpeed, pSpeed; // 플레이어 속도, 네비 속도
        public bool isColl, isBoost, isCollEnemy;
        public bool isSt1, isSt2, isSt3, isCountOk, isStart = false;
        public bool isPo;
        private int Life;
        public float countTime, startTime, gameTime;

        public Renderer lamp;
        private Color originColor; // 원래 색깔

        private AudioSource bgm;

        private int count;

        // Use this for initialization
        public void Start()
        {
            count = 0;
            cornerCount = 1; // 코너를 돈 수
            vrCamera = GameObject.Find("VRCamera").GetComponent<Transform>();

            bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
            bgm.Play();

            Transform tr = GameObject.Find("startPo").GetComponent<Transform>();
            transform.position = tr.position;
            transform.rotation = tr.rotation;

            originColor = lamp.material.color;
            nvAgent = gameObject.GetComponent<NavMeshAgent>(); // 네비게이션

            UIObj = GameObject.Find("Game_UI").GetComponent<GameUI>(); // GameUI 오브젝트 찾음
            UIObj.ChangeCorner(5 - cornerCount);
            img = GameObject.FindGameObjectsWithTag("img"); // 이미지 UI 오브젝트들
            Life = 5;

            Debug.Log("목숨 : " + Life);
            for (int i = 1; i <= 5; i++)
            {
                GameObject.Find("Lifes").transform.Find("life" + i).gameObject.SetActive(true);
            }
            for(int i = 1; i <= 4; i++)
                GameObject.Find("cornerEvent").transform.Find("corner" + i).gameObject.SetActive(true);

            isSt1 = false; isSt2 = false; isSt3 = true; // 스텝 1,2,3은 다 비활성 상태
            isBoost = false; isColl = false; isCountOk = false; isStart = false; isPo = false;

            stepCtrl = GetComponent<StepCtrl>();

            startTime = 60f; // 초기화 과정이 끝난 후의 시간
            gameTime = 0f; // 게임 시작한 이후로의 시간

            nvSpeed = 0f;
            pSpeed = 0f;
            Invoke("CountDown", startTime);

            cornertr = GameObject.FindWithTag("corner" + cornerCount);
            nvAgent.SetDestination(cornertr.transform.position);
            nvAgent.speed = nvSpeed; // 코너를 따라가는 속도
        }

        // Update is called once per frame
        void Update()
        {
            if(cornerCount == 1)
            {
                if((transform.position.x > -247 || transform.position.x < -342) && !isPo)
                {
                    Transform tr = GameObject.Find("startPo").GetComponent<Transform>();
                    transform.position = tr.position;
                    transform.rotation = tr.rotation;
                    isPo = true;
                }
            }

            distinctionA AAA = GameObject.Find("사람").GetComponent<distinctionA>();
            count = AAA.count3;
            gameTime += Time.deltaTime;
            if (count >= 200 && !isStart)
            {
                Invoke("CountDown", 5f);
                Invoke("StartGo", 5f);
                UIObj.ChangeCount(14);
                // UI에 게임 시작된다고 메시지 뜨게함
            }
            if (isStart)
            //if (gameTime > startTime)
            {
                if (Life <= 0) // 게임 오버 메시지 뜨게 함- 목숨을 다 소모했다고 함
                {
                    UIObj.ChangeGameOver(0);
                    if (isCollEnemy) // 장애물이랑 부딪힘 - 제자리에서 뱅글돎, 반짝거림
                    {
                        transform.Rotate(0, 20, 0);
                        float flicker = Mathf.Abs(Mathf.Sin(Time.time * 10));
                        lamp.material.color = originColor * flicker;
                    }
                    GameObject.Find("BtnCanvas").transform.Find("EndMenu").gameObject.SetActive(true);
                }
                else // 아직 살아 있음
                {
                    distinctionA snowsnow = GameObject.Find("사람").GetComponent<distinctionA>(); // 나중에 형이 바꿔줌
                    if (cornerCount != 5) // 코너를 다 돌지 않았으면 계속 코너를 따라가도록 함
                    {
                        nvAgent.speed = nvSpeed; // 코너를 따라가는 속도
                    }
                    // 눈 이벤트 위치 조정
                    Vector3 vector3 = new Vector3(transform.position.x, transform.position.y + 30, transform.position.z);
                    snowing.transform.position = vector3;

                    if (isCollEnemy) // 장애물이랑 부딪힘 - 제자리에서 뱅글돎, 반짝거림
                    {
                        transform.Rotate(0, 20, 0);
                        float flicker = Mathf.Abs(Mathf.Sin(Time.time * 10));
                        lamp.material.color = originColor * flicker;
                    }
                    else if (!isColl) // 충돌하지 않으면
                    {
                        //플레이어 회전 구현
                        // 코너 1 : -90~90, 코너 2 : 0~180 ....
                        x = vrCamera.rotation.eulerAngles.y; // vr 시선에 따라 
                        if(cornerCount == 1)
                        {
                            if (x < 270 && x > 180) x = 270;
                            if (x > 90 && x < 180) x = 90;
                        }
                        else if (cornerCount == 2)
                        {
                            if (x < 360 && x > 270) x = 0;
                            if (x > 180 && x < 270) x = 180;
                        }
                        else if (cornerCount == 3)
                        {
                            if (x < 90 && x > 0) x = 90;
                            if (x > 270 && x < 360) x = 270;
                        }
                        else if (cornerCount == 4)
                        {
                            if (x < 180 && x > 90) x = 180;
                            if (x > 0 && x < 90) x = 360;
                        }


                        Quaternion turn = Quaternion.Euler(0, x, 0);
                        transform.rotation = turn;

                        transform.Translate(Vector3.forward * pSpeed); // 가속

                        if (!isBoost) // 부스터가 아니면 속도가 서서히 줆
                        {
                            pSpeed *= 0.996f;
                            nvSpeed *= 0.996f;
                        }
                        else // 부스터 상태면 속도가 붙는다.
                        {
                            if (newEf) // 오브젝트가 할당 된 상태야 함, 부스터 이펙트 생성
                            {
                                newEf.transform.position = transform.position;
                                newEf.transform.Translate(new Vector3(0, 2, 0));
                            }

                            pSpeed *= 1.2f;
                            nvSpeed *= 1.2f;

                            // 속도 제한
                            if (pSpeed >= 0.6f) pSpeed = 0.3f;
                            if (nvSpeed >= 3f) nvSpeed = 3f;
                        }

                        if (isCountOk)
                        {
                            UIObj.ChangeCount((int)(countTime - Time.time));
                            if (Time.time < countTime) // 제한 시간안에 올바른 동작을 함
                            {
                                if (Input.GetKeyDown(KeyCode.Q) && isSt3) // Time.time <= countTime 나중에 이것도 추가 - 제한 시간안에 올바른 동작을 함
                                {
                                    stepCtrl.StepOne();
                                    isSt1 = true;
                                    isSt3 = false;
                                    CountDown();
                                }
                                else if (Input.GetKeyDown(KeyCode.W) && isSt1)
                                {
                                    stepCtrl.StepTwo();
                                    isSt1 = false;
                                    isSt2 = true;
                                    CountDown();
                                }
                                else if (Input.GetKeyDown(KeyCode.E) && isSt2)
                                {
                                    stepCtrl.StepThree();
                                    isSt2 = false;
                                    isSt3 = true;
                                    isCountOk = false;
                                    Invoke("CountDown", 2f);
                                }
                                /**** 밑에는 아두니티 쓰는거 *****/
                                if (snowsnow.snow0 && isSt3)
                                {
                                    stepCtrl.StepOne();
                                    isSt1 = true;
                                    isSt3 = false;
                                    CountDown();
                                }
                                else if (snowsnow.snow1 && isSt1)
                                {
                                    stepCtrl.StepTwo();
                                    isSt1 = false;
                                    isSt2 = true;
                                    CountDown();
                                }
                                else if (snowsnow.snow2 && isSt2)
                                {
                                    stepCtrl.StepThree();
                                    isSt2 = false;
                                    isSt3 = true;
                                    isCountOk = false;
                                    Invoke("CountDown", 2f);
                                    UIObj.ChangeCount(12); // 성공 메시지
                                }
                            }
                            else // 동작을 수행하지 못함 : 목숨 깎이고 실패하는 애니메이션 - 미끄러지는 애니메이션 말고, 속도는 그대로
                            {
                                UIObj.ChangeCount(0);
                                isCountOk = false;
                                Debug.Log("동작 못함 ㅜㅜ : life" + Life + "번 깎임");
                                GameObject.Find("life" + Life).SetActive(false);
                                //Destroy(GameObject.Find("life" + Life));
                                Life--;

                                stepCtrl.StepFail();
                                Invoke("isCollFalse", 4f); // 2초 후에 정상
                                Clear();
                                Invoke("CountDown", 4f);
                            }
                        }
                    }
                }
            }
        }

        void OnCollisionEnter(Collision coll) // 부딪혔을 때
        {
            if (coll.collider.tag == ("corner" + cornerCount))
            {
                isColl = true;            // 부딪힌 상태
                //Destroy(coll.gameObject); // 코너 삭제

                coll.gameObject.SetActive(false);
                cornerCount++;
                UIObj.GetComponent<GameUI>().ChangeCorner(5 - cornerCount);

                if (cornerCount < 5)
                {
                    cornertr = GameObject.FindWithTag("corner" + cornerCount);
                    nvAgent.SetDestination(cornertr.transform.position);

                    Quaternion turn = Quaternion.Euler(0, 90 * (cornerCount - 1), 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, turn, 0.01f * Time.deltaTime); // 부드럽게 턴
                    UIObj.ChangeCount(9); // 코너 도는중 메시지 띄움
                    Invoke("CountDown", 1f);
                    Invoke("isCollFalse", 1f); // 3초 후에 정상
                }
                else
                {
                    // 맵을 다 돌았으니까 최종 결과가 나오고, 만약 최고기록보다 짧게 들어오면 갱신함
                    //stepCtrl.StepSuccess();
                    UIObj.ChangeGameOver(1);
                    GameObject.Find("BtnCanvas").transform.Find("EndMenu").gameObject.SetActive(true);
                }
            }

            if (coll.collider.tag == ("enemy"))
            {
                UIObj.ChangeCount(7); // 장애물에 부딪힘 알려줌
                isColl = true;            // 부딪힌 상태
                isCollEnemy = true;
                isCountOk = false;
                // 목숨 깎이고, 뱅글돌아가는 효과 호출
                nvSpeed = 0f;
                pSpeed = 0f;

                float flicker = Mathf.Abs(Mathf.Sin(Time.time * 10));
                lamp.material.color = originColor * flicker;

                Debug.Log("적이랑 부딪힘 ㅜㅜ : life" + Life + "번 깎임");
                GameObject.Find("life" + Life).SetActive(false);
                Life--;

                stepCtrl.StepFail();
                Invoke("isCollFalse", 4f); // 3초 후에 정상
                Clear();
                Invoke("CountDown", 4f);
            }
        }

        void isCollFalse() // 코너 부딪힘 끝
        {
            Debug.Log("isColl false!");
            isColl = false;
            isCollEnemy = false;
            lamp.material.color = originColor;
        }

        public void Booster() // 부스터 온
        {
            GameObject.Find("BoosterSound").GetComponent<AudioSource>().Play();
            isBoost = true;
            UIObj.ChangeCount(11); // 장애물에 부딪힘 알려줌
            Debug.Log("부스터 온!");
            newEf = Instantiate(BoostEf, this.transform.position, this.transform.rotation) as GameObject;

            nvSpeed = 1f;
            pSpeed = 0.10f;
            Destroy(newEf, 1.5f); // 1.5초뒤에 이펙트 삭제
            Invoke("BoostOff", 1.5f); // 1.5초 후에 정상
        }

        void BoostOff() // 부스터 끄기
        {
            Debug.Log("부스터 오프!");
            isBoost = false;
        }

        void CountDown() // 동작을 실행하기 위해 시간을 초기화
        {
            countTime = Time.time + 6f; // 5초 추가
            isCountOk = true;
        }

        public void Clear() // 불값 초기화
        {
            isSt1 = false;
            isSt2 = false;
            isSt3 = true;
        }

        void StartGo()
        {
            isStart = true;
            UIObj.txtClear();
        }
    }
}