using Ardunity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject Target;
    public GameObject vrCam;
    public float dist = 10f;
    public float height= 5f;
    public float smoothRotate = 5.0f;

    private Player player;
    int count;

    Vector3 cameraPo;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>(); // 플레이어 스크립트 객체
        vrCam = GameObject.Find("VRCamera");
    }

    private void LateUpdate()
    {
        if (!player.isCollEnemy)
        {
            float currYAngle = Mathf.LerpAngle(transform.eulerAngles.y, Target.transform.eulerAngles.y, smoothRotate * Time.deltaTime);
            Quaternion rot = Quaternion.Euler(0, currYAngle, 0);
            transform.position = Target.transform.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
            transform.LookAt(Target.transform);
            transform.Rotate(-20, 0, 0);                
        }
    }
}
