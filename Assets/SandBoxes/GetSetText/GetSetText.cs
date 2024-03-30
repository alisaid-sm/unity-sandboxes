using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSetText : MonoBehaviour
{
    private Text _text;
    [SerializeField] private string _firstText;

    // Start is called before the first frame update
    void Start()
    {
        _text = transform.GetComponent<Text>();
    }

    public void SetText(string text)
    {
        if (_text != null)
        {
            _text.text = $"{_firstText}{text}";
        }
    }

    public string GetTextValue()
    {
        return _text.text.Substring(_firstText.Length);
    }
}
