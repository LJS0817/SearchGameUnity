using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SMS_ProfileLong : MonoBehaviour
{
    TMP_Text _name;
    TMP_Text _number;
    Image _icon;
    Button _back;

    // Start is called before the first frame update
    void Start()
    {
        _name = transform.GetChild(2).GetComponent<TMP_Text>();
        _number = transform.GetChild(3).GetComponent<TMP_Text>();
        _icon = transform.GetChild(1).GetComponent<Image>();
        _back = transform.GetChild(0).GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(int idx, string str)
    {
        _name.text = str;
        _number.text = idx.ToString();
    }
}
