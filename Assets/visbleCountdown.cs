using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class visbleCountdown : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _title;

    public void DisplayTime(float time, string addon)
    {
        _title.text = time.ToString() + addon; 
    }
}
