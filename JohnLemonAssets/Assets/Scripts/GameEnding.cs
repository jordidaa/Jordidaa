using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;

    public GameObject player;

    bool m_IsPlayerAtExit;

    bool m_IsPlayerCaught;

    public CanvasGroup exitBackgraundImageCanvasGrup;

    public CanvasGroup caughtBackgraundImageCanvasGrup;

    float m_timer;

    public float displayImageDuration = 1f;

    public AudioSource exitAudio;

    public AudioSource caughtAudio;

    bool m_HasAudioPlayed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgraundImageCanvasGrup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgraundImageCanvasGrup, true, caughtAudio);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;

        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSourse)
    {
        if (!m_HasAudioPlayed)
        {
            audioSourse.Play();
            m_HasAudioPlayed = true;
        }
        m_timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_timer / fadeDuration;



        if (m_timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
            
        }
    }
}
