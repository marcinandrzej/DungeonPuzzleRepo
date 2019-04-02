using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    private const int ROWS = 4;
    private const int COLUMNS = 9;

    public ButtonScript[] levelButtons;

    public GameObject winPanel;
    public GameObject infoPanel;
    public GameObject controlPanel;
    public GameObject nextButton;
    public Image[] coins;
    public Text[] coinsText;
    public Text movesText;
    public Text levelText;

    public GameObject levelPanel;
    public GameObject levelBox;
    public GameObject levelButtonPrefab;
    public Sprite activeLevel;
    public Sprite inactiveLevel;

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
        nextButton.SetActive(showNextButton);
        HideWinMenu(true);
    }

    public void HideWinMenu(bool show)
    {
        infoPanel.SetActive(!show);
        controlPanel.SetActive(!show);
        winPanel.SetActive(show);
    }

    public void HideLevelMenu(bool show)
    {
        levelPanel.SetActive(show);
        infoPanel.SetActive(!show);
        controlPanel.SetActive(!show);
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

    public void SetUpLevelButtons(buttonAction action)
    {
        levelButtons = new ButtonScript[COLUMNS * ROWS];
        float offsetX = levelBox.GetComponent<RectTransform>().sizeDelta.x / COLUMNS;
        float offsetY = levelBox.GetComponent<RectTransform>().sizeDelta.y / ROWS;

        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLUMNS; x++)
            {
                int index = y * COLUMNS + x;
                GameObject g = Instantiate(levelButtonPrefab);
                g.transform.SetParent(levelBox.transform);
                g.GetComponent<RectTransform>().anchoredPosition = new Vector2(x * offsetX, -y * offsetY);
                g.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                levelButtons[index] = g.GetComponent<ButtonScript>();
                levelButtons[index].SetText((index + 1).ToString());
                levelButtons[index].SetAction(action, index);
            }
        }
    }

    public void UpdateLevelButtons(string key)
    {
        char[] keyInChar = key.ToCharArray();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (key.Length > i)
            {
                levelButtons[i].ChangeImage(activeLevel);
                levelButtons[i].ActiveButton(true);
                levelButtons[i].ActiveText(true);
                levelButtons[i].ShowStars((int)char.GetNumericValue(keyInChar[i]));
            }
            else
            {
                levelButtons[i].ChangeImage(inactiveLevel);
                levelButtons[i].ActiveButton(false);
                levelButtons[i].ActiveText(false);
                levelButtons[i].ShowStars(0);
            }
        }
    }
}
