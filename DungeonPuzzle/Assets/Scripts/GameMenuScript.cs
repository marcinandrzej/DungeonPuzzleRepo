using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject infoPanel;
    public GameObject controlPanel;
    public GameObject nextButton;
    public Image[] coins;
    public Text[] coinsText;
    public Text movesText;
    public Text levelText;

    public Button nextLevelButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowWinMenu(int coinsCount, bool showNextButton)
    {
        for (int i = 0; i < coins.Length; i++)
        {
            if (i < coinsCount)
                coins[i].gameObject.SetActive(true);
            else
                coins[i].gameObject.SetActive(false);
        }
        if (coinsCount <= 0)
        {
            nextLevelButton.gameObject.SetActive(false);
        }
        else
        {
            nextLevelButton.gameObject.SetActive(true);
        }
        nextButton.SetActive(showNextButton);
        HideWinMenu(true);
    }

    public void HideWinMenu(bool show)
    {
        infoPanel.SetActive(!show);
        controlPanel.SetActive(!show);
        winPanel.SetActive(show);
    }

    public void UpdateCoinText(int threeCoins, int twoCoins, int oneCoin)
    {
        coinsText[0].text = threeCoins.ToString();
        coinsText[1].text = twoCoins.ToString();
        coinsText[2].text = oneCoin.ToString();
    }

    public void UpdateMovesText(int moves)
    {
        movesText.text = moves.ToString();
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = "LEVEL " + level.ToString();
    }
}
