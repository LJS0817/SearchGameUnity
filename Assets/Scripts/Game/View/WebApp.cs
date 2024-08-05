using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WebApp : MonoBehaviour
{
    TMP_InputField textEdit;

    // Start is called before the first frame update
    private void Start()
    {
        textEdit = transform.GetChild(3).GetChild(0).GetComponent<TMP_InputField>();
        textEdit.onValueChanged.AddListener(onTextChanged);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void onTextChanged(string str)
    {
        Debug.Log(str);
    }
}
