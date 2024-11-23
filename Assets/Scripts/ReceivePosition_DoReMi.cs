using UnityEngine;
using System.Collections;
using System;

public class ReceivePosition_DoReMi : MonoBehaviour {
    
   	public OSC osc;


	// Use this for initialization
	void Start () {
       osc.SetAddressHandler("/CubeY", OnReceiveY);
       osc.SetAddressHandler("/BallSpeed", BallSpeed);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	    void OnReceiveY(OscMessage message) {
        float y = message.GetFloat(0);
        if (y > 0) {
            Vector3 position = transform.position;
            float tmp = (y - 48) / 2.0f + 1;
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
