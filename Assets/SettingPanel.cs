using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    public Slider sliderSound;
    public Button btnAccept;
    private float soundVal;
    private void Awake()
    {
        sliderSound.onValueChanged.AddListener((val) =>
        {
            soundVal = (float)val;
        });
        btnAccept.onClick.AddListener(() =>
        {
            DataManager.Instance.globalData.SoundValue = soundVal;
            gameObject.SetActive(false);
        });
    }

}
