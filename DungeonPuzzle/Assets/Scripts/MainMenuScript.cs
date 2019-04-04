using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    public GameObject panelOption;
    public GameObject panelLoading;

    public Sprite soundEnabled;
    public Sprite soundDisabled;
    public Sprite musicEnabled;
    public Sprite musicDisabled;

    public Image LoadingBar;
    public Text loadingText;

    public AudioMixer audioMixer;

    public Slider soundSlider;
    public Slider musicSlider;

    public Image soundButton;
    public Image musicButton;

    private bool soundOn;
    private bool musicOn;

	// Use this for initialization
	void Start ()
    {
        soundOn = true;
        musicOn = true;
        soundSlider.onValueChanged.AddListener(delegate { SetSoundVolume(); });
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowOptions()
    {
        panelOption.SetActive(!panelOption.activeSelf);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadLevel(string name)
    {
        panelLoading.SetActive(true);
        StartCoroutine(loadCoroutine(name));
    }

    private IEnumerator loadCoroutine(string name)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(name);
        while (!loading.isDone)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
            LoadingBar.fillAmount = loading.progress;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
    }

    public void SoundButtonClick()
    {
        soundOn = !soundOn;
        if (soundOn)
        {
            soundButton.sprite = soundEnabled;
        }
        else
        {
            soundButton.sprite = soundDisabled;
        } 
        SetSoundVolume();
    }

    public void MusicButtonClick()
    {
        musicOn = !musicOn;
        if (musicOn)
        {
            musicButton.sprite = musicEnabled;
        }
        else
        {
            musicButton.sprite = musicDisabled;
        }
        SetMusicVolume();
    }

    public void SetMusicVolume()
    {
        if (musicOn)
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", -80);
        }
    }

    public void SetSoundVolume()
    {
        if (soundOn)
        {
            audioMixer.SetFloat("SoundVolume", Mathf.Log10(soundSlider.value) * 20);
        }
        else
        {
            audioMixer.SetFloat("SoundVolume", -80);
        }
    }
}
