using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public GameObject target;
    private bool _rotate;
    private Vector3 target_init_pos;
    private Quaternion target_init_rot;

    // Use this for initialization
    void Start(){
        _rotate = true;
        target_init_pos = target.transform.position;
        target_init_rot = target.transform.rotation;
    }

    void Update()
    {
        Vector3 vel = GetComponent<Rigidbody>().velocity;
        if (_rotate)
            transform.rotation = Quaternion.LookRotation(vel);
    }

    void OnCollisionEnter(Collision other)
    {
        _rotate = false;
    }

    void OnCollisionExit(Collision other)
    {
        _rotate = true;
    }
}
