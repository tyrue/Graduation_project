//using UnityEngine;
//using System.Collections.Generic;
//using System;





//namespace Ardunity
//{
    
//    [AddComponentMenu("ARDUnity/Reactor/Transform/RotationReactor2")]
//    [HelpURL("https://sites.google.com/site/ardunitydoc/references/reactor/rotationreactor")]
//	public class RotationReactor2R : ArdunityReactor
//	{

        
         
        
//        public Animator animator;
//        public bool smoothFollow = true;

//        float time = 0.0f;
//        float time2 = 0.0f;
//		private Quaternion _initRot;
//		private IWireInput<Quaternion> _rotation;
//        private Quaternion _curRotation;
//		private Quaternion _fromRotation;
//		private Quaternion _toRotation;
//		private float _time;
//        private Quaternion a;
//        private bool k = true;
//        private int count = 0;
//        private int count1 = 0;
//        private int decision = 0;
//        public bool rightback = false;
//        public bool leftback = false;
//        protected override void Awake()
//		{
//            base.Awake();
			
//			_initRot = transform.localRotation;
//            _curRotation = Quaternion.identity;
//            _toRotation =  Quaternion.identity;
                        
//            _time = 1f;
            
//        }
       

        
//        // Use this for initialization
//        void Start ()
//		{
            
            
//            animator = GetComponent<Animator>();
           
            

//        }

//        // Update is called once per frame
//        void Update()
//        {


//            time += Time.deltaTime;
            

//            if (_time < 1f && smoothFollow == true)
//            {
//                _time += Time.deltaTime;
//                _curRotation = Quaternion.Lerp(_fromRotation, _toRotation, _time);
//            }
//            else
//                _curRotation = _toRotation;
//            //  print(_curRotation.x);
           
//            Debug.Log("2번"+"x:"+_curRotation.x+" / "+"y:"+_curRotation.y+" / "+"z:"+_curRotation.z+" / "+"w:"+_curRotation.w);

//            //RotationReactor _curRotation2 = GameObject.Find("Robot").GetComponent<RotationReactor>(); // 1번
//            //RotationReactor3 _curRotation3 = GameObject.Find("Robot").GetComponent<RotationReactor3>(); // 3번
//            //RotationReactor4 _curRotation4 = GameObject.Find("Robot").GetComponent<RotationReactor4>(); // 4번

//            //print(_curRotation2._curRotation);
//            //print(_curRotation3._curRotation);
//            if (_curRotation.x != 0)
//            {
//                count++;
//            }
//            if (count == 1000)
//            {
//                a = _curRotation;
//                //print(a);
//                //transform.localRotation = _initRot * _curRotation;
//                // k = false;
                

//            }
//            Debug.Log("초기값" + "x:" + a.x + " / " + "y:" + a.y + " / " + "z:" + a.z + " / " + "w:" + a.w);
//            //print(a);



//            /*
//            if (time >= 3.5f)
//            {
//                if (_curRotation.x > 0.3f + a.x)
//                {
//                    animator.Play("Wave", -1, 0);
//                    count1++;
//                }
//            }
//            else { }

//            if (time >= 3.5f)
//            {
//                if (-0.3f + a.x > _curRotation.x)
//                {
//                    animator.Play("HumanoidCrouchIdle", -1, 0);
                   
//                    count1++;              
//                }
//            }
//            else { }
//            */
//            /*
//                if ((Math.Abs(_curRotation.z) <  0.15f || Math.Abs(_curRotation3._curRotation.z) <  0.15f) 
//                   &&( Math.Abs(a.z) > 0.0f || Math.Abs(_curRotation3.a.z) > 0.0f))  
//                                                                                  // 다리운동조건:  2번 : 0 < 현재값 < 0.15f or 3번 : 0 < 현재값 < 0.15f
//                {                                                                // Math.Abs(a.z) > 0.0f 조건은 캘레브레이션이 되기 전에 첫번째 조건을 
//                    count1++;                                                    // 만족해서 애니메이션이 실행되는것을 방지하기 위함

//                    if (count1 == 1)  // 다리운동 조건을 만족하면 count1 = 1이 된다.
//                    {
//                        time = 0.0f;  // 조건만족시 시간 초기화

                        
//                    }
                    

//                }
            
//            else {  // 5초를 버티지 못하고 다리가 내려가면 다시 시간이 초기화된다. 즉 도중에 다리가 내려갔을 경우 시간을 초기화시켜 5초이상일때 실행되는 
//                time = 0.0f;                                                       // 애니메이션이 실행되지 않도록 한다.
                
//            }

//            print("다리운동지속시간 :" + time);

//            if (time > 5)   // 조건을 5초이상 만족하고 있으면 특정 애니메이션이 실행된다.
//            {
//                animator.Play("180725_makehuman_model|Yaba_1_throw", -1, 0);
//                time = 0.0f;  // 애니메이션이 동작하면 다시 시간을 초기화 시켜준다.
//            }

            
//            */





//            /*
            
//            if (time >= 3.5f) 
//                {
//                if (decision == 0) // 팔운동1 
//                {
//                    if ((Math.Abs(_curRotation2._curRotation.z) < 0.2f) && (Math.Abs(_curRotation.z) < 0.2f) //  1번 : 0 < 현재값 < 0.2f 
//                                                                                                             // and 2번 : 0 < 현재값 < 0.2f 
//                        && (Math.Abs(_curRotation3._curRotation.z) < 0.15f) && (Math.Abs(_curRotation4._curRotation.z) < 0.15f)) //and 3번 : 0 < 현재값 < 0.15f
//                                                                                                                                 //and 4번 : 0 < 현재값 < 0.15f
//                    {

//                        animator.Play("180725_makehuman_model|Gun_1_sholder", -1, 0);  // 팔운동1 애니메이션 실행
//                        count1++;
//                        decision++;  // 팔운동 1 애니메이션이 실행되면 팔운동2 애니메이션이 실행될수있도록 decision = 1로 바꿔준다.

//                    }
//                }
//                }
            
//            else { }

//           // print("카운트값1: " + decision);
            
            
//                if (time >= 3.5f) 
//                {
//                if (decision == 1) // 팔운동2
//                {

//                    if ( (Math.Abs(_curRotation2._curRotation.z) > 0.35f) // 1번 : 현재값 > 0.35f 
//                        && ( Math.Abs(_curRotation2._curRotation.z) - Math.Abs(_curRotation.z) > 0.3f)  // and 1번 현재값 - 2번 현재값 > 0.3f 
//                        && (Math.Abs(_curRotation3._curRotation.z) < 0.15f) && (Math.Abs(_curRotation4._curRotation.z) > 0.3f))
//                    {   // and 3번 : 현재값 < 0.15f  and 4번 : 현재값 > 0.3f 

//                        animator.Play("180725_makehuman_model|Gun_2_shot", -1, 0); // 팔운동2 애니메이션 실행
//                        count1++;
//                        decision++; // 팔운동2 애니메이션이 실행되면 팔운동3 애니메이션이 실행될수있도록 decision = 2로 바꿔준다.
//                    }
//                }
//                }
            
//            else { }

//           // print("카운트값2: " + decision);
            
            
            
//                if (time >= 3.5f) 
//                {
//                if (decision == 2)  // 팔운동3
//                {

//                    if (Math.Abs(_curRotation2._curRotation.z) > 0.3f && Math.Abs(_curRotation.z) > 0.2f  // 1번 : 현재값 > 0.3f  and 2번 : 현재값 > 0.2f
//                        && Math.Abs(_curRotation3._curRotation.z) - Math.Abs(_curRotation4._curRotation.z) < 0.15f  // -0.15f < 3번 현재값 - 4번 현재값 < 0.15f
//                        && Math.Abs(_curRotation3._curRotation.z) - Math.Abs(_curRotation4._curRotation.z) > - 0.15f)

//                    {

//                        animator.Play("180725_makehuman_model|Gun_3_win", -1, 0);  // 팔운동3 애니메이션 실행
//                        count1++;
//                        decision++;  // 팔운동3 애니메이션이 실행되면 팔운동4 애니메이션이 실행될수있도록 decision = 3으로 바꿔준다.
//                    }
//                }
//                }

//           // print("카운트값3: " + decision);

//            if (time >= 3.5f)
//            {
//                if (decision == 3)  // 팔운동4
//                {
//                    if (Math.Abs(_curRotation2._curRotation.z) > 0.55f && Math.Abs(_curRotation.z) > 0.4f // 1번 : 현재값 > 0.55f and 2번 : 현재값 > 0.4f 
//                        && Math.Abs(_curRotation3._curRotation.z) > 0.5f && Math.Abs(_curRotation4._curRotation.z) > 0.5f ) //and 3번 : 현재값 > 0.5f and 4번 : 현재값 > 0.5f

//                    {

//                        animator.Play("Wave", -1, 0); // 팔운동4 애니메이션 실행
//                        count1++;
//                        decision = 0; // 팔운동4 애니메이션이 실행되면 팔운동1 애니메이션이 실행될수있도록 decision = 0 으로 바꿔준다.

//                    }
//                }
//            }

//            else { }

//           // print("카운트값4: " + decision);

//            */



//            if (time >= 2.0f) // 허리운동조건 : 2번 0.1 < 현재값(x) < 0.4  and 0.3 < 현재값(y) < 0.6  왼쪽 오른쪽 같음
//            {
//                if (Math.Abs(a.x) + 0.1f < Math.Abs(_curRotation.x) && Math.Abs(a.y) + 0.3f < Math.Abs(_curRotation.y) &&
//                    Math.Abs(a.x) + 0.4f > Math.Abs(_curRotation.x) && Math.Abs(a.y) + 0.6f > Math.Abs(_curRotation.y))
//                {
//                    if ((_curRotation.x + _curRotation.y + _curRotation.z < -1.0f) || (_curRotation.x + _curRotation.y + _curRotation.z > 1.0f))  // 왼쪽
//                    {
//                        // x+y+z >1 or x+y+z <-1
//                        leftback = true;
//                        //animator.Play("180725_makehuman_model|Rope_2_Right_back", -1, 0);
//                        count1++;
//                    }
//                    else                                                          // 오른쪽조건 :  -1 < x+y+z < 1
//                    {
//                        rightback = true;
//                        animator.Play("180725_makehuman_model|Rope_1_Left_back", -1, 0);
//                        count1++;
//                    }
//                }
//                else
//                {
//                    rightback = false;
//                    leftback = false;
//                }
//            }

            
//            if (count1 > 0)   //다리운동할때는 주석처리 / 허리와 팔은 필요함 
//            {
//                time = 0.0f;
                
//                count1 = 0;
//            }
//            print(time);
            

//        }








//        private void OnRotationChanged(Quaternion q)
//        {
//            _fromRotation = _toRotation;
//			_toRotation =  q;
            
//            _time = 0f;
//        }
		
//		protected override void AddNode(List<Node> nodes)
//        {
//			base.AddNode(nodes);
			
//			nodes.Add(new Node("rotation", "Rotation", typeof(IWireInput<Quaternion>), NodeType.WireFrom, "Input<Quaternion>"));
//        }
        
//        protected override void UpdateNode(Node node)
//        {
//            if(node.name.Equals("rotation"))
//            {
//                node.updated = true;
//                if(node.objectTarget == null && _rotation == null)
//                    return;
                
//                if(node.objectTarget != null)
//                {
//                    if(node.objectTarget.Equals(_rotation))
//                        return;
//                }
                
//                if(_rotation != null)
//                    _rotation.OnWireInputChanged -= OnRotationChanged;
                
//                _rotation = node.objectTarget as IWireInput<Quaternion>;
//                if(_rotation != null)
//                    _rotation.OnWireInputChanged += OnRotationChanged;
//                else
//                    node.objectTarget = null;
                
//                return;
//            }
            
//            base.UpdateNode(node);
//        }


//	}
//}
