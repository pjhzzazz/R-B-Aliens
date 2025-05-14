using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider soundEffectSlider;
    //private float lastPlayTime = 0f;
    void Start()
    {
        // �ʱ�ȭ
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        soundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume", 1f);

        // �����̴� �� ���� �� AudioManager�� �ݿ�
        bgmSlider.onValueChanged.AddListener((value) =>
        {
            AudioManager.Instance.SetBGMVolume(value);
        });

        soundEffectSlider.onValueChanged.AddListener((value) =>
        {
            AudioManager.Instance.SetSoundEffectVolume(value);
            //if (Time.time - lastPlayTime > 0.5f)
            //{
            //    AudioManager.Instance.PlaySoundEffects("click");         //Ŭ���Ҹ��� �̸����
            //    lastPlayTime = Time.time;
            //}
        });
    }
}
