using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 버튼 비활성화 기능 사용하기 위함
using UnityEngine.SceneManagement;

public class Manual : MonoBehaviour {

    int isPlaying = 0; // 설명 재생 여부를 저장하는 변수

    // 각 버튼들
    public Button LegButton;
    public Button WaistButton;
    public Button ArmButton;

    // '이전 화면으로' 버튼 배치를 위한 변수(maxscreen용)
    int w = Screen.width;
    int h = Screen.height;
    

    public void Manual_Leg()
    {

        isPlaying = 1;

        GameObject.Find("movie").transform.Find("arm").gameObject.SetActive(false);
        GameObject.Find("movie").transform.Find("waist").gameObject.SetActive(false);
        GameObject.Find("movie").transform.Find("leg").gameObject.SetActive(false);


        GameObject.Find("movie").transform.Find("leg").gameObject.SetActive(true);

        /*
        Destroy(GameObject.Find("arm(Clone)"));
        Destroy(GameObject.Find("waist(Clone)"));
        Destroy(GameObject.Find("leg(Clone)"));

        GameObject obj = Instantiate(Resources.Load("leg")) as GameObject;

        // 모든 버튼들을 눌리지 못하게 처리(중복 재생 방지)
        //WaistButton.interactable = false;
        //ArmButton.interactable = false;
        //LegButton.interactable = false;

        //OnGUI();
        */
    }

    public void Manual_Waist()
    {
        
        isPlaying = 1;

        GameObject.Find("movie").transform.Find("arm").gameObject.SetActive(false);
        GameObject.Find("movie").transform.Find("waist").gameObject.SetActive(false);
        GameObject.Find("movie").transform.Find("leg").gameObject.SetActive(false);


        GameObject.Find("movie").transform.Find("waist").gameObject.SetActive(true);

        /*
        Destroy(GameObject.Find("arm(Clone)"));
        Destroy(GameObject.Find("waist(Clone)"));
        Destroy(GameObject.Find("leg(Clone)"));

        GameObject obj = Instantiate(Resources.Load("waist")) as GameObject;

        //WaistButton.interactable = false;
        //ArmButton.interactable = false;
        //LegButton.interactable = false;

        //OnGUI();
        */
    }

    public void Manual_Arm()
    {
        //GameObject obj = Instantiate(Resources.Load("arm")) as GameObject;

        isPlaying = 1;

        GameObject.Find("movie").transform.Find("arm").gameObject.SetActive(false);
        GameObject.Find("movie").transform.Find("waist").gameObject.SetActive(false);
        GameObject.Find("movie").transform.Find("leg").gameObject.SetActive(false);


        GameObject.Find("movie").transform.Find("arm").gameObject.SetActive(true);

        /*
        Destroy(GameObject.Find("arm(Clone)"));
        Destroy(GameObject.Find("waist(Clone)"));
        Destroy(GameObject.Find("leg(Clone)"));

        GameObject obj = Instantiate(Resources.Load("arm")) as GameObject;

        //WaistButton.interactable = false;
        //ArmButton.interactable = false;
        //LegButton.interactable = false;

        //OnGUI();
        */
    }

    /*
    public void OnGUI()
    {
        // maximize on play 버튼 눌렀을 때 화면 크기에 맞게 버튼 생성 (컴퓨터 모니터의 크기에 따라 오브젝트들이나 버튼들의 위치가 달라지는데 이 부분은 최종 합친 후에 해결해야 할 것 같음)
        //if (GUI.Button(new Rect(w/(1.19f), h / 8, w / 16, h / 20), "이전 화면으로"))

        if (isPlaying == 1) // 재생 중일 경우에만 '이전 화면으로' 버튼 생성
        {
            
            //if (GUI.Button(new Rect(630, 10, 100, 30), "이전 화면으로"))
            if (GUI.Button(new Rect(w / (1.19f), h / 8, w / 16, h / 20), "이전 화면으로"))
            {
                SceneManager.LoadScene("manual");
            }
        }
    }
    */
}


