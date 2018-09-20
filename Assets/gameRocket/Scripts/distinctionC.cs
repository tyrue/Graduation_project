using UnityEngine;
using System.Collections.Generic;
using System;





namespace Ardunity
{
    

        [AddComponentMenu("ARDUnity/Reactor/Transform/distinctionC")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/reactor/distinction")]
	public class distinctionC : ArdunityReactor
    {

        
         
        
        public Animator animator;
        public bool smoothFollow = true;

        float time = 0.0f;
        float time2 = 0.0f;
        float time3 = 0.0f;
		private Quaternion _initRot;
		private IWireInput<Quaternion> _rotation;
        private Quaternion _curRotation;
		private Quaternion _fromRotation;
		private Quaternion _toRotation;
		private float _time;
        private Quaternion a;
        private bool k = true;
        private int count = 0;
        private int count1 = 0;
        private int decision = 0;
        public double a1,a2,a3,a4 = 0;
        public int F = 0;
        public bool snow0, snow1, snow2 = false;
        private Quaternion abc1,abc2,abc3,abc4,abc5,abc6;
        private bool c1, c2, c3, c4, c5, c6 = false;
        private bool d1 = false;
        public bool rightback, leftback, waterrocket = false;
        private bool initial = false;
        private bool e1, e2, e3, e4, e5, e6, e7 = false;
        public int count2 = 0;

        protected override void Awake()
		{
            base.Awake();
			
			_initRot = transform.localRotation;
            _curRotation = Quaternion.identity;
            _toRotation =  Quaternion.identity;
                        
            _time = 1f;
            
        }
       

        
        // Use this for initialization
        void Start ()
		{
            
            
            animator = GetComponent<Animator>();
           
            

        }

        // Update is called once per frame
        void Update()
        {


            time  += Time.deltaTime;
            time2 += Time.deltaTime;
            time3 += Time.deltaTime;

            if (_time < 1f && smoothFollow == true)
            {
                _time += Time.deltaTime;
                _curRotation = Quaternion.Lerp(_fromRotation, _toRotation, _time);
            }
            else
                _curRotation = _toRotation;

            print("시간 :" + time2);
         

            RotationReactorC _curRotation1 = GameObject.Find("RocketControl").GetComponent<RotationReactorC>(); // 1번
            RotationReactor2C _curRotation2 = GameObject.Find("RocketControl").GetComponent<RotationReactor2C>(); // 2번
            RotationReactor3C _curRotation3 = GameObject.Find("RocketControl").GetComponent<RotationReactor3C>(); // 3번
            RotationReactor4C _curRotation4 = GameObject.Find("RocketControl").GetComponent<RotationReactor4C>(); // 4번



          /*  if (d1 == false) // 센서가 connect 되면 time2가 0초로 초기화 된다.  초기화가 되면 d1 = true로 해서 더이상 초기화 되지 않도록 한다.
            {
                if (_curRotation1._curRotation.x != 0 || _curRotation2._curRotation.x != 0 || _curRotation3._curRotation.x != 0 || _curRotation4._curRotation.x != 0) // connect가 되면 if문이 실행 
                {
                    time2 = 0.0f;
                    d1 = true;
                }
            }
            */
            // 썰매운동 : 총 3개의 센서를 이용하는 경우의 수
            if ((_curRotation1._curRotation.x != 0 && _curRotation2._curRotation.x != 0 && _curRotation3._curRotation.x != 0 && _curRotation4._curRotation.x == 0) //1,2,3번 연결
               || (_curRotation1._curRotation.x != 0 && _curRotation2._curRotation.x != 0 && _curRotation3._curRotation.x == 0 && _curRotation4._curRotation.x != 0) // 1,2,4번 연결
               || (_curRotation1._curRotation.x == 0 && _curRotation2._curRotation.x != 0 && _curRotation3._curRotation.x != 0 && _curRotation4._curRotation.x != 0) // 2,3,4번 연결
               || (_curRotation1._curRotation.x != 0 && _curRotation2._curRotation.x == 0 && _curRotation3._curRotation.x != 0 && _curRotation4._curRotation.x != 0)) // 1,3,4번 연결
               {
                if (time2 > 15.0f && c3 == false) // time2 = 15  즉, connect후  15초 후에 모듈의 위치 확인 시작 
                {                               // c3 = true 가 되면 모든 모듈의 위치가 확인 되었으므로 더이상 모듈의 위치를 확인할 필요가 없음
                                                // 썰매게임 



                    if (c1 == false)  // c1의 초기값이 false 이므로 실행되고 모듈의 위치를 인식하면 true를 반환하기 때문에 if문은 한번만 실행됨
                    {

                        // print("모듈의 위치를 확인합니다."); UI  *** 모든 UI는 한번만 나오도록 해야함
                        // print("오른팔 모듈의 위치를 확인합니다.");  UI
                        // print("오른팔을 " " 해주세요.");  UI

                        if (time2 > 20.0f) // 20초 후에 오른팔 위치확인 시작
                        {
                            // print("측정을 시작합니다.");

                            // 1,2,3,4번 센서중 오른팔동작범위를 만족하는 센서가 오른팔에 부착한 센서가 됨

                            if ((Math.Abs(_curRotation1._curRotation.x) > 0.2f && Math.Abs(_curRotation1._curRotation.x) < 0.6f) //0.2 < x < 0.6 이면 오른팔
                                &&(Math.Abs(_curRotation1._curRotation.y) > 0.25f && Math.Abs(_curRotation1._curRotation.y) < 0.6f) // 0.25 < y < 0.6
                                &&(Math.Abs(_curRotation1._curRotation.z) > 0.4f && Math.Abs(_curRotation1._curRotation.z) < 0.65f)) // 0.4 < z < 0.65
                            {                                                                                                  // 손번쩍드는동작
                                a1 = 1.1; // 1번센서가 썰매운동 오른팔
                                c1 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if ((Math.Abs(_curRotation2._curRotation.x) > 0.2f && Math.Abs(_curRotation2._curRotation.x) < 0.6f) //0.2 < x < 0.6 이면 오른팔
                                && (Math.Abs(_curRotation2._curRotation.y) > 0.25f && Math.Abs(_curRotation2._curRotation.y) < 0.6f) // 0.25 < y < 0.6
                                && (Math.Abs(_curRotation2._curRotation.z) > 0.4f && Math.Abs(_curRotation2._curRotation.z) < 0.65f)) // 0.4 < z < 0.65
                            {
                                a2 = 1.1; // 2번센서가 썰매운동 오른팔
                                c1 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if ((Math.Abs(_curRotation3._curRotation.x) > 0.2f && Math.Abs(_curRotation3._curRotation.x) < 0.6f) //0.2 < x < 0.6 이면 오른팔
                                && (Math.Abs(_curRotation3._curRotation.y) > 0.25f && Math.Abs(_curRotation3._curRotation.y) < 0.6f) // 0.25 < y < 0.6
                                && (Math.Abs(_curRotation3._curRotation.z) > 0.4f && Math.Abs(_curRotation3._curRotation.z) < 0.65f)) // 0.4 < z < 0.65
                            {
                                a3 = 1.1; // 3번센서가 썰매운동 오른팔
                                c1 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if ((Math.Abs(_curRotation4._curRotation.x) > 0.2f && Math.Abs(_curRotation4._curRotation.x) < 0.6f) //0.2 < x < 0.6 이면 오른팔
                                && (Math.Abs(_curRotation4._curRotation.y) > 0.25f && Math.Abs(_curRotation4._curRotation.y) < 0.6f) // 0.25 < y < 0.6
                                && (Math.Abs(_curRotation4._curRotation.z) > 0.4f && Math.Abs(_curRotation4._curRotation.z) < 0.65f)) // 0.4 < z < 0.65
                            {
                                a4 = 1.1; // 4번센서가 썰매운동 오른팔
                                c1 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else
                            {
                                // print("오른팔 인식에 실패하였습니다. 다시 동작을 해주세요.");
                            }

                        }

                    }

                    if (c1 == true && c2 == false)  // c2의 초기값이 false 이므로 실행되고 모듈의 위치를 인식하면 true를 반환하기 때문에 if문은 한번만 실행됨
                    {

                        // print("왼팔 모듈의 위치를 확인합니다.");  UI
                        // print("왼팔을 " " 해주세요.");  UI

                        if (time2 > 40.0f) //  40초 이후부터 왼팔 위치확인 시작
                        {


                            // print("측정을 시작합니다.");

                            // 1,2,3,4번 센서중 왼팔동작범위를 만족하는 센서가 왼팔에 부착한 센서가 됨

                            if ((Math.Abs(_curRotation1._curRotation.y) > 0.4f && Math.Abs(_curRotation1._curRotation.y) < 0.8f) // 0.4 < y < 0.8
                                && (Math.Abs(_curRotation1._curRotation.z) > 0.0f && Math.Abs(_curRotation1._curRotation.z) < 0.25f)) // 0.0 < z < 0.25 이면 왼팔
                                                                                                                                      // 손을 수평으로 펴는 동작

                            {                                                                                                    
                                a1 = 1.2; // 1번센서가 썰매운동 왼팔
                                c2 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if (Math.Abs(_curRotation2._curRotation.y) > 0.4f && Math.Abs(_curRotation2._curRotation.y) < 0.8f
                                     && (Math.Abs(_curRotation2._curRotation.z) > 0.0f && Math.Abs(_curRotation2._curRotation.z) < 0.25f))
                            {
                                a2 = 1.2; // 2번센서가 썰매운동 왼팔
                                c2 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if (Math.Abs(_curRotation3._curRotation.y) > 0.4f && Math.Abs(_curRotation3._curRotation.y) < 0.8f
                                     && (Math.Abs(_curRotation3._curRotation.z) > 0.0f && Math.Abs(_curRotation3._curRotation.z) < 0.25f)) 
                            {
                                a3 = 1.2; // 3번센서가 썰매운동 왼팔
                                c2 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if (Math.Abs(_curRotation4._curRotation.y) > 0.4f && Math.Abs(_curRotation4._curRotation.y) < 0.8f
                                     && (Math.Abs(_curRotation4._curRotation.z) > 0.0f && Math.Abs(_curRotation4._curRotation.z) < 0.25f))
                            {
                                a4 = 1.2; // 4번센서가 썰매운동 왼팔
                                c2 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else
                            {
                                // print("왼팔 인식에 실패하였습니다. 다시 동작을 해주세요.");
                            }

                        }

                    }




                    if (c2 == true && c3 == false)  // c3의 초기값이 false 이므로 실행되고 모듈의 위치를 인식하면 true를 반환하기 때문에 if문은 한번만 실행됨
                    {

                        // print("등 모듈의 위치를 확인합니다.");  UI
                        // print("등을" " 해주세요.");  UI

                        if (time2 > 60.0f) // count = 3000 일 때 등 위치확인 시작
                        {
                            // print("측정을 시작합니다.");

                            // 1,2,3,4번 센서중 등 동작범위를 만족하는 센서가 등에 부착한 센서가 됨

                            if ((Math.Abs(_curRotation1._curRotation.z) > 0.0f && Math.Abs(_curRotation1._curRotation.z) < 0.3f) // 0 < z < 0.3 
                                && (Math.Abs(_curRotation1._curRotation.x) > 0.0f && Math.Abs(_curRotation1._curRotation.x) < 0.15f)   //0 < x < 0.15
                                && (Math.Abs(_curRotation1._curRotation.y) > 0.0f && Math.Abs(_curRotation1._curRotation.y) < 0.15f)) //0 < y < 0.15
                            {
                                a1 = 1.3; // 1번센서가 썰매운동 등
                                c3 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if ((Math.Abs(_curRotation2._curRotation.z) > 0.0f && Math.Abs(_curRotation2._curRotation.z) < 0.3f) // 0 < z < 0.3 
                                && (Math.Abs(_curRotation2._curRotation.x) > 0.0f && Math.Abs(_curRotation2._curRotation.x) < 0.15f)   //0 < x < 0.15
                                && (Math.Abs(_curRotation2._curRotation.y) > 0.0f && Math.Abs(_curRotation2._curRotation.y) < 0.15f)) //0 < y < 0.15
                            {
                                a2 = 1.3; // 2번센서가 썰매운동 등
                                c3 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if ((Math.Abs(_curRotation3._curRotation.z) > 0.0f && Math.Abs(_curRotation3._curRotation.z) < 0.3f) // 0 < z < 0.3 
                                && (Math.Abs(_curRotation3._curRotation.x) > 0.0f && Math.Abs(_curRotation3._curRotation.x) < 0.15f)   //0 < x < 0.15
                                && (Math.Abs(_curRotation3._curRotation.y) > 0.0f && Math.Abs(_curRotation3._curRotation.y) < 0.15f)) //0 < y < 0.15
                            {
                                a3 = 1.3; // 3번센서가 썰매운동 등
                                c3 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if ((Math.Abs(_curRotation4._curRotation.z) > 0.0f && Math.Abs(_curRotation4._curRotation.z) < 0.3f) // 0 < z < 0.3 
                                && (Math.Abs(_curRotation4._curRotation.x) > 0.0f && Math.Abs(_curRotation4._curRotation.x) < 0.15f)   //0 < x < 0.15
                                && (Math.Abs(_curRotation4._curRotation.y) > 0.0f && Math.Abs(_curRotation4._curRotation.y) < 0.15f)) //0 < y < 0.15
                            {
                                a4 = 1.3; // 4번센서가 썰매운동 등
                                c3 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else
                            {
                                // print("등 인식에 실패하였습니다. 다시 동작을 해주세요.");
                            }

                        }

                    }

                    if (c1 == true && c2 == true && c3 == true)
                    {
                        //print("모듈이 인식되었습니다.");
                    }
                }
            }

            if ((_curRotation1._curRotation.x != 0 && _curRotation2._curRotation.x != 0 && _curRotation3._curRotation.x == 0 && _curRotation4._curRotation.x == 0)   // 1,2번 연결
               || (_curRotation1._curRotation.x != 0 && _curRotation2._curRotation.x == 0 && _curRotation3._curRotation.x != 0 && _curRotation4._curRotation.x == 0) // 1,3번 연결
               || (_curRotation1._curRotation.x != 0 && _curRotation2._curRotation.x == 0 && _curRotation3._curRotation.x == 0 && _curRotation4._curRotation.x != 0) // 1,4번 연결
               || (_curRotation1._curRotation.x == 0 && _curRotation2._curRotation.x != 0 && _curRotation3._curRotation.x != 0 && _curRotation4._curRotation.x == 0) // 2,3번 연결
               || (_curRotation1._curRotation.x == 0 && _curRotation2._curRotation.x != 0 && _curRotation3._curRotation.x == 0 && _curRotation4._curRotation.x != 0) // 2,4번 연결
               || (_curRotation1._curRotation.x == 0 && _curRotation2._curRotation.x == 0 && _curRotation3._curRotation.x != 0 && _curRotation4._curRotation.x != 0))// 3,4번 연결
            {

                if (d1 == false) // 센서 3개가 connect 되면 time2가 0초로 초기화 된다.  초기화가 되면 d1 = true로 해서 더이상 초기화 되지 않도록 한다.
                {
                    time2 = 0.0f;
                    d1 = true;
                }
                if (initial == false)
                {
                    // 초기화 영상 재생
                    GameObject obj = Instantiate(Resources.Load("InitializingRocket")) as GameObject;
                    initial = true;
                }
                if (time2 > 18.0f && c5 == false) // 로켓게임 / 왼쪽다리와 오른쪽다리 모듈이 확인되면 c5가 true가 되므로 더이상 반복문이 실행되지 않는다.
                {
                    Destroy(GameObject.FindWithTag("InitializingRocket")); // 컨초_다리 영상 제거하기

                    if (c4 == false)  // c4의 초기값이 false 이므로 실행되고 모듈의 위치를 인식하면 true를 반환하기 때문에 if문은 한번만 실행됨
                    {

                        // print("오른쪽 다리 모듈의 위치를 확인합니다.");  UI
                        // print("오른쪽다리를 " " 해주세요.");  UI

                        if (time2 > 20.0f) // connect 후 20초후에 오른쪽 다리 위치확인 시작
                        {
                            // 로켓통합_01 활성화
                            if (e1 == false)
                            {
                                GameObject.Find("RocketControl").transform.Find("RTotal_01").gameObject.SetActive(true);
                                e1 = true;

                            }

                            // print("측정을 시작합니다.");

                            // 1,2,3,4번 센서중 오른쪽다리 동작범위를 만족하는 센서가 오른쪽다리에 부착한 센서가 됨

                            if (Math.Abs(_curRotation1._curRotation.z) < 0.15f && Math.Abs(_curRotation1._curRotation.z) > 0.0f)  // 0 < z < 0.15 다리운동과 동작같음
                            {
                                a1 = 2.1; // 1번센서가 로켓게임 오른쪽다리
                                c4 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if (Math.Abs(_curRotation2._curRotation.z) < 0.15f && Math.Abs(_curRotation2._curRotation.z) > 0.0f)
                            {
                                a2 = 2.1; // 2번센서가 로켓게임 오른쪽다리
                                c4 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if (Math.Abs(_curRotation3._curRotation.z) < 0.15f && Math.Abs(_curRotation3._curRotation.z) > 0.0f)
                            {
                                a3 = 2.1; // 3번센서가 로켓게임 오른쪽다리
                                c4 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if (Math.Abs(_curRotation4._curRotation.z) < 0.15f && Math.Abs(_curRotation4._curRotation.z) > 0.0f)
                            {
                                a4 = 2.1; // 4번센서가 로켓게임 오른쪽다리
                                c4 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else
                            {
                                // print("오른쪽 다리 인식에 실패하였습니다. 다시 동작을 해주세요.");
                            }

                        }

                    }

                    if (c4 == true && c5 == false)  // c5의 초기값이 false 이므로 실행되고 모듈의 위치를 인식하면 true를 반환하기 때문에 if문은 한번만 실행됨
                    {
                        GameObject.Find("RocketControl").transform.Find("RTotal_01").gameObject.SetActive(false);
                        if (e2 == false)
                        {
                            GameObject.Find("RocketControl").transform.Find("RTotal_02").gameObject.SetActive(true);
                            e2 = true;
                            time3 = 0.0f;

                        }

                        if (time3 > 2.0f)
                        {
                            GameObject.Find("RocketControl").transform.Find("RTotal_02").gameObject.SetActive(false);
                        }
                        // print("왼쪽 다리 모듈의 위치를 확인합니다.");  UI
                        // print("왼쪽다리를 " " 해주세요.");  UI

                        if (time2 > 30) // connect후 40초후에 왼쪽다리 위치확인 시작
                        {
                            
                            if (e3 == false)
                            {
                                GameObject.Find("RocketControl").transform.Find("RTotal_03").gameObject.SetActive(true);
                                e3 = true;

                            }
                            // print("측정을 시작합니다.");

                            // 1,2,3,4번 센서중 왼쪽다리 동작범위를 만족하는 센서가 왼쪽다리에 부착한 센서가 됨

                            if (Math.Abs(_curRotation1._curRotation.x) > 0.3f && Math.Abs(_curRotation1._curRotation.x) < 0.65f
                                && Math.Abs(_curRotation1._curRotation.y) > 0.3f && Math.Abs(_curRotation1._curRotation.y) < 0.65f
                                && Math.Abs(_curRotation1._curRotation.z) > 0.3f && Math.Abs(_curRotation1._curRotation.z) < 0.65f) 
                            { // 오른쪽 다리에 왼쪽다리 올리기  0.3 < x,y,z < 0.65
                                a1 = 2.2; // 1번센서가 로켓게임 왼쪽다리
                                c5 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if (Math.Abs(_curRotation2._curRotation.x) > 0.3f && Math.Abs(_curRotation2._curRotation.x) < 0.65f
                                && Math.Abs(_curRotation2._curRotation.y) > 0.3f && Math.Abs(_curRotation2._curRotation.y) < 0.65f
                                && Math.Abs(_curRotation2._curRotation.z) > 0.3f && Math.Abs(_curRotation2._curRotation.z) < 0.65f)
                            {
                                a2 = 2.2; // 2번센서가 로켓게임 왼쪽다리
                                c5 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if (Math.Abs(_curRotation3._curRotation.x) > 0.3f && Math.Abs(_curRotation3._curRotation.x) < 0.65f
                                && Math.Abs(_curRotation3._curRotation.y) > 0.3f && Math.Abs(_curRotation3._curRotation.y) < 0.65f
                                && Math.Abs(_curRotation3._curRotation.z) > 0.3f && Math.Abs(_curRotation3._curRotation.z) < 0.65f)
                            {
                                a3 = 2.2; // 3번센서가 로켓게임 왼쪽다리
                                c5 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else if (Math.Abs(_curRotation4._curRotation.x) > 0.3f && Math.Abs(_curRotation4._curRotation.x) < 0.65f
                                && Math.Abs(_curRotation4._curRotation.y) > 0.3f && Math.Abs(_curRotation4._curRotation.y) < 0.65f
                                && Math.Abs(_curRotation4._curRotation.z) > 0.3f && Math.Abs(_curRotation4._curRotation.z) < 0.65f)
                            {
                                a4 = 2.2; // 4번센서가 로켓게임 왼쪽다리
                                c5 = true;

                                // print("확인되었습니다.");  UI
                            }
                            else
                            {
                                // print("왼쪽다리 인식에 실패하였습니다. 다시 동작을 해주세요.");
                            }

                        }

                    }
                    
                }
                
            }
            if (c4 == true && c5 == true)
            {
                GameObject.Find("RocketControl").transform.Find("RTotal_03").gameObject.SetActive(false);
                if (e4 == false)
                {
                    GameObject.Find("RocketControl").transform.Find("RTotal_04").gameObject.SetActive(true);
                    e4 = true;
                    //print("모듈이 인식되었습니다.");
                }

                count2++;
            }

            print(count2);

            if (count2 == 200)
            {
                GameObject.Find("RocketControl").transform.Find("RTotal_04").gameObject.SetActive(false);
            }
            if ((_curRotation1._curRotation.x != 0 && _curRotation2._curRotation.x == 0 && _curRotation3._curRotation.x == 0 && _curRotation4._curRotation.x == 0)   // 1번 연결
               || (_curRotation1._curRotation.x == 0 && _curRotation2._curRotation.x != 0 && _curRotation3._curRotation.x == 0 && _curRotation4._curRotation.x == 0) // 2번 연결
               || (_curRotation1._curRotation.x == 0 && _curRotation2._curRotation.x == 0 && _curRotation3._curRotation.x != 0 && _curRotation4._curRotation.x == 0) // 3번 연결
               || (_curRotation1._curRotation.x == 0 && _curRotation2._curRotation.x == 0 && _curRotation3._curRotation.x == 0 && _curRotation4._curRotation.x != 0)) // 4번 연결

            {

                if (time2 > 15.0f && c6 == false)  // 외줄타기게임  connect 후 15초후에 모듈위치확인 시작
                                                 // c6의 초기값이 false 이므로 실행되고 모듈의 위치를 인식하면 true를 반환하기 때문에 if문은 한번만 실행됨
                {

                    // print("허리 모듈의 위치를 확인합니다.");  UI
                    // print("허리를 " " 해주세요.");  UI

                    if (time2 > 20.0f) // 20초 후에  허리 위치확인 시작
                    {

                        // print("측정을 시작합니다.");

                        // 1,2,3,4번 센서중 허리동작범위를 만족하는 센서가 허리에 부착한 센서가 됨

                        if (Math.Abs(_curRotation1._curRotation.y) > 0.3f && Math.Abs(_curRotation1._curRotation.y) < 0.6f) // 0.3 < y < 0.6 
                           
                        {
                            a1 = 3.1; // 1번센서가 외줄타기게임 허리
                            c6 = true;

                            // print("확인되었습니다.");  UI
                        }
                        else if (Math.Abs(_curRotation2._curRotation.y) > 0.3f && Math.Abs(_curRotation2._curRotation.y) < 0.6f)
                        {
                            a2 = 3.1; // 2번센서가 외줄타기게임 허리
                            c6 = true;

                            // print("확인되었습니다.");  UI
                        }
                        else if (Math.Abs(_curRotation3._curRotation.y) > 0.3f && Math.Abs(_curRotation3._curRotation.y) < 0.6f)
                        {
                            a3 = 3.1; // 3번센서가 외줄타기게임 허리
                            c6 = true;

                            // print("확인되었습니다.");  UI
                        }
                        else if (Math.Abs(_curRotation4._curRotation.y) > 0.3f && Math.Abs(_curRotation4._curRotation.y) < 0.6f)
                        {
                            a4 = 3.1; // 4번센서가 외줄타기게임 허리
                            c6 = true;

                            // print("확인되었습니다.");  UI
                        }
                        else
                        {
                            // print("허리 인식에 실패하였습니다. 다시 동작을 해주세요.");
                        }

                    }
                    if (c6 == true)
                    {
                        //print("모듈이 인식되었습니다.");
                    }

                }
            }
           

            print(count);
            Debug.Log("c1 :" + c1 + " / " + "c2 :" + c2 + " / " + "c3 :" + c3 + " / " + "c4 :" + c4 + " / " + "c5 :" + c5 + " / " + "c6 :" + c6);
            Debug.Log("a1 :" + a1 + " / " + "a2 :" + a2 + " / " + "a3 :" + a3 + " / " + "a4 :" + a4);



           // if (F == 1) { // 썰매게임
                if (a1 == 1.1) // 썰매운동 오른팔
                {
                    abc1 = _curRotation1._curRotation;

                }

                if (a2 == 1.1)
                {
                    abc1 = _curRotation2._curRotation;

                }

                if (a3 == 1.1)
                {
                    abc1 = _curRotation3._curRotation;

                }

                if (a4 == 1.1)
                {
                    abc1 = _curRotation4._curRotation;

                }

                if (a1 == 1.2)  // 썰매운동 왼팔
                {
                    abc2 = _curRotation1._curRotation;

                }

                if (a2 == 1.2)
                {
                    abc2 = _curRotation2._curRotation;

                }

                if (a3 == 1.2)
                {
                    abc2 = _curRotation3._curRotation;

                }

                if (a4 == 1.2)
                {
                    abc2 = _curRotation4._curRotation;

                }



                if (a1 == 1.3)   // 썰매운동 허리
                {
                    abc3 = _curRotation1._curRotation;

                }

                if (a2 == 1.3)
                {
                    abc3 = _curRotation2._curRotation;

                }

                if (a3 == 1.3)
                {
                    abc3 = _curRotation3._curRotation;

                }
                if (a4 == 1.3)
                {
                    abc3 = _curRotation4._curRotation;

                }
           // }

          //  if (F == 2) {// 다리운동게임
            
                if (a1 == 2.1) // 오른쪽 다리
                {
                    abc4 = _curRotation1._curRotation;

                }

                if (a2 == 2.1)
                {
                    abc4 = _curRotation2._curRotation;

                }

                if (a3 == 2.1)
                {
                    abc4 = _curRotation3._curRotation;

                }

                if (a4 == 2.1)
                {
                    abc4 = _curRotation4._curRotation;

                }

                if (a1 == 2.2) // 왼쪽 다리
                {
                    abc5 = _curRotation1._curRotation;

                }

                if (a2 == 2.2)
                {
                    abc5 = _curRotation2._curRotation;

                }

                if (a3 == 2.2)
                {
                    abc5 = _curRotation3._curRotation;

                }

                if (a4 == 2.2)
                {
                    abc5 = _curRotation4._curRotation;

                }

          //  }

              //  if (F == 3){ // 허리운동게임                        
                    if (a1 == 3.1) // 허리
                    {
                        abc6 = _curRotation1._curRotation;

                    }

                    if (a2 == 3.1)
                    {
                        abc6 = _curRotation2._curRotation;

                    }

                    if (a3 == 3.1)
                    {
                        abc6 = _curRotation3._curRotation;

                    }

                    if (a4 == 3.1)
                    {
                        abc6 = _curRotation4._curRotation;

                    }
              //  }









           
                if (decision == 0) // 팔운동1 
                {
                    if (Math.Abs(abc1.y) < 0.45f && Math.Abs(abc1.y) > 0.4f      //  오른팔 y: 0.45 < 현재값 < 0.8
                          && Math.Abs(abc2.y) < 0.45f && Math.Abs(abc2.y) > 0.4f) //  왼팔 y: 0.45 < 현재값 < 0.8
                    {

                        //animator.Play("Makehuman_gameskel|gun_game_1_bullet", -1, 0);  // 팔운동1 애니메이션 실행
                        
                        decision++;  // 팔운동 1 애니메이션이 실행되면 팔운동2 애니메이션이 실행될수있도록 decision = 1로 바꿔준다.
                        snow0 = true;
                        snow2 = false;

                    }
                }
            

            else { }

           // print("1번" + snow0);

           // print("카운트값1: " + decision);


                if (decision == 1) // 팔운동2
                {
                                                                                                                                    // 오른팔 y : 0 < 현재값 < 0.3
                    if (Math.Abs(abc1.x) < 0.8f && Math.Abs(abc1.x) > 0.4f && Math.Abs(abc1.y) < 0.3f && Math.Abs(abc1.y) > 0.0f    // 오른팔 x : 0.4 < 현재값 < 0.8 
                     && Math.Abs(abc2.x) < 0.8f && Math.Abs(abc2.x) > 0.4f && Math.Abs(abc2.y) < 0.3f && Math.Abs(abc2.y) > 0.0f) //  왼팔 x: 0.4 < 현재값 < 0.8
                                                                                                                                  // 오른팔 y : 0 < 현재값 < 0.3
                    {  

                        //animator.Play("Makehuman_gameskel|gun_game_2_sholder", -1, 0); // 팔운동2 애니메이션 실행
                        snow1 = true;
                        snow0 = false;
                        
                        decision++; // 팔운동2 애니메이션이 실행되면 팔운동3 애니메이션이 실행될수있도록 decision = 2로 바꿔준다.
                    }
                }
            

           

           // print("카운트값2: " + decision);

           // print("2번" + snow1);

            
                if (decision == 2)  // 팔운동3
                {
                    if (Math.Abs(abc3.z) < 0.4f && Math.Abs(abc3.z) > 0.0f) // 등 z: 0  < 현재값 < 0.4f


                    {

                        //animator.Play("Makehuman_gameskel|gun_game_4_win", -1, 0); // 팔운동3 애니메이션 실행
                        snow2 = true;
                        snow1 = false;
                       
                        decision = 0; // 팔운동3 애니메이션이 실행되면 팔운동1 애니메이션이 실행될수있도록 decision = 0 으로 바꿔준다.

                    }
                }



            if ((Math.Abs(abc4.z) < 0.2f || Math.Abs(abc5.z) < 0.2f)  // 오른쪽 다리 z : 0 < 현재값 < 0.2
                 && (Math.Abs(abc4.z) > 0.0f || Math.Abs(abc5.z) > 0.0f)) // 왼쪽다리 z : 0 < 현재값 < 0.2
            
            {                                                                // Math.Abs(abc4.z) > 0.0f 조건은 캘레브레이션이 되기 전에 첫번째 조건을 
                                                                             // 만족해서 애니메이션이 실행되는것을 방지하기 위함
                waterrocket = true;
            }


            else
            {   
               
                waterrocket = false;
            }





            // 허리운동조건 : 0.1 < x < 0.4  and 0.3 < y < 0.6  왼쪽 오른쪽 같음

            if (( 0.1f < Math.Abs(abc6.x) && Math.Abs(abc6.x) < 0.4f)
                   &&( 0.3f < Math.Abs(abc6.y) &&  Math.Abs(abc6.y) < 0.6f))
                {
                    if ((abc6.x + abc6.y + abc6.z < - 0.9f) || (abc6.x + abc6.y + abc6.z > 0.9f))  // 왼쪽
                    {                                                                                                       // x+y+z > 0.9 or x+y+z < -0.9
                        leftback = true;
                        //animator.Play("abc6|Rope_2_Right_back", -1, 0);
                        
                    }
                    else                                                          // 오른쪽조건 :  -0.9 < x+y+z < 0.9
                    {
                        rightback = true;
                        //animator.Play("180725_makehuman_model|Rope_1_Left_back", -1, 0);
                        
                    }
                }
                else
                {
                    leftback = false;
                    rightback = false;
                }
            
            //  print("3번" + snow2);


            // print("카운트값3: " + decision);

            print("1번 :" + snow0 + "2번 :" + snow1 + "3번 :" + snow2);

            print(decision);

           // if (count1 > 0)   //다리운동할때는 주석처리 / 허리와 팔은 필요함 
            //{
              //  time = 0.0f;
                
                //count1 = 0;
            //}
          //  print(time);

            
           


        }




      
       


        private void OnRotationChanged(Quaternion q)
        {
            _fromRotation = _toRotation;
			_toRotation =  q;
            
            _time = 0f;
        }
		
		protected override void AddNode(List<Node> nodes)
        {
			base.AddNode(nodes);
			
			nodes.Add(new Node("rotation", "Rotation", typeof(IWireInput<Quaternion>), NodeType.WireFrom, "Input<Quaternion>"));
        }
        
        protected override void UpdateNode(Node node)
        {
            if(node.name.Equals("rotation"))
            {
                node.updated = true;
                if(node.objectTarget == null && _rotation == null)
                    return;
                
                if(node.objectTarget != null)
                {
                    if(node.objectTarget.Equals(_rotation))
                        return;
                }
                
                if(_rotation != null)
                    _rotation.OnWireInputChanged -= OnRotationChanged;
                
                _rotation = node.objectTarget as IWireInput<Quaternion>;
                if(_rotation != null)
                    _rotation.OnWireInputChanged += OnRotationChanged;
                else
                    node.objectTarget = null;
                
                return;
            }
            
            base.UpdateNode(node);
        }


	}
}
