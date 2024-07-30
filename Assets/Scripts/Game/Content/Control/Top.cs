using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Top : ViewController
{
    Vector3 _mousePos;
    public override void init(string str)
    {
        base.init(str);
        _mousePos = Vector3.zero;
    }

    public override void ViewEvent(RectTransform rect)
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos -= p;
        _mousePos.z = 0;
        rect.position -= _mousePos;
        _mousePos = p;
    }

    public override void OnPointerDown(PointerEventData data)
    {
        Activate();
        _mousePos = Camera.main.ScreenToWorldPoint(data.position);
    }

    public override void OnPointerUp(PointerEventData data)
    {
        isActivated = false;
        _mousePos = Vector3.zero;
    }

    public override void OnPointerEnter(PointerEventData data) { }

    public override void OnPointerExit(PointerEventData data) { }
}
