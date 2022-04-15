using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadIK : MonoBehaviour
{

    public GameObject HeadLookGoal;
    public Animator MyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnAnimatorIK()
    {
        MyAnimator.SetLookAtPosition(HeadLookGoal.transform.position);
        MyAnimator.SetLookAtWeight(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
