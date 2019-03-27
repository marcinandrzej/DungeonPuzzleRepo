using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    private Color32 inactiveColor;
    private Color32 activeColor;
    public static GameMenuScript instance;

    public GameObject winPanel;
    public Image[] coins;

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

        activeColor = new Color32(255, 255, 255, 255);
        inactiveColor = new Color32(100, 100, 100, 255);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowWinMenu(int coinsCount)
    {
        for (int i = 0; i < coins.Length; i++)
        {
            if (i < coinsCount)
                coins[i].color = activeColor;
            else
                coins[i].color = inactiveColor;
        }
        winPanel.SetActive(true);
    }
}
