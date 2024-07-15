using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    //private string _name;
    //RectTransform _rect;
    ControllerManager _controller;
    //Animator _ani;

    //Vector3 CurSize;
    //Vector3 CurPosition;

    private void Start()
    {
        _controller = transform.GetChild(0).GetComponent<ControllerManager>();
    }

    //public void SetDisable()
    //{
    //    _rect.position = GameManager.DISABLED_POSITION;
    //    _rect.pivot = GameManager.DEFAULT_PIVOT;
    //}

    //public void SetEnable()
    //{
    //    _rect.sizeDelta = CurSize;
    //    _rect.position = CurPosition;
    //    _ani.SetTrigger("ChangeState");
    //}

    //public void SaveState()
    //{
    //    CurSize = _rect.sizeDelta;
    //    CurPosition = _rect.position;
    //    _ani.SetTrigger("ChangeState");
    //}

    //public void SaveStateWithVector3(Vector3 pos)
    //{
    //    CurSize = pos;
    //    CurPosition = pos;
    //}

    //void Update()
    //{
    //    viewEvent();
    //}

    //void viewEvent()
    //{
    //    _controller.getCurrentEvent(_rect);
    //}

    /////// <summary>
    /////// <para>0 == 이동</para>
    /////// <para>1 == 닫기</para>
    /////// <para>2 == 최대화</para>
    /////// 3 == 최소화
    /////// </summary>
    /////// <param name="type"></param>
    ////public void ActivateOnce(int type)
    ////{
    ////    _controller.setEvent(type);
    ////}

    //public void SetPivot(Vector2 vec)
    //{
    //    _rect.pivot = vec;
    //}
}
