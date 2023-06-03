using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
        [SerializeField] private GameObject panel;
    [SerializeField] private string text ="Time to find key: ";

    void OnEnable(){
        DisplayTime(Time.timeSinceLevelLoad);
    }


    public void DisplayTime()
    {
       DisplayTime(Time.timeSinceLevelLoad);

    }
    public void DisplayTime(float time)
    {
        panel.SetActive(true);
        // Debug.Log("Time: " + Time.timeSinceLevelLoad);
        textMeshPro.text = text + ConvertTimeToMinutesSeconds(time);
    }
    
    public string ConvertTimeToMinutesSeconds(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);

        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
