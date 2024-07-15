using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Maximum : ViewController
{
    //Vector2 ScreenSize = new Vector2(Screen.width, Screen.height);
    //Vector2 WindowSize = Vector2.zero;

    //Vector2 BeforePos = Vector2.zero;
    //readonly Vector2 FullPos = Vector2.zero;

    //bool isFull = false;

    //Vector2 getSize()
    //{
    //    if (isFull) return WindowSize;
    //    else return ScreenSize;
    //}

    //Vector2 getPos()
    //{
    //    if (isFull) return BeforePos;
    //    else return FullPos;
    //}

    //public override void ViewEvent(RectTransform rect)
    //{
    //    if (WindowSize == Vector2.zero) WindowSize = rect.sizeDelta;
    //    if (BeforePos == Vector2.zero && !isFull) BeforePos = rect.position;

    //    rect.position = Vector2.Lerp(rect.position, getPos(), 15f * Time.deltaTime);
    //    rect.sizeDelta = Vector2.Lerp(rect.sizeDelta, getSize(), 15f * Time.deltaTime);
    //    if (Vector2.Distance(getSize(), rect.sizeDelta) < 0.5f)
    //    {
    //        rect.sizeDelta = getSize(); 
    //        isFull = !isFull;
    //        if (!isFull) BeforePos = Vector2.zero;
    //        isActivated = false;
    //    }
    //}

    //public override void OnPointerEnter(PointerEventData data)
    //{
    //    needChange = true;
    //    tempColor = targetColor;
    //}

    //public override void OnPointerExit(PointerEventData data)
    //{
    //    needChange = true;
    //    tempColor = sourceColor;
    //}

    //public override void OnPointerDown(PointerEventData data)
    //{
    //    isActivated = true;
    //}

    //public override void OnPointerUp(PointerEventData data) { }

}