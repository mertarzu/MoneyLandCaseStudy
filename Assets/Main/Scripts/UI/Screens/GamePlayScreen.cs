using System.Collections.Generic;
using UnityEngine;

public class GamePlayScreen : UIScreen
{
    [SerializeField] List<UIView> uiViews;

    public override void Hide()
    {
        gameObject.SetActive(false);
        foreach (var uiView in uiViews)
        {
            uiView.SetActive(false);
        }
    }

    public override void Initialize()
    {
        Hide();
        foreach (var uiView in uiViews)
        {
            uiView.Initialize();
        }
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        foreach (var uiView in uiViews)
        {
            uiView.SetActive(true);
            uiView.UpdateView();
        }
    }
}
