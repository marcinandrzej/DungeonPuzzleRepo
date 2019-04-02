using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void buttonAction (int a);

public class ButtonScript : MonoBehaviour
{
    public GameObject[] stars;
    public Text buttonText;
    public Image buttonImage;
    public Button button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActiveButton(bool active)
    {
        button.enabled = active;
    }

    public void ChangeImage(Sprite img)
    {
        buttonImage.sprite = img;
    }

    public void ActiveText(bool active)
    {
        buttonText.gameObject.SetActive(active);
    }

    public void ShowStars(int starsCount)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < starsCount)
            {
                stars[i].SetActive(true);
            }
            else
            {
                stars[i].SetActive(false);
            }
        }
    }

    public void SetText(string _text)
    {
        buttonText.text = _text;
    }

    public void SetAction(buttonAction action, int value)
    {
        button.onClick.AddListener(delegate { action.Invoke(value); });
    }
}
