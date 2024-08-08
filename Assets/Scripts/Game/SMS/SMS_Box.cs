using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SMS_Box : MonoBehaviour
{
    RectTransform _rect;
    TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _rect = GetComponent<RectTransform>();
        _text = transform.GetChild(0).GetComponent<TMP_Text>();

        SetText(_text.text);
    }

    public void SetText(string str)
    {
        _text.SetText(str);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SetText("ASJKDHASDKLJASDXZNBCKZXMCASJKLDHASKLDASKLJDAS");
        }
    }
}
