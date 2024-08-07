using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : View
{
    protected override void init()
    {
        Animator obj = GameObject.Find("/Canvas/" + name + "/Content/Detail").GetComponent<Animator>();

        Button btn = GameObject.Find("/Canvas/" + name + "/Content/Detail/InfoView/Container/Viewport/Content/Profile/Close").GetComponent<Button>();
        btn.onClick.AddListener(() => { obj.SetTrigger("ChangeState"); });

        btn = GameObject.Find("/Canvas/" + name + "/Content/Detail/Container/Actions/Info").GetComponent<Button>();
        btn.onClick.AddListener(() => { obj.SetTrigger("ChangeState"); });

        base.init();
    }
}
