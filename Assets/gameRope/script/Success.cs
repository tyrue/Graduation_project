using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour {

    public AudioClip sndSuccess; // 효과음

    void Start () {
        AudioSource.PlayClipAtPoint(sndSuccess, transform.position);
    }
}
