using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    //적 캐릭터에게 필요한 컴포넌트들
    private float time; // 적 생존 시간

    //적 캐릭터에게 필요한 변수들
    public enum State {wait, spown, gameover }; // 상태 집합, 대기, 발사, 게임 끝
    public State enemyState = State.wait; // 처음에는 평상 
    public GameObject explosion;   // 폭발 효과
    private AudioSource audiosource;

    public GameObject UIObj;

    // Use this for initialization 초기화
    void Awake()
    {
        UIObj = GameObject.Find("Game_UI");        // UI 오브젝트
        audiosource = GetComponent<AudioSource>(); // 오디오
    }

    void OnEnable() // 활성화 상태 때마다
    {
        enemyState = State.spown; // 스폰 상태
        time = Time.time + 20f;
        StartCoroutine(this.CheckEnemyState());
    }

    IEnumerator CheckEnemyState()
    {
        while (enemyState != State.gameover)    // 여기다가 게임이 끝날 때 상황도 넣자
        {
            switch (enemyState)
            {
                case State.spown:
                    // 장애물이 스폰된다. 장애물의 위치는 플레이어 정면에서 좌, 중, 우 중 하나에서 랜덤하게 생성됨
                    if (Time.time > time)    // 일정 시간이 지나면 자동으로 없앰
                    {
                        audiosource.Play();
                        Destroy(this.gameObject);
                        GameObject newExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation) as GameObject;
                        newExplosion.transform.Translate(Vector3.up * 1.3f);
                        Destroy(newExplosion, 1.2f);
                    }
                        
                    break;
            }
            yield return null;
        }
    }

    void OnCollisionEnter(Collision coll) // 플레이어와 부딪혔을 때
    {
        if (coll.collider.tag == ("Player"))
        {
            // 폭발 효과, 오브젝트 삭제
            audiosource.Play();
            Destroy(this.gameObject);
            GameObject newExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation) as GameObject;
            newExplosion.transform.Translate(Vector3.up * 1.3f);
            Debug.Log("Enemy Hit!");
            Destroy(newExplosion, 1.2f);
        }
    }
}