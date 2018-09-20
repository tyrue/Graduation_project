using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPosition : MonoBehaviour {

    // Use this for initialization
    Transform tr;
    public int corner;
	void Start () {
        tr = GameObject.FindWithTag("Player").GetComponent<Transform>();      
    }
	
	// Update is called once per frame
	void Update () {
        corner = GameObject.FindWithTag("Player").GetComponent<Ardunity.Player>().cornerCount;
        switch (corner)
        {
            case 1:
                transform.position = new Vector3(-312.6f, 6.6f, -12.1f);
                transform.Translate(new Vector3(0, 0, tr.position.z + 35.5f));
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                transform.position = new Vector3(-270f, 6.6f, 243.1f);
                transform.Translate(new Vector3(0, 0, tr.position.x + 320f));
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 3:
                transform.position = new Vector3(-78.9f, 6.6f, 213.8f);
                transform.Translate(new Vector3(0, 0, -tr.position.z + 250f));
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 4:
                transform.position = new Vector3(-114.4f, 6.6f, -102.8f);
                transform.Translate(new Vector3(0, 0, -tr.position.x - 70.4f));
                transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
        }
    }
}
