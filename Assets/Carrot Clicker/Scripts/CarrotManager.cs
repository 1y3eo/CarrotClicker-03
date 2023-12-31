using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarrotManager : MonoBehaviour
{
    public static CarrotManager instance;

    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI carrotsText;

    [Header(" Data ")]
    [SerializeField] private double totalCarrotsCount;
    [SerializeField] private int FrenzyModeMultiplier;
    [SerializeField] private int carrotIncrement;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadData();
        carrotIncrement = 1;

        InputManager.onCarrotClicked += CarrotClickedCallback;

        Carrot.onFrenzyModeStarted += FrenzyModeStartedCallback;
        Carrot.onFrenzyModeStopped += FrenzyModeStoppedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;

        Carrot.onFrenzyModeStarted -= FrenzyModeStartedCallback;
        Carrot.onFrenzyModeStopped -= FrenzyModeStoppedCallback;
    }

    void Start()
    {
        AddCarrots(50);
    }

    void Update()
    {
        
    }


    public bool TryPurchase(double price)
    {
        if (price <= totalCarrotsCount)
        {
            totalCarrotsCount -= price;
            return true;
        }
        return false;
    }

    public void AddCarrots(double value)
    {
        totalCarrotsCount += value;

        UpdateCarrotsText();

        SaveData();
    }

    public void AddCarrots(float value)
    {
        totalCarrotsCount += value;

        UpdateCarrotsText();

        SaveData();
    }

    private void CarrotClickedCallback()
    {
        totalCarrotsCount += carrotIncrement;
        UpdateCarrotsText();
        SaveData();
    }

    private void UpdateCarrotsText()
    {
        carrotsText.text = totalCarrotsCount.ToString("F0") + " Carrots!";
    }

    private void FrenzyModeStartedCallback()
    {
        carrotIncrement = FrenzyModeMultiplier;
    }

    private void FrenzyModeStoppedCallback()
    {
        carrotIncrement = 1;
    }

    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots", totalCarrotsCount.ToString());
    }

    private void LoadData()
    {
        double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotsCount);

        UpdateCarrotsText();
    }

    public int GetCurrentMultiplier()
    {
        return carrotIncrement;
    }
}
