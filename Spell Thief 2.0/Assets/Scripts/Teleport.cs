using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
        {
             if (Input.GetButtonDown("Fire2"))
             {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
             }
        }
    }
