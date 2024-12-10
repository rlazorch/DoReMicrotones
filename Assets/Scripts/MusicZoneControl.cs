using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZoneConrol : MonoBehaviour
{
    public OSC osc;
    void Start() {
        OscMessage message = new OscMessage();
        message.address = "/FightTime";
        message.values.Add(1);
        osc.Send(message);
        Debug.Log("sent");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            // GameObject.Find("/MusicManager").GetComponent<MusicPlayerSync>().swapToSub(0);
            // GameObject.Find("/AmbienceManager").GetComponent<MusicPlayerSync>().swapToSub(0);
            OscMessage message = new OscMessage();
            message.address = "/PlayCloser";
            message.values.Add(1);
            osc.Send(message);
            Debug.Log("sent");
        }
    }
    // void OnTriggerExit2D(Collider2D  other) {
    //     if (other.gameObject.tag == "Player") {
    //         GameObject.Find("/MusicManager").GetComponent<MusicPlayerSync>().swapToSuper();
    //         GameObject.Find("/AmbienceManager").GetComponent<MusicPlayerSync>().swapToSuper();
    //     }
    // }
}
