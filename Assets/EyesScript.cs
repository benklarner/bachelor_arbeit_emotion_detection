using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Timeline;

public class EyesScript : MonoBehaviour
{
    public GameObject LookAtGoal; //goal for the eyes to look at
    public GameObject EyeLeft;
    public GameObject EyeRight;

    public SkinnedMeshRenderer EyeAndLeash;
    public SkinnedMeshRenderer CharacterMesh;

    public bool EyeClosed = false;
    public bool bBlink = false;

    public float BlinkValue = 0.0f; //the value for the blendshapes


    public float BlinkTime; //the duration of a blink, just for testing

    public float BlinkTimer; //Time counter until next blink

    public float NextBlink; //Time that it takes until next blink

    public float BlinkSpeed=600f; //a natural blink speed. blinking takes around 322ms


    // Start is called before the first frame update
    void Start()
    {
        
        NextBlink = Random.Range(4f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        EyeLeft.transform.LookAt(LookAtGoal.transform);
        EyeRight.transform.LookAt(LookAtGoal.transform);
        EyeAndLeash.SetBlendShapeWeight(EyeAndLeash.sharedMesh.GetBlendShapeIndex("head__eCTRLEyesClosed"), BlinkValue);
        CharacterMesh.SetBlendShapeWeight(CharacterMesh.sharedMesh.GetBlendShapeIndex("head__eCTRLEyesClosed"), BlinkValue);

        BlinkTimer += Time.deltaTime;
        if (BlinkTimer >= NextBlink)
        {
            bBlink = true;
        }

        if (bBlink)
        {
           Blink();
        }
        
    }


    /*public void Blink()
    {
        StartCoroutine("CBlink");
    }*/

    public void Blink()
    {
        BlinkTime += Time.deltaTime;
        if ((BlinkValue < 100f) && (!EyeClosed))
        {
            BlinkValue += BlinkSpeed * Time.deltaTime;

            if (BlinkValue >= 100f)
            {
                BlinkValue = 100f;
                EyeClosed = true;
            }
        }
        if ((BlinkValue > 0) && (EyeClosed))
        {
            BlinkValue -= BlinkSpeed * Time.deltaTime;

            if (BlinkValue <= 0)
            {
                BlinkValue = 0;
                EyeClosed = false;
                bBlink = false;
                NextBlink = Random.Range(4f, 6f);
                BlinkTimer = 0f;
            }
        }

    }
}
