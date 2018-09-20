using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ardunity
{
    public class TargetCollision : MonoBehaviour
    {

        public GameObject explosion;
        public GameObject rocket;
        public GameObject target1;
        public GameObject target2;
        public GameObject target3;
        public GameObject target4;
        public GameObject mainCamera;
        private int target_find;
        private bool target_bool;


        // Use this for initialization
        public void Start()
        {
            //mainCamera = GameObject.Find("Main Camera");
            //9월 11일 초기화 추가
            target1.SetActive(true);
            target2.SetActive(true);
            target3.SetActive(true);
            target4.SetActive(true);
            target_bool = false;
        }

        // Update is called once per frame
        void Update()
        {
            /*if (this.tag == "target")
                target_find = 1;
            if (this.tag == "target (1)")
                target_find = 2;
            if (this.tag == "target (2)")
                target_find = 3;
            if (this.tag == "target (3)")
                target_find = 4;*/
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.collider.tag == "rocket")
            {
                rocket.GetComponent<RocketMove>().mainCameraOn();
                rocket.GetComponent<RocketMove>().setRocketLaunchReady(false);

                GameObject newExplosion =
                    Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), this.transform.rotation) as GameObject;

                int rand_che = mainCamera.GetComponent<GameDirector>().getRandom_number();

                //if (rand_che != target_find)
                //{
                    //9월 11일 초기화 추가
                    if (rand_che == 1)
                    {
                        //Destroy(target1);
                        target1.SetActive(false);
                    }
                        
                    if (rand_che == 2)
                    {
                        //Destroy(target2);
                        target2.SetActive(false);
                    }
                        
                    if (rand_che == 3)
                    {
                        //Destroy(target3);
                        target3.SetActive(false);
                    }
                        
                    if (rand_che == 4)
                    {
                        //Destroy(target4);
                        target4.SetActive(false);
                    }
                        

                    //GameObject newtarget = Instantiate(target, this.transform.position, this.transform.rotation) as GameObject;
                //}
                //else // 맞춘 타겟과 초록 점이 일치할 때
                //{
                    //9월 11일 초기화 추가
                //    this.gameObject.SetActive(false);
                //    //Destroy(this.gameObject);
                //    mainCamera.GetComponent<GameDirector>().setPlusPoint(50);
                //}

                mainCamera.GetComponent<GameDirector>().setRandom_check(false);
            }
        }

        public bool getTargetBool()
        {
            return target_bool;
        }

        public void setTargetBool(bool bo)
        {
            target_bool = bo;
        }
    }
}