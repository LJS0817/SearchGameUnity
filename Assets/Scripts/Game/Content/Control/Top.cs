using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Top : ViewController
{
    //Vector3 mousePos;

    //public delegate void ChangePivotEvent(bool changePivot);
    //private ChangePivotEvent cEvent;

    //public void setEvent(ChangePivotEvent e)
    //{
    //    cEvent = e;
    //}

    //public override void ViewEvent(RectTransform rect)
    //{
    //    //Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    //    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    pos.z = 0;
    //    rect.position += (pos - mousePos);
    //    mousePos = pos;
    //}

    //public override void OnPointerDown(PointerEventData data)
    //{
    //    base.OnPointerDown(data);
    //    //mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    //    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    mousePos.z = 0;
    //    cEvent(false);
    //    //fullEvent(mousePos);
    //}

    //public override void OnPointerExit(PointerEventData data) {  }

    //public override void OnPointerUp(PointerEventData data)
    //{
    //    isActivated = false;
    //    cEvent(true);
    //}
}
