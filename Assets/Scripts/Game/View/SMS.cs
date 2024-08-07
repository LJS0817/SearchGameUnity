using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SMS : View
{
    RectTransform _profiles;
    RectTransform _detail;

    ScrollRect _profileScrollView;
    ScrollRect _detailScrollView;

    GameObject _profileObject;

    readonly string[] _userList = { "friend", "mom" };
    List<SMS_User> _users;

    protected override void init()
    {
        _profiles = transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
        _detail = transform.GetChild(2).GetChild(1).GetComponent<RectTransform>();

        _profileScrollView = _profiles.GetComponent<ScrollRect>();
        _detailScrollView = _detail.GetComponent<ScrollRect>();

        _profileObject = GameObject.Find("GameManager").GetComponent<GameManager>().Prefabs[0];

        addProfile();

        base.init();
    }

    protected override void update()
    {
        if(_enable)
        {
            if (_rect.sizeDelta.x > 1100 && _profiles.sizeDelta.x == 210f)
            {
                _profiles.sizeDelta = addX(30f, _profiles.sizeDelta);
                _detail.sizeDelta = addX(-30f, _detail.sizeDelta);
            } 
            else if (_rect.sizeDelta.x <= 1100 && _rect.sizeDelta.x > 750 && _profiles.sizeDelta.x != 210f)
            {
                if (_profiles.sizeDelta.x == 180f)
                {
                    _profiles.sizeDelta = addX(30f, _profiles.sizeDelta);
                    _detail.sizeDelta = addX(-30f, _detail.sizeDelta);
                } else if (_profiles.sizeDelta.x == 240f)
                {
                    _profiles.sizeDelta = addX(-30f, _profiles.sizeDelta);
                    _detail.sizeDelta = addX(30f, _detail.sizeDelta);
                }
            }
            else if(_rect.sizeDelta.x <= 750 && _profiles.sizeDelta.x != 180f)
            {
                _profiles.sizeDelta = addX(-30f, _profiles.sizeDelta);
                _detail.sizeDelta = addX(30f, _detail.sizeDelta);
            }

        }
    }

    Vector2 addX(float target, Vector2 v)
    {
        return new Vector2(v.x + target, v.y);
    }

    void addProfile()
    {
        for(int i = 0; i < _userList.Length; i++)
        {
            GameObject obj = GameObject.Instantiate(_profileObject);
            obj.transform.SetParent(_profileScrollView.content);
            obj.GetComponent<SMS_User>().Connect(i, _userList[i]);
        }
        _profileScrollView.content.sizeDelta = new Vector2(_profileScrollView.content.sizeDelta.x, 50f * _userList.Length);
    }
}
