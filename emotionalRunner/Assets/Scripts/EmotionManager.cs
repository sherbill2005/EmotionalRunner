using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System;

public class EmotionManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum Emotion { Happy, Sad, Angry, Scared }
    public PlayerController player;
    public Emotion currentEmotion;


    public float changeTimeIntervel = 3f;
    private float baseMoveSpeed;
    private float baseJumpForce;


    void Start()
    {
        baseMoveSpeed = player.moveSpeed;
        baseJumpForce = player.jumpForce;

        StartCoroutine(ChangeEmotion());
    }

    IEnumerator ChangeEmotion()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeTimeIntervel);
            SetRandomEmotion();
        }
    }

    void SetRandomEmotion()
    {
        currentEmotion = (Emotion)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Emotion)).Length);
        Debug.Log("Current Emotion: " + currentEmotion);
        ResetStats();
        EmotionEffects();

    }

    void EmotionEffects()
    {
        switch (currentEmotion)
        {
            case Emotion.Happy:

                break;
            case Emotion.Sad:
                player.moveSpeed = baseMoveSpeed * 0.5f;
                

                break;
            case Emotion.Angry:
                player.jumpForce = baseJumpForce * 1.2f;
                

                break;
            case Emotion.Scared:
                player.moveSpeed = baseMoveSpeed * 1.5f;
                

                break;

        }
    }
    void ResetStats()
    {
        player.moveSpeed = baseMoveSpeed;
        player.jumpForce = baseJumpForce;
    }

}
