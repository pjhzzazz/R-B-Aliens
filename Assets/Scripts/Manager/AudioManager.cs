using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource soundEffectSource;

    public AudioClip[] bgms;
    public AudioClip[] soundEffects;

    public Dictionary<string, AudioClip> bgmDict = new();
    public Dictionary<string, AudioClip> soundEffectDict = new(); 

    private string currentBGMName = "";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (AudioClip clip in bgms)
                bgmDict[clip.name] = clip;

            foreach (AudioClip clip in soundEffects)    //��ųʸ��� ���
                soundEffectDict[clip.name] = clip;
        }
        else
        {
            Destroy(gameObject);
        }
        float bgmVol = PlayerPrefs.GetFloat("BGMVolume", 1f);
        float soundEffectVol = PlayerPrefs.GetFloat("SoundEffectVolume", 1f);  //����� ���� �Է°� �ҷ�����
    }

    public void PlaySoundEffects(string name)
    {
        if (soundEffectDict.ContainsKey(name))
            soundEffectSource.PlayOneShot(soundEffectDict[name]);      //PlayOneShot���� �ѹ� ����
    }

    public void PlayBGM(string name)
    {
        if (bgmDict.ContainsKey(name))
        {
            if (currentBGMName == name) return; // �ߺ� ��� ����
            currentBGMName = name;

            AudioClip clip = bgmDict[name];
            bgmSource.clip = clip;
            bgmSource.Play();
        
        }
    }

    public void StopBGM() => bgmSource.Stop();

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSoundEffectVolume(float volume)
    {
        soundEffectSource.volume = volume;
        PlayerPrefs.SetFloat("SoundEffectVolume", volume);
    }

    public void MuteBGM(bool isMuted)
    {
        bgmSource.mute = isMuted;     
    }

    public void MuteSoundEffect(bool isMuted)
    {
        soundEffectSource.mute = isMuted;
    }
}

