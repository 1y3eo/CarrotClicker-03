/*sing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Carrot : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform carrotRendererTransform;
    [SerializeField] private Image FillImage;

    [Header(" Settings ")]
    [SerializeField] private float fillRate;
    private bool isFrenzyModeActive;

    [Header(" Actions ")]
    public static Action onFrenzyModeStarted;
    public static Action onFrenzyModeStopped;

    private void Awake()
    {
        InputManager.onCarrotClicked += CarrotClickedCallback;
    }
    private void onDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void CarrotClickedCallback()
    {
        Animate();

        if(!isFrenzyModeActive)
            Fill();
    }

    private void Animate()
    {
        carrotRendererTransform.localScale = Vector3.one * .8f;
        LeanTween.cancel(carrotRendererTransform.gameObject);
        LeanTween.scale(carrotRendererTransform.gameObject, Vector3.one * .7f, .15f).setLoopPingPong(1);
    }

    private void Fill()
    {
        FillImage.fillAmount += fillRate;

        if (FillImage.fillAmount >= 1)
            StartFrenzyMode();
    }

    private void StartFrenzyMode()
    {
        isFrenzyModeActive = true;

        LeanTween.value(1, 0, 5).setOnUpdate((value) => FillImage.fillAmount = value)
            .setOnComplete(StopFrenzyMode);

        onFrenzyModeStarted?.Invoke();
    }

    private void StopFrenzyMode()
    {
        isFrenzyModeActive = false;

        onFrenzyModeStopped?.Invoke();
    }
}
    */
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Carrot : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform carrotRendererTransform;
    [SerializeField] private Image fillImage;

    [Header(" Settings ")]
    [SerializeField] private float fillRate;
    private bool isFrenzyModeActive;

    [Header(" Action ")]
    public static Action onFrenzyModeStarted;
    public static Action onFrenzyModeStopped;

    private void Awake()
    {
        InputManager.onCarrotClicked += CarrotClickedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;
    }
    void Start()
    {
        isFrenzyModeActive = false;
    }

    void Update()
    {

    }

    private void CarrotClickedCallback()
    {
        Animate();
        Fill();
    }

    private void Animate()
    {
        carrotRendererTransform.localScale = Vector3.one * .8f;
        LeanTween.cancel(carrotRendererTransform.gameObject);
        LeanTween.scale(carrotRendererTransform.gameObject, Vector3.one * .7f, .15f).setLoopPingPong(1);
    }

    private void Fill()
    {
        fillImage.fillAmount += fillRate;

        if (fillImage.fillAmount >= 1)
            StartFrenzyMode();
    }

    private void StartFrenzyMode()
    {
        isFrenzyModeActive = true;

        LeanTween.value(1, 0, 5).setOnUpdate((value) => fillImage.fillAmount = value)
            .setOnComplete(StopFrenzyMode);

        onFrenzyModeStarted?.Invoke();
    }

    private void StopFrenzyMode()
    {
        isFrenzyModeActive = false;

        onFrenzyModeStopped?.Invoke();
    }
}
