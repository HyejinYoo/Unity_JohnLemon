using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameEnding gameEnding;
    public Text Timetxt;
    public Stopwatch sw = new Stopwatch();


    float m_Timer = 0;
    static bool Stop = false;

    void Start()
    {
        Timetxt = GameObject.Find("TimeText").GetComponent<Text>();
        Timetxt.text = "0.00";
    }

    void Update()
    {
        if (!Stop)
        {
            m_Timer = m_Timer + Time.deltaTime;
            Timetxt.text = m_Timer.ToString("F2");
        }
    }

    public void stopTimer()
    {
        Stop = true;
    }
}
