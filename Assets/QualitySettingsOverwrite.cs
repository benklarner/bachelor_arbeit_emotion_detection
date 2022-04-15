using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualitySettingsOverwrite : MonoBehaviour
{
    public Text DebugText;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.skinWeights = SkinWeights.FourBones;
    }

    // Update is called once per frame
    void Update()
    {
        DebugText.text = QualitySettings.skinWeights.ToString();
    }
}
