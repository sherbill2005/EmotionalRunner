using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else Destroy(gameObject);
    }


    public void ADDGems() => PlayerPrefs.SetInt("TotalGems", PlayerPrefs.GetInt("TotalGems", 0) + 1);
    public void ADDDeaths() => PlayerPrefs.SetInt("TotalDeaths", PlayerPrefs.GetInt("TotalDeaths", 0) + 1);
    public void ADDKills() => PlayerPrefs.SetInt("TotalKills", PlayerPrefs.GetInt("TotalKills", 0) + 1);
    public void SetHighScore(int score) => PlayerPrefs.SetInt("HighScore", score);


    public int GetGems() => PlayerPrefs.GetInt("TotalGems", 0);
    public int GetDeaths() => PlayerPrefs.GetInt("TotalDeaths", 0); 
    public int GetKills() => PlayerPrefs.GetInt("TotalKills", 0);
    public int GetHighScore() => PlayerPrefs.GetInt("HighScore", 0);


    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("TotalGems");
        PlayerPrefs.DeleteKey("TotalKills");
        PlayerPrefs.DeleteKey("TotalDeaths");
        PlayerPrefs.Save();
    }


    public void OnClearProgressButton()
    {

        PlayerStats.instance.ResetStats();
        DashBoardUI.instance.UpdateStats();
         
         
    }

}
