using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour {

    private GameObject unitychan;
    private GameObject mainCamera;
    private float kyori;
    private float cameraDifference;

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        this.mainCamera = GameObject.Find("Main Camera");
   
    }
	
	// Update is called once per frame
	void Update () {
        this.cameraDifference = unitychan.transform.position.z - mainCamera.transform.position.z;
        this.kyori = unitychan.transform.position.z - this.transform.position.z;
        if (kyori >= cameraDifference)
        {
            Destroy(gameObject);

        }
    }
}
