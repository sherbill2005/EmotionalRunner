using UnityEngine;
using System.Collections;

public class EmotionManager : MonoBehaviour
{
    public enum Emotion { Normal, Happy, Sad, Angry, Scared }
    public PlayerController player;
    public Emotion currentEmotion = Emotion.Normal;

    private float baseMoveSpeed;
    private float baseJumpForce;
    public static EmotionManager instance;

    [Tooltip("How many seconds before changing emotion")]
    public float emotionChangeInterval = 10f;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        baseMoveSpeed = player.moveSpeed;
        baseJumpForce = player.jumpForce;
        // SetRandomEmotion();

        SetEmotion(Emotion.Normal);
        AudioScript.instance.Music("Normal");// start in Normal
        StartCoroutine(RandomEmotionRoutine());
    }

    IEnumerator RandomEmotionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(emotionChangeInterval);
            SetRandomEmotion();
        }
    }

    void SetRandomEmotion()
    {
        // Pick random excluding current
        Emotion newEmotion;
        do
        {
            newEmotion = (Emotion)Random.Range(0, System.Enum.GetValues(typeof(Emotion)).Length);
        }
        while (newEmotion == currentEmotion);

        SetEmotion(newEmotion);
    }

    public void SetEmotion(Emotion newEmotion)
    {
        if (currentEmotion != newEmotion)
        {
            currentEmotion = newEmotion;
            Debug.Log("Changed Emotion to: " + newEmotion);

            ResetStats();
            ApplyEmotionEffects(newEmotion);
        }
    }

    void ApplyEmotionEffects(Emotion emotion)
    {
        switch (emotion)
        {
            case Emotion.Normal:
                AudioScript.instance.Music("Normal");
                break;

            case Emotion.Happy:
                player.moveSpeed = baseMoveSpeed * 1.2f;
                player.jumpForce = baseJumpForce * 1.1f;
                AudioScript.instance.Music("Happy");
                break;

            case Emotion.Sad:
                player.moveSpeed = baseMoveSpeed * 0.7f;
                player.jumpForce = baseJumpForce * 1.4f;
                AudioScript.instance.Music("Sad");
                break;

            case Emotion.Angry:
                player.moveSpeed = baseMoveSpeed * 1.3f;
                player.jumpForce = baseJumpForce * 1.2f;
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
}
