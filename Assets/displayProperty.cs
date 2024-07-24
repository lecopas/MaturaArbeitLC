using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayProperty : MonoBehaviour
{

    [SerializeField]
    private Text _title;

    public void ShowProperty(float value, string unit)
    {
        _title.text = value + unit;
    }
}
