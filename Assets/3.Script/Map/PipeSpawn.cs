using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    private GameObject[] pipes;
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField]
    private float startTime = 5f;
    private int length = 5;

    private void Awake()
    {
        GameObject pipesParent = GameObject.Find("Pipes");
        pipes = new GameObject[length];
        for (int i = 0; i < length; i++)
        {
            pipes[i] = Instantiate(pipePrefab, new Vector3(0, 3, 35 + i * 20), Quaternion.identity, pipesParent.transform);
            pipes[i].transform.name = "Pipe";
        }
    }
}
