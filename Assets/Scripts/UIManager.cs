using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform panelOppo;
    public RectTransform panelSelf;
    public RectTransform panelLine;
    public RectTransform panelHand;
    void Awake()
    {
        OnResize();
    }
    
    void OnResize()
    {
        panelHand.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * 0.25f);
        panelSelf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * 0.3f);
        panelLine.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * 0.05f);
        panelOppo.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * 0.3f);

        panelSelf.anchoredPosition = new Vector2(0, -Screen.height * 0.37f);
        panelLine.anchoredPosition = new Vector2(0, -Screen.height * 0.31f);
    }
}
