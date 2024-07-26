using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Top : ViewController
{
    Vector2 _prevPivot;

    public override void init(string str)
    {
        base.init(str);
        _prevPivot = new Vector2(0.5f, 0.5f);
    }

    public override void ViewEvent(RectTransform rect)
    {
        Debug.Log(rect.pivot);
    }

    public override void OnPointerDown(PointerEventData data)
    {
        Activate();
    }

    public override void OnPointerUp(PointerEventData data)
    {
        isActivated = false;
    }

    public override void OnPointerEnter(PointerEventData data) { }

    public override void OnPointerExit(PointerEventData data) { }
}
