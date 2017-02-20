using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {
    
    // Version in which you play in Gear VR
    // Update is called once per frame
    void Update () {
        GameObject modcub = GameObject.Find("ModeCube");
        GameObject remcub = GameObject.Find("RemainderCube");
        GameObject diagcub = GameObject.Find("DiagCube");
        Ray raycastRay = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(raycastRay, out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.gameObject.name == "ModeCube")
            {
                modcub.transform.position = new Vector3(-17.05f, -2f, -5.2f);
                if (Input.GetMouseButtonDown(0))
                {
                    CreateColor.changemod();
                }
            }
            else
            {
                modcub.transform.position = new Vector3(-17f, -2f, -5f);
            }
            if (hitInfo.collider.gameObject.name == "RemainderCube")
            {
                remcub.transform.position = new Vector3(-17.05f, -6.5f, -5.2f);
                if (Input.GetMouseButtonDown(0))
                {
                    CreateColor.changeremainder();
                }
            }
            else
            {
                remcub.transform.position = new Vector3(-17f, -6.5f, -5f);
            }
            if (hitInfo.collider.gameObject.name == "DiagCube")
            {
                diagcub.transform.position = new Vector3(-17.05f, -11f, -5.2f);
                if (Input.GetMouseButtonDown(0))
                {
                    CreateColor.changediag();
                }
            }
            else
            {
                diagcub.transform.position = new Vector3(-17f, -11f, -5f);
            }

        }
        else
        {
            modcub.transform.position = new Vector3(-17f, -2f, -5f);
            remcub.transform.position = new Vector3(-17f, -6.5f, -5f);
            diagcub.transform.position = new Vector3(-17f, -11f, -5f);
        }
    }
}
