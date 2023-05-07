using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PipeOnOff : MonoBehaviour
{
    int length;
    public MeshRenderer[] meshRenderers;

    private void OnEnable()
    {
        length = transform.childCount;
        meshRenderers = new MeshRenderer[length];
        for (int i = 0; i < length; i++)
        {
            meshRenderers[i] = transform.GetChild(i).GetComponent<MeshRenderer>();
        }
    }

    public void PipeOn()
    {
        for (int i = 0; i < length; i++)
        {
            if (meshRenderers[i] != null)
            {
                meshRenderers[i].enabled = true;
            }
        }
    }

    public void PipeOff()
    {
        for (int i = 0; i < length; i++)
        {
            if (meshRenderers[i] != null)
            {
                meshRenderers[i].enabled = false;
            }
        }
    }
}
