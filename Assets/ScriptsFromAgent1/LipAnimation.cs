using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * Plays lip animation when indicated by the LipSyncTool
 * This happens by manipulating the BlendShapes
 */

public class LipAnimation : MonoBehaviour
{

    //public GameObject M3D;

    public Text playcount;
    public int iplaycount;

    public bool canPlay = false;

    public float speedMin, speedMax, delayMin, delayMax;

    public SkinnedMeshRenderer MaleSkinnedMeshRenderer;
    public SkinnedMeshRenderer FemaleSkinnedMeshRenderer;
    //Mesh skinnedMesh;
    float blendOne = 0f;
    float blendSpeed = 3f;
    bool moveBack = false;
    public bool Male = true;

    //public int FindShape;

    void Awake()
    {
        //skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        //skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        /*if (Male)
        {
            FindShape = MaleSkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Male__eCTRLMouthOpen");
        }
        if (!Male)
        {
            FindShape = FemaleSkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("Genesis8Female__eCTRLMouthOpen");
        }*/
       
    }

    // Update is called once per frame
    void Update()
    {
        playcount.text = iplaycount.ToString();
       // FindShape = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("eCTRLMouthOpen");
        if (canPlay)
        {
            iplaycount += 1;
            if ((blendOne < (int)30) && (moveBack == false))
            {
                blendOne += blendSpeed;
            }
            else
            {
                moveBack = true;
                blendOne -= blendSpeed / 4;
            }
        }
        else
        {
            moveBack = false;
            blendOne = 0;
        }
        if (Male)
        {
            //M3D.GetComponent<M3DCharacterManager>().SetBlendshapeValue("eCTRLMouthOpen", blendOne*4);
            MaleSkinnedMeshRenderer.SetBlendShapeWeight(MaleSkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("head__eCTRLMouthOpen"), blendOne);
        }
            

        if (!Male)
        {
            //M3D.GetComponent<M3DCharacterManager>().SetBlendshapeValue("eCTRLMouthOpen", blendOne*4);
            FemaleSkinnedMeshRenderer.SetBlendShapeWeight(FemaleSkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("head__eCTRLMouthOpen"), blendOne);
        }
            

    }

    public void stopAnimation()
    {
        canPlay = false;
    }


}