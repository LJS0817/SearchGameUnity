using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Top : ViewController
{
    Vector3 mousePos;

    public delegate void ifWasFullEvent(Vector3 pos);
    private ifWasFullEvent fullEvent;

    public void setFullEvent(ifWasFullEvent e)
    {
        fullEvent = e;
    }

    public override void ViewEvent(RectTransform rect)
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); 
        pos = Camera.main.ScreenToWorldPoint(pos);
        rect.position += (pos - mousePos);
        mousePos = pos;
    }

    public override void OnPointerDown(PointerEventData data)
    {
        base.OnPointerDown(data);
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //fullEvent(mousePos);
    }

    public override void OnPointerExit(PointerEventData data) {  }

    public override void OnPointerUp(PointerEventData data)
    {
        isActivated = false;
    }
}
