using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform shopPanel;

    [Header(" Settings ")]
    [SerializeField] Vector2 openedPosition;
    [SerializeField] Vector2 closedPosition;

    void Start()
    {
        openedPosition = Vector2.zero;
        closedPosition = new Vector2(shopPanel.rect.width, 0);

        shopPanel.anchoredPosition = closedPosition;
    }

    public void Open()
    {
        LeanTween.cancel(shopPanel);
        LeanTween.move(shopPanel, openedPosition, .3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void Close()
    {
        LeanTween.cancel(shopPanel);
        LeanTween.move(shopPanel, closedPosition, .3f).setEase(LeanTweenType.easeInOutSine);
    }
}
