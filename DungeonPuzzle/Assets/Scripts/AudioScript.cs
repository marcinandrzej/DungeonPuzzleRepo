using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript instance;

    public AudioSource musicSource;
    public AudioSource fanfareSource;

    private Coroutine fanfares;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StopAllSoundes()
    {
        fanfareSource.Stop();
        if(!musicSource.isPlaying)
            musicSource.Play();
    }

    public void PlayFanfares()
    {
        musicSource.Stop();
        fanfares = StartCoroutine(PlayFanfaresCoroutine());
    }

    public IEnumerator PlayFanfaresCoroutine()
    {
        fanfareSource.Play();
        while (fanfareSource.isPlaying)
        {
            yield return new WaitForEndOfFrame(); 
        }
        yield return new WaitForEndOfFrame();
    }
}
