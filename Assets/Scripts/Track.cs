using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject sphere;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, sphere.transform.position.z);
    }
}
