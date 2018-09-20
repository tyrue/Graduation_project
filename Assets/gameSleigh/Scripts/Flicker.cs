using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {
    public Renderer lamp;
    private Color originColor; // 원래 색깔
                               // Use this for initialization
    void Start () {
        originColor = lamp.material.color;
    }
	
	// Update is called once per frame
	void Update () {
        float flicker = Mathf.Abs(Mathf.Sin(Time.time * 10));
        lamp.material.color = originColor * flicker;
    }
}
