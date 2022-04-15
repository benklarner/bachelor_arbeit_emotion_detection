using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crosstales.RTVoice;
using UnityEngine.UI;


public class TestScript : MonoBehaviour
{
    //public Speaker speaker;
    public SkinnedMeshRenderer Character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Character.SetBlendShapeWeight(Character.sharedMesh.GetBlendShapeIndex("head__eCTRLMouthOpen"), GameObject.Find("SliderMouth").GetComponent<Slider>().value);
    }
}
