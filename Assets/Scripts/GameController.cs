using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    public GameObject pillar;
    public string[] names;
    public float[] pitches;
    List<GameObject> pillars;
    public float pillarGap = 8f;

    public GameObject ball;
    public float ballSize = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        pillars = new List<GameObject>();
        for (int i = 0; i < names.Length; i ++) {
            GameObject newPillar = Instantiate(pillar);
            newPillar.transform.position = new Vector3(0, 0, pillarGap * i);
            newPillar.transform.Find("PillarBottom").transform.localScale = new Vector3(1, 1 + pitches[i] * 0.5f, 1);
            newPillar.transform.Find("PillarTop").transform.localScale = new Vector3(1, 10 - pitches[i] * 0.5f - 2, 1);
            newPillar.transform.Find("Label").GetComponent<TMP_Text>().text = names[i];
            newPillar.transform.SetParent(gameObject.transform);
            newPillar.SetActive(true);
            pillars.Add(newPillar);
        }

        ball.transform.localScale = new Vector3(ballSize, ballSize, ballSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
