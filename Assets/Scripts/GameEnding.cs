using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameEnding : MonoBehaviour
{

    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public Timer timer;
    public Text exitTime;
    public Text shortestTime;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    bool m_HasAudioPlayed;
    float m_Timer;
    bool m_ShowTime = false;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Start()
    {
        m_IsPlayerAtExit = false;
        exitTime = GameObject.Find("ExitTime").GetComponent<Text>();
        shortestTime = GameObject.Find("ShortestTime").GetComponent<Text>();
    }

    void Update()
    {

        //UnityEngine.Debug.Log("foreach : " + sw.ElapsedMilliseconds + " ms");
        if (m_IsPlayerAtExit)
        {
            //timer.TimerStop();
            //timer.sw.Stop();
            timer.stopTimer();
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
                 
        }
        else if (m_IsPlayerCaught)
        {
            
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
            
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {

        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {


                if (!m_ShowTime)
                {
                    exitTime.text = GameObject.Find("Timer").GetComponent<Timer>().Timetxt.text;
                    float exitTimef = float.Parse(exitTime.text);

                    //exitTime.text = timer.Timetxt.text;

                    if (PlayerPrefs.HasKey("Shortest"))
                    {
                        string shortestText = PlayerPrefs.GetString("Shortest");
                        float shortestf = float.Parse(shortestText);

                        UnityEngine.Debug.Log(shortestText + " " + exitTime.text);
                        if (exitTimef < shortestf)
                        {
                            PlayerPrefs.SetString("Shortest", exitTime.text);
                        }
                    }
                    else
                    {
                        UnityEngine.Debug.Log(exitTime.text);
                        PlayerPrefs.SetString("Shortest", exitTime.text);
                    }
                    shortestTime.text = PlayerPrefs.GetString("Shortest");
                    m_ShowTime = true;
                }
                

                //Application.Quit();
            }
        }
    }
}