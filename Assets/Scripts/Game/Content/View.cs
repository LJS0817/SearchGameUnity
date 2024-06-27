using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    private string _name;
    RectTransform _rect;
    ControllerManager _controller;
    Animator _ani;

    Vector3 CurSize;
    Vector3 CurPosition;

    private void Awake()
    {
        _ani = GetComponent<Animator>();
        _name = transform.name;
        _controller = transform.GetChild(0).GetComponent<ControllerManager>();
        _rect = GetComponent<RectTransform>();

        SetDisable();
    }

    // Start is called before the first frame update
    void Start()
    {
        CurSize = GameManager.DEFAULT_SIZE;
        CurPosition = Vector3.zero;
    }

    public void SetDisable()
    {
        _rect.position = GameManager.DISABLED_POSITION;
    }

    public void SetEnable()
    {
        _rect.sizeDelta = CurSize;
        _rect.position = CurPosition;
        _ani.SetTrigger("ChangeState");
    }

    public void SaveState()
    {
        CurSize = _rect.sizeDelta;
        CurPosition = _rect.position;
        _ani.SetTrigger("ChangeState");
    }

    public void SaveStateWithVector3(Vector3 pos)
    {
        CurSize = pos;
        CurPosition = pos;
    }

    void Update()
    {
        viewEvent();
    }

    void viewEvent()
    {
        _controller.getCurrentEvent(_rect);
    }

    /// <summary>
    /// <para>0 == 이동</para>
    /// <para>1 == 닫기</para>
    /// <para>2 == 최대화</para>
    /// 3 == 최소화
    /// </summary>
    /// <param name="type"></param>
    public void ActivateOnce(int type)
    {
        _controller.setEvent(type);
    }

    public bool isFull()
    {
        return _controller.isActivatedEvent(2);
    }
}
