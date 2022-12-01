using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;

    private GameObject currentScreen;

    public GameObject endScreen;
    public GameObject gameScreen;
    public GameObject mainScreen;
    public GameObject returnScreen;

    public Button lengthButton;
    public Button strengthButton;
    public Button offlineButton;

    public Text gameScreenMoney;
    public Text lengthCostText;
    public Text lengthValueText;
    public Text strengthCostText;
    public Text strenthValueText;
    public Text offlineCostText;
    public Text offlineValueText;
    public Text endScreenMoney;
    public Text returnScreenMoney;

    private int gameCount;

    private void Awake()
    {
        if (ScreenManager.instance)
            Destroy(base.gameObject);
        else
            ScreenManager.instance = this;
        currentScreen = mainScreen;

    }
    private void Start()
    {
        CheckIdles();
        UpdateTexts();

    }
    public void ChangeScreen(Screens screen)
    {
        currentScreen.SetActive(false);
        switch (screen)
        {
            case Screens.MAIN:
                currentScreen = mainScreen;
                UpdateTexts();
                CheckIdles();
                break;

            case Screens.GAME:
                currentScreen = gameScreen;
                gameCount++;
                break;

            case Screens.END:
                currentScreen = endScreen;
                SetEndScreenMoney();
                break;
            case Screens.RETURN:
                currentScreen = returnScreen;
                SetReturnScreenMoney();
                break;
        }
        currentScreen.SetActive(true);
    }
    public void SetEndScreenMoney()
    {
        endScreenMoney.text = "$" + ÝdleManager.instance.totalGain;
    }
    public void SetReturnScreenMoney()
    {
        returnScreenMoney.text = "$" + ÝdleManager.instance.totalGain + " gained while waiting!";
    }
    public void UpdateTexts()
    {
        gameScreenMoney.text = "$" + ÝdleManager.instance.wallet;
        lengthCostText.text = "$" + ÝdleManager.instance.lengthCost;
        lengthValueText.text = -ÝdleManager.instance.length + "m";
        strengthCostText.text = "$" + ÝdleManager.instance.strengthCost;
        strenthValueText.text = ÝdleManager.instance.strength + "fishes.";
        offlineCostText.text = "$" + ÝdleManager.instance.offlineEarningsCosts;
        offlineValueText.text = "$" + ÝdleManager.instance.offlineEarnings+"/min";
    }
    public void CheckIdles()
    {
        int lengthCost = ÝdleManager.instance.lengthCost;
        int strengthCost = ÝdleManager.instance.strengthCost;
        int offlineEarningsCost = ÝdleManager.instance.offlineEarningsCosts;
        int wallet = ÝdleManager.instance.wallet;

        if (wallet < lengthCost)
            lengthButton.interactable = false;
        else
            lengthButton.interactable = true;

        if (wallet < strengthCost)
            strengthButton.interactable = false;
        else
            strengthButton.interactable = true;

        if (wallet < offlineEarningsCost)
            offlineButton.interactable = false;
        else
            offlineButton.interactable = true;
    }
}
