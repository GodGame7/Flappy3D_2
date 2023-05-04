using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{


    [SerializeField]private float blinkInterval = 0.2f;
    [SerializeField] private GameObject button;
    Coroutine Blink_co;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Blink_co == null)
            Blink_co = StartCoroutine(CoBlink());


    }

    IEnumerator CoBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);

            button.SetActive(!button.activeSelf);
        }
    }
}
