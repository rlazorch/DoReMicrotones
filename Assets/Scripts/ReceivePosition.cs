using UnityEngine;
using System.Collections;
using System;

public class ReceivePosition : MonoBehaviour {
    
   	public OSC osc;


	// Use this for initialization
	void Start () {
	   osc.SetAddressHandler("/CubeXYZ" , OnReceiveXYZ);
       osc.SetAddressHandler("/CubeX", OnReceiveX);
       osc.SetAddressHandler("/CubeY", OnReceiveY);
       osc.SetAddressHandler("/CubeZ", OnReceiveZ);
       osc.SetAddressHandler("/BallSpeed", BallSpeed);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnReceiveXYZ(OscMessage message){
		float x = message.GetInt(0);
        float y = message.GetInt(1);
		float z = message.GetInt(2);

		transform.position = new Vector3(x,y,z);
	}

    void OnReceiveX(OscMessage message) {
        float x = message.GetFloat(0);

        Vector3 position = transform.position;

        position.x = x;

        transform.position = position;
    }

    void OnReceiveY(OscMessage message) {
        float y = message.GetFloat(0);
        if (y > -4.0) {
            Vector3 position = transform.position;
            position.y = y;
            transform.position = position;
        }
    }

    void OnReceiveZ(OscMessage message) {
        float z = message.GetFloat(0);

        Vector3 position = transform.position;

        position.z = z;

        transform.position = position;
    }

    void BallSpeed(OscMessage message) {
        float force = message.GetFloat(0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));        
        //Debug.Log("Received! " + force);
    }
}
