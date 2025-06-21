using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System;

public class EmotionManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum Emotion { Normal, Happy, Sad, Angry, Scared }
    public PlayerController player;
    public Emotion currentEmotion = Emotion.Normal;
    private Coroutine Resetcoroutine;
    private float baseMoveSpeed;
    private float baseJumpForce;
    public static EmotionManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        baseMoveSpeed = player.moveSpeed;
        baseJumpForce = player.jumpForce;
        // AudioScript.instance.Music("Happy");
        EmotionEffects(Emotion.Normal);


    }
    public void setemotion(Emotion Newemotion)
    {
        if (currentEmotion != Newemotion)
        {
            currentEmotion = Newemotion;
            Debug.Log("Current Emotion: " + currentEmotion);
            ResetStats();

            EmotionEffects(Newemotion);
            if (Resetcoroutine != null)
            {
                StopCoroutine(Resetcoroutine);
            }
            if (Newemotion != Emotion.Normal)
            {
                Resetcoroutine = StartCoroutine(ResetEmotionDelay(10f));
            }
        }
    }

    void EmotionEffects(Emotion emotion)
    {
        switch (emotion)
        {
            case Emotion.Normal:
                AudioScript.instance.Music("Normal");
                break;
            case Emotion.Happy:
                AudioScript.instance.Music("Happy");
                player.moveSpeed = baseMoveSpeed * 1.2f;
                player.jumpForce = baseJumpForce * 1.1f;
                break;
            case Emotion.Sad:
                player.moveSpeed = baseMoveSpeed * 0.7f;
                player.jumpForce = baseJumpForce * 1.4f;
                AudioScript.instance.Music("Sad");

                break;
            case Emotion.Angry:
                player.jumpForce = baseJumpForce * 1.2f;
                player.moveSpeed = baseMoveSpeed * 1.3f;
                AudioScript.instance.Music("Angry");


                break;
            case Emotion.Scared:
                player.moveSpeed = baseMoveSpeed * 1.5f;
                AudioScript.instance.Music("Scared");
                break;

        }
    }
    void ResetStats()
    {
        player.moveSpeed = baseMoveSpeed;
        player.jumpForce = baseJumpForce;
    }

    IEnumerator ResetEmotionDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        setemotion(Emotion.Normal); 
    }

}
