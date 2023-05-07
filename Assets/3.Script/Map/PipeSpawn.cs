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
    [SerializeField]
    private int cnt = 3;

    private void Awake()
    {
        GameObject pipesParent = GameObject.Find("Pipes");
        pipes = new GameObject[cnt];
        for (int i = 0; i < cnt; i++)
        {
            pipes[i] = Instantiate(pipePrefab);
            pipes[i].transform.SetParent(pipesParent.transform);
            pipes[i].transform.name = "Pipe";
            pipes[i].SetActive(false);
        }
        StartCoroutine(nameof(PipeLoop_co));
    }


    private IEnumerator PipeLoop_co()
    {
        yield return new WaitForSeconds(startTime);

        Vector3 position = Vector3.zero;
        for (int i = 0; i < cnt; i++)
        {
            pipes[i].SetActive(true);
            pipes[i].transform.position = new Vector3(0, pipes[i].transform.position.y, 35 + i * 20);
        }
    }
}
