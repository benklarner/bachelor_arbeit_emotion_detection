using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceMorphs : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;

    //public Slider SliderAngry;
    
    // Start is called before the first frame update
    void Start()
    {
        //SliderAngry = GameObject.Find("SliderAngry");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlendAngry()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Male__eCTRLAngry_HD"), GameObject.Find("SliderAngry").GetComponent<Slider>().value);
    }
    public void BlendAfraid()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Male__eCTRLAfraid_HD"), GameObject.Find("SliderAfraid").GetComponent<Slider>().value);
    }
    public void BlendShock()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Male__eCTRLShock_HD"), GameObject.Find("SliderShock").GetComponent<Slider>().value);
    }
    public void BlendFrown()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Male__eCTRLFrown_HD"), GameObject.Find("SliderFrown").GetComponent<Slider>().value);
    }
    public void BlendSmileFullFace()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Male__eCTRLSmileFullFace_HD"), GameObject.Find("SliderSmileFullFace").GetComponent<Slider>().value);
    }
    public void BlendFlirting()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Male__eCTRLFlirting_HD"), GameObject.Find("SliderFlirting").GetComponent<Slider>().value);
    }
    public void BlendMouthSmile()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Male__eCTRLMouthSmile"), GameObject.Find("SliderMouthSmile").GetComponent<Slider>().value);
    }
    public void BlendEarsElfLong()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Male__PHMEarsElfLong"), GameObject.Find("SliderEarsElfLong").GetComponent<Slider>().value);
    }
}
