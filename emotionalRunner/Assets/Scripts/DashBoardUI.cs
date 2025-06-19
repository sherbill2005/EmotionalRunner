using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DashBoardUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created4
    public static DashBoardUI instance;
    public GameObject Dashboardpanel;
    public TextMeshProUGUI gemText, KillsText, DeathText;

void Awake()
    {
        instance = this;

    }
    public void DashBoard()
    {
        Time.timeScale = 0f;
        Dashboardpanel.SetActive(true);
        UpdateStats();
        // gemManager.EndScoreUpdate();

    }
    void OnEnable()
    {
        // UpdateStats();
    }

    public void UpdateStats()
    {
        gemText.text = "TOTAL Gems: " + PlayerStats.instance.GetGems();
        KillsText.text ="TOTAL KILLS: " +  PlayerStats.instance.GetKills();
        DeathText.text = "TOTAL DEATHS: " + PlayerStats.instance.GetDeaths();
    }
}
