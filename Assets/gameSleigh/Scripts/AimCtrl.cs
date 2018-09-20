using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCtrl: MonoBehaviour
{
    public Texture2D Aimtexture;
    public Rect AimRect;
    private float mouseX, mouseY, left, top, width, height;


	// Use this for initialization
	void Start ()
    {
        getPosition();
	}

    // Update is called once per frame
    private void OnGUI()
    {
        GUI.DrawTexture(AimRect, Aimtexture);
    }

    private void Update()
    {
        getPosition();
        AimRect = new Rect(left, top, width, height);
    }

    private void getPosition()
    {
        mouseX = Input.mousePosition.x;
        mouseY = -Input.mousePosition.y;
        //width = 20;
        //height = 20;

        width = Aimtexture.width;
        height = Aimtexture.height;
        left = (mouseX - width/2);
        top = (mouseY + Screen.height - height/2);   
    }
}
