using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.ShaderGraph; // if using TextMeshPro

public class EmotionUI : MonoBehaviour
{
    public EmotionManager emotionManager;

    public Image emotionIcon;
    public TextMeshProUGUI emotionText;
    public TextMeshProUGUI Description;


    public Sprite happySprite;
    public Sprite NormalSprite;

    public Sprite angrySprite;
    public Sprite sadSprite;
    public Sprite scaredSprite;

    void Update()
    {
        UpdateEmotionUI();
    }

    void UpdateEmotionUI()
    {
        switch (emotionManager.currentEmotion)
        {
            case EmotionManager.Emotion.Happy:
                emotionIcon.sprite = happySprite;;
                emotionText.text = "Happy";
                emotionText.color = Color.green;
                Description.text = "Speed: +30%\nJump: +30% ";

                break;
            case EmotionManager.Emotion.Normal:
                emotionIcon.sprite = NormalSprite;
                emotionText.text = "Normal";
                emotionText.color = Color.yellow;
                Description.text = "Speed: Normal\nJump: Normal ";

                break;
            case EmotionManager.Emotion.Angry:
                emotionIcon.sprite = angrySprite;
                emotionText.text = "Angry";
                emotionText.color = Color.magenta;
                Description.text = "Speed: +50%\nJump: +60% ";
                break;
            case EmotionManager.Emotion.Sad:
                emotionIcon.sprite = sadSprite;
                emotionText.text = "Sad";
                emotionText.color = Color.blue;
                Description.text = "Speed: -30%\nJump: +20% ";
                break;
            case EmotionManager.Emotion.Scared:
                emotionIcon.sprite = scaredSprite;
                emotionText.text = "Scared";
                emotionText.color = Color.gray;
                Description.text = "Speed: +70%\nJump: Normal ";
                break;
        }
    }
}
