using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GemManager : MonoBehaviour
{


    public int score = 0;
    
    public TMP_Text score_Text;
    public TMP_Text EndScore_Text;


    public void AddScore(int add)
    {
        score += add;
        score_Text.text = score.ToString();
        
        EndScore_Text.text = score.ToString();
    }
   
}
