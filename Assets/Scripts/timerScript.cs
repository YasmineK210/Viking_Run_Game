using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public Text timerText;
    public static timerScript inst;
    public float startTime;
    // Start is called before the first frame update

    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        startTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.inst.isGameOver)
        {
            startTime += Time.deltaTime;
            timerText.text = "Time: " + startTime;
        }
    }
}
