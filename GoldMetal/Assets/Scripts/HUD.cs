using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType {  Exp, Level, Kill, Time, Health}
    public InfoType type;

    Text myText;
    Slider mySlider;

    private void Awake()
    {
        mySlider = GetComponent<Slider>();
        myText = GetComponent<Text>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.Instance.exp;
                float maxExp = GameManager.Instance.nextExp[GameManager.Instance.level];
                mySlider.value = curExp/maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("LV.{0:F0}",GameManager.Instance.level);
                break;
            case InfoType.Time:
                float remainTime = GameManager.Instance.maxGameTime - GameManager.Instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("LV.{0:D2}:{1:D2}", min,sec);
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.Instance.kill);
                break;
            case InfoType.Health:

                break;
        }
    }
}
