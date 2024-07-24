using Extended;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Close : ViewController
{
    Vector2 _iconPos;

    public override void init(string str)
    {
        base.init(str);
        _iconPos = GameObject.Find("/Canvas/AppList/" + _id).transform.position;
    }

    public override void ViewEvent(RectTransform rect)
    {
        if (isActivated)
        {
            rect.position = Vector2.Lerp(rect.position, _iconPos, 10f * Time.deltaTime);
            rect.sizeDelta = Vector2.Lerp(rect.sizeDelta, Extend.MIN_SIZE, 10f * Time.deltaTime);
            if (Mathf.Abs(rect.position.magnitude - _iconPos.magnitude) +
                Mathf.Abs(rect.sizeDelta.magnitude - Extend.MIN_SIZE.magnitude) < 1f)
            {
                rect.position = Extend.DISABLED_POSITION;
                isActivated = false;
            }
        }
    }
}
