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
            pipes[i] = Instantiate(pipePrefab);
            pipes[i].transform.SetParent(pipesParent.transform);
            pipes[i].transform.name = "Pipe";
            pipes[i].SetActive(false);
            //pipes[i] = transform.GetChild(i).gameObject;
        }
        StartCoroutine(nameof(PipeLoop_co));
    }


    private IEnumerator PipeLoop_co()
    {
        yield return null;

        Vector3 position = Vector3.zero;
        for (int i = 0; i < length; i++)
        {
            pipes[i].SetActive(true);
            pipes[i].transform.position = new Vector3(0, pipes[i].transform.position.y, 35 + i * 20);
        }
    }
}
