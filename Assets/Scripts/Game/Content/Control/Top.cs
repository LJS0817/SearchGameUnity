using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Extended;

public class Top : ViewController, IPointerMoveHandler
{
    RectTransform _rect;
    Vector2 ScreenCenterSize;

    public void ConnectRectTransform(RectTransform r)
    {
        _rect = r;
        ScreenCenterSize = new Vector2(Screen.width, Screen.height);
    }

    public override void init(string str)
    {
        base.init(str);
    }

    public void OnPointerMove(PointerEventData data)
    {
        if(isActivated)
        {
            //_rect.position = Camera.main.ScreenToWorldPoint(data.position);
        }
        //Debug.Log((data.position - _rect.sizeDelta) / _rect.sizeDelta);
    }

    public override void OnPointerDown(PointerEventData data)
    {
        Activate();
        Debug.Log(_rect.position);
        Vector3 pivot = _rect.pivot;
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(data.position);
        //mousePos.z = 0;

        _rect.pivot = pivot;
    }

    public override void OnPointerUp(PointerEventData data)
    {
        isActivated = false;
        //_rect.transform.position = ((Vector2)_rect.transform.position + (Extend.DEFAULT_PIVOT - _rect.pivot));
        //_rect.pivot = Extend.DEFAULT_PIVOT;
    }

    public override void OnPointerEnter(PointerEventData data) { }

    public override void OnPointerExit(PointerEventData data) { }
}
