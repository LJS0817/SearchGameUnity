using Extended;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSide : ViewController
{
    RectTransform _rect;
    Vector2 _screenCenter;

    Vector2 _eRange;
    Vector2 _dir;
    Vector3 _mPos;
    Vector2 _mouseLocked;

    public void ConnectRectTransform(RectTransform r)
    {
        _rect = r;
    }

    public override void init(string str)
    {
        base.init(str);
        _screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        _eRange = new Vector2(10f, 10f);
        _dir = Vector2.zero;
        _mPos = Vector3.zero;
        _mouseLocked = Vector2.zero;
    }

    public override void ViewEvent(RectTransform rect)
    {
        Vector3 p = Input.mousePosition;
        Vector3 mp = p - _mPos;
        mp *= _dir;
        mp += (Vector3)rect.sizeDelta;
        if (mp.x < Extend.MIN_SIZE.x) { mp.x = Extend.MIN_SIZE.x; _mouseLocked.x = 1; }
        else if (_mouseLocked.x != 0) { _mouseLocked.x = 0; }
        if(mp.y < Extend.MIN_SIZE.y) { mp.y = Extend.MIN_SIZE.y; _mouseLocked.y = 1; }
        else if (_mouseLocked.y != 0) { _mouseLocked.y = 0; }
        rect.sizeDelta = (Vector2)mp;

        _mPos.x = _mouseLocked.x == 1 ? _mPos.x : p.x;
        _mPos.y = _mouseLocked.y == 1 ? _mPos.y : p.y;
    }

    public override void OnPointerDown(PointerEventData data)
    {
        Activate();
        changePivot(data.position);
        _mPos = Input.mousePosition;
    }

    public override void OnPointerUp(PointerEventData data)
    {
        //base.OnPointerUp(data)
        isActivated = false;
        Vector2 size = new Vector2(_rect.rect.width * 0.5f, _rect.rect.height * 0.5f);
        size = Camera.main.ScreenToWorldPoint(size + _screenCenter) * _dir;
        Debug.Log(size);
        _rect.position += (Vector3)size;
        _rect.pivot = Extend.DEFAULT_PIVOT;
        _dir = Vector2.zero;
        _mouseLocked = Vector2.zero;
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        
    }

    public override void OnPointerExit(PointerEventData data)
    {
        
    }

    private void changePivot(Vector3 pos)
    {
        Vector2 calc = pos - Camera.main.WorldToScreenPoint(_rect.position);
        Vector2 size = new Vector2(_rect.rect.xMax, _rect.rect.yMax);
        Vector3 viewPos = Camera.main.ScreenToWorldPoint(size + _screenCenter);
        viewPos.z = 0;

        if (calc.x < -size.x + _eRange.x && calc.y < -size.y + _eRange.y) {                 // ¦¦ left + bottom
            _rect.pivot = new Vector2(1, 1);
        } 
        else if (calc.x < -size.x + _eRange.x && calc.y > size.y - _eRange.y) {           // ¦£ left + top
            _rect.pivot = new Vector2(1, 0);
            viewPos.y *= -1;
        } 
        else if (calc.x > size.x - _eRange.x && calc.y < -size.y + _eRange.y) {           // ¦¥ right + bottm
            _rect.pivot = new Vector2(0, 1);
            viewPos.x *= -1;
        } 
        else if(calc.x > size.x - _eRange.x && calc.y > size.y - _eRange.y) {             // ¦¤ right _ top
            _rect.pivot = new Vector2(0, 0);
            viewPos *= -1;
        } 
        else if(calc.x > size.x)  {               // ¦¢ right
            _rect.pivot = new Vector2(0, 0.5f);
            viewPos.y = 0;
            viewPos.x *= -1;
        }
        else if(calc.x < -size.x)  {              // ¦¢ left
            _rect.pivot = new Vector2(1, 0.5f);
            viewPos.y = 0;
        } 
        else if(calc.y > size.y)  {               // ¦¡ top
            _rect.pivot = new Vector2(0.5f, 0);
            viewPos.x = 0;
            viewPos.y *= -1;
        }
        else if(calc.y < -size.y)  {              // ¦¡ bottom
            _rect.pivot = new Vector2(0.5f, 1);
            viewPos.x = 0;
        }
        _rect.position += viewPos;
        setDirection();
    }

    private void setDirection()
    {
        _dir = _rect.pivot;
        if (_dir.x == 0) _dir.x = 1;
        else if (_dir.x == 1) _dir.x = -1;
        else _dir.x = 0;

        if (_dir.y == 0) _dir.y = 1;
        else if (_dir.y == 1) _dir.y = -1;
        else _dir.y = 0;
    }
}
