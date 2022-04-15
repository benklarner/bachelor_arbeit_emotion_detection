using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *LipSyncTool as supposed in Ali Hassan's Tutorial.
 * Retrieved at: http://alihc.me/unity-3d-lip-sync-with-audio/
 */
public class LipSyncTool : MonoBehaviour
{
    private bool m_IsOk = false;
    private int m_NumSamples = 1024;
    private float[] m_SamplesL, m_SamplesR;
    private int i;
    private float maxL, maxR, sample, sumL, sumR, rms, dB;
    private Vector3 scaleL, scaleR;
    // Because rms values are usually very low
    private float volume = 30.0f;
    private Color color;
    public AudioSource audio;
    public LipAnimation jaw;
    // Use this for initialization
    void Start()
    {
        m_IsOk = true;
        m_SamplesL = new float[m_NumSamples];
        m_SamplesR = new float[m_NumSamples];
    }
    public void setLipSyncOn()
    {
        audio = GetComponent<AudioSource>();
        m_IsOk = true;
    }
    public void setLipSyncOff()
    {
        jaw.stopAnimation();
        m_IsOk = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Continuing proper validation
        if (m_IsOk)
        {
            audio.GetOutputData(m_SamplesL, 0);
            audio.GetOutputData(m_SamplesR, 1);
            maxL = maxR = 0.0f;
            sumL = 0.0f;
            sumR = 0.0f;
            for (i = 0; i < m_NumSamples; i++)
            {
                sumL = m_SamplesL[i] * m_SamplesL[i];
                sumR = m_SamplesR[i] * m_SamplesR[i];
            }
            rms = Mathf.Sqrt(sumL / m_NumSamples);
            scaleL.y = Mathf.Clamp01(rms * volume);
            rms = Mathf.Sqrt(sumR / m_NumSamples);
            scaleR.y = Mathf.Clamp01(rms * volume);
            if (scaleL.y > 0.01f || scaleR.y > 0.01f)
            {
                jaw.canPlay = true;
            }
            else
            {
                jaw.stopAnimation();
            }
        }
    }
}