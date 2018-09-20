using UnityEngine;
using System.Collections.Generic;
using System;





namespace Ardunity
{
    

        [AddComponentMenu("ARDUnity/Reactor/Transform/RotationReactor2B")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/reactor/rotationreactor")]
	public class RotationReactor2B : ArdunityReactor
    {

        
         
        
        public Animator animator;
        public bool smoothFollow = true;

        float time = 0.0f;
        float time2 = 0.0f;
		private Quaternion _initRot;
		private IWireInput<Quaternion> _rotation;
        public Quaternion _curRotation;
		private Quaternion _fromRotation;
		private Quaternion _toRotation;
		private float _time;
        private Quaternion a;
        private bool k = true;
        private int count = 0;
        private int count1 = 0;
        private int decision = 0;
        public bool rightback = false;
        public bool leftback = false;
        public bool snow0,snow1,snow2 = false;

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


            time += Time.deltaTime;
            

            if (_time < 1f && smoothFollow == true)
            {
                _time += Time.deltaTime;
                _curRotation = Quaternion.Lerp(_fromRotation, _toRotation, _time);
            }
            else
                _curRotation = _toRotation;
            //  print(_curRotation.x);
           
            Debug.Log("2번"+"x:"+_curRotation.x+" / "+"y:"+_curRotation.y+" / "+"z:"+_curRotation.z+" / "+"w:"+_curRotation.w);

           // RotationReactor _curRotation1 = GameObject.Find("snow").GetComponent<RotationReactor>(); // 1번
            //RotationReactor3 _curRotation3 = GameObject.Find("snow").GetComponent<RotationReactor3>(); // 3번
            //RotationReactor4 _curRotation4 = GameObject.Find("snow").GetComponent<RotationReactor4>(); // 4번

            //print(_curRotation2._curRotation);
            //print(_curRotation3._curRotation);
            if (_curRotation.x != 0)
            {
                count++;
            }
            if (count == 800)
            {
                a = _curRotation;
                //print(a);
                //transform.localRotation = _initRot * _curRotation;
                // k = false;
                

            }
            //Debug.Log("2번초기값" + "x:" + a.x + " / " + "y:" + a.y + " / " + "z:" + a.z + " / " + "w:" + a.w);
            //print(a);



            
                   

           
           

          



           






         

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
