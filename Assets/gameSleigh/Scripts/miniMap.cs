using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap : MonoBehaviour {
    Transform playerTr;

	// Use this for initialization
	void Start () {
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerTr.position;
        transform.Translate(Vector3.up * 7);
	}
}
