using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManage : MonoBehaviour
{
    public TextMeshProUGUI valueText;
   
    public void OnSLiderChanged(float value)
    {
        valueText.text = value.ToString();
    }
}
