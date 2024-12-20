﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class ReceivePosition_DoReMi : MonoBehaviour {
    
   	public OSC osc;
    public int transpose = 12;
    public GameController gameController;
	void Start () {
       osc.SetAddressHandler("/CubeY", OnReceiveY);
       osc.SetAddressHandler("/BallSpeed", BallSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > gameController.pillarGap * gameController.names.Length) {
            SceneManager.LoadScene("Fight", LoadSceneMode.Single);
        }
	}
	    void OnReceiveY(OscMessage message) {
        float y = message.GetFloat(0);
        if (y > 0) {
            Vector3 position = transform.position;
            float tmp = (y - 45 - transpose) / 2.0f;
            if (tmp < 0) {
                tmp = 0;
            }
            
            position.y = tmp;
            transform.position = position;
        }
    }

    void BallSpeed(OscMessage message) {
        float force = message.GetFloat(0);
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force));
        //Debug.Log("Received! " + force);
    }
}
