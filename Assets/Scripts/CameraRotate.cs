using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    float h = 5; //horizontal rotation (left, right)
    float v = 5; //vertical rotation (up, down)
    float zoom = 5; //zoom speed

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float rotX = h * Input.GetAxis("Horizontal");
        float rotY = v * Input.GetAxis("Vertical");
        transform.Rotate(rotY, rotX, 0);

        if (Input.GetKeyDown("z"))
        {
            transform.Translate(0, 0, zoom);
        }
        else if(Input.GetKeyDown("x"))
        {
            transform.Translate(0, 0, -zoom);
        }
    }
}
