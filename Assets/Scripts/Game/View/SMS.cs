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

    Animator _ContentAni;

    SMS_ProfileLong _longProfile;

    public GameObject ProfileObject;
    public GameObject ChatCardObject;
    public GameObject MyChatCardObject;

    readonly string[] _userList = { "friend", "mom" };
    List<SMS_User> _users;

    protected override void init()
    {
        _profiles = transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
        _detail = transform.GetChild(2).GetChild(1).GetComponent<RectTransform>();

        _profileScrollView = _profiles.GetComponent<ScrollRect>();
        _detailScrollView = _detail.GetComponent<ScrollRect>();

        _ContentAni = transform.GetChild(2).GetComponent<Animator>();
        _longProfile = _ContentAni.transform.GetChild(2).GetComponent<SMS_ProfileLong>();

        addProfile();

        base.init();
    }

    protected override void update()
    {
        if(_enable)
        {
            if(_ContentAni.GetBool("Show"))
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
                    }
                    else if (_profiles.sizeDelta.x == 240f)
                    {
                        _profiles.sizeDelta = addX(-30f, _profiles.sizeDelta);
                        _detail.sizeDelta = addX(30f, _detail.sizeDelta);
                    }
                }
                else if (_rect.sizeDelta.x <= 750 && _profiles.sizeDelta.x != 180f)
                {
                    _profiles.sizeDelta = addX(-30f, _profiles.sizeDelta);
                    _detail.sizeDelta = addX(30f, _detail.sizeDelta);
                }
                else if (_rect.sizeDelta.x <= 450)
                {
                    _ContentAni.SetBool("Show", false);
                }
            }  
            else if(_rect.sizeDelta.x > 450)
            {
                _ContentAni.SetBool("Show", true);
            }

        }
    }

    Vector2 addX(float target, Vector2 v)
    {
        return new Vector2(v.x + target, v.y);
    }

    void addProfile()
    {
        Destroy(_profileScrollView.content.GetChild(0).gameObject);
        for (int i = 0; i < _userList.Length; i++)
        {
            GameObject obj = GameObject.Instantiate(ProfileObject);
            obj.transform.SetParent(_profileScrollView.content);
            obj.GetComponent<SMS_User>().Connect(i, _userList[i]);
            int idx = i;
            obj.GetComponent<Button>().onClick.AddListener(() => { _longProfile.SetData(idx, _userList[idx]); });
        }
        _profileScrollView.content.sizeDelta = new Vector2(_profileScrollView.content.sizeDelta.x, 50f * _userList.Length);
    }
}
