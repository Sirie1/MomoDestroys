/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using CodeMonkey.Utils;

public class UI_Assistant : MonoBehaviour {

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private int messageCount = 0;
    [SerializeField] Animator dogAnimator;
    [SerializeField] bool isIntroCompleted;

    private void Awake() {
        messageText = transform.Find("Message").Find("messageText").GetComponent<Text>();
        talkingAudioSource = transform.Find("TalkingSound").GetComponent<AudioSource>();
        messageCount = 0;
        isIntroCompleted = false;
    }
    public void OnMessageClick()
    {
        Debug.Log("Message button pressed");
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            // Currently active TextWriter
            textWriterSingle.WriteAllAndDestroy();
        }
        else
        {
            string[] messageArray = new string[] {
                    "Momo darling, we need to leave",
                    "We will be back in a couple of minutes",
                    "Please beheave...",
                    "We love U",
                };

            if (messageCount == messageArray.Count())
            {
                if(!isIntroCompleted)
                    EndIntro();
                else
                    StartGame();
            }
            else
            {
                string message = messageArray[messageCount];
                messageCount++;
                StartTalkingSound();
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .02f, true, true, StopTalkingSound);
            }

        }
    }
    private void StartTalkingSound() {
        talkingAudioSource.Play();
    }

    private void StopTalkingSound() {
        talkingAudioSource.Stop();
    }

    public void EndIntro()
    {
        dogAnimator.SetBool("isTextFinished", true);
        isIntroCompleted=true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
