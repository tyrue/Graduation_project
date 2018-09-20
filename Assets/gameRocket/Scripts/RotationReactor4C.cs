using UnityEngine;
using System.Collections.Generic;






namespace Ardunity
{

    [AddComponentMenu("ARDUnity/Reactor/Transform/RotationReactor4C")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/reactor/rotationreactor")]
    public class RotationReactor4C : ArdunityReactor
    {




        public Animator animator;
        public bool smoothFollow = true;

        float time = 0.0f;
        private Quaternion _initRot;
        private IWireInput<Quaternion> _rotation;
        public Quaternion _curRotation;
        private Quaternion _fromRotation;
        private Quaternion _toRotation;
        private float _time;
        public Quaternion a;
        private bool k = true;
        private int count = 0;
        private int count1 = 0;

        protected override void Awake()
        {
            base.Awake();

            _initRot = transform.localRotation;
            _curRotation = Quaternion.identity;
            _toRotation = Quaternion.identity;

            _time = 1f;

        }



        // Use this for initialization
        void Start()
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
            // print(_curRotation);

            Debug.Log("4번"+"x:" + _curRotation.x + " / " + "y:" + _curRotation.y + " / " + "z:" + _curRotation.z + " / " + "w:" + _curRotation.w);

            if (_curRotation.x != 0)
            {
                count++;
            }
            if (count == 800)
            {
                a = _curRotation;
                //print(a);
                //transform.localRotation = _initRot * _curRotation;
                //k = false;

            }
            Debug.Log("4번초기값" + "x:" + a.x + " / " + "y:" + a.y + " / " + "z:" + a.z + " / " + "w:" + a.w);
            //print(a);


/*
            if (time >= 3.5f)
            {
                if (_curRotation.x > 0.3f + a.x)
                {
                    animator.Play("Wave", -1, 0);
                    count1++;
                }
            }
            else { }

            if (time >= 3.5f)
            {
                if (-0.3f + a.x > _curRotation.x)
                {
                    animator.Play("HumanoidCrouchIdle", -1, 0);

                    count1++;
                }
            }
            else { }

            if (time >= 3.5f)
            {
                if (((_curRotation.x < 0.1f + a.x) && (_curRotation.x > -0.1f + a.x)) && ((_curRotation.y > 1.2f + a.y) && (_curRotation.y < 1.5f + a.y))
                    && ((_curRotation.z > 0.6f + a.z) && (_curRotation.z < 0.9f + a.z)))
                {

                    animator.Play("Wave", -1, 0);
                    count1++;

                }
            }
            else { }
            */
            if (count1 == 1)
            {
                time = 0.0f;

                count1 = 0;
            }
            //print(time);


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
