using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowIcon : MonoBehaviour, IPointerClickHandler
{
    Image stateIcon;
    Image imageIcon;
    Animator ani;
    View view;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        stateIcon = transform.GetChild(0).GetComponent<Image>();
        imageIcon = transform.GetChild(1).GetComponent<Image>();
    }

    public bool getEnable()
    {
        return ani.GetBool("Enable");
    }

    public void ConnectView(View v)
    {
        view = v;
    }

    public void SetActive(bool b)
    {
        ani.SetBool("Enable", b);
    }

    public void OnPointerClick(PointerEventData data)
    {
        view.SetEnable();
        if (!getEnable())
        {
            SetActive(true);
            Minimum min = GameObject.Find("/Canvas/" + name + "/TopBar/Controller/Min").GetComponent<Minimum>();
            min.SetIconPosition(transform.position, view.SaveState, view.SetDisable);
            Close close = GameObject.Find("/Canvas/" + name + "/TopBar/Controller/Close").GetComponent<Close>();
            close.SetCloseEvent(view.SaveState, () => { SetActive(false); });
            //Top top = GameObject.Find("/Canvas/" + name + "/TopBar/Move").GetComponent<Top>();
            //top.setFullEvent(MoveIfWasFullEvent);
        }
    }

    void MoveIfWasFullEvent(Vector3 pos)
    {
        if(view.isFull())
        {
            view.ActivateOnce(2);
            view.SaveStateWithVector3(pos);
        }
    }
}
