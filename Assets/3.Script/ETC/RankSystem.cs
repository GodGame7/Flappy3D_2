using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankSystem : MonoBehaviour
{
    // 랭킹을 저장할 자료구조
    public struct Ranking
    {
        public string name;
        public string score;

        public Ranking(string name, string score)
        {
            this.name = name;
            this.score = score;
        }
    }

    [Header("InputName_UI")]
    [SerializeField] private GameObject inputName_UI;
    [SerializeField] private InputField inputName_InputField;
    [SerializeField] private GameObject pleaseRetry_txt;

    [Header("Ranking_UI")]
    [SerializeField] private GameObject ranking_UI;
    [SerializeField] private Text ranking_text;

    // 게임 종료 후 이름을 입력할 UI 활성화
    public void On_InputName()
    {
        inputName_UI.SetActive(true);
        pleaseRetry_txt.SetActive(false);
    }

    // 이름 입력 후 랭킹 활성화
    public void On_Ranking()
    {
        string name = inputName_InputField.text;
        if (name.Length > 3)
        {
            StopCoroutine(OnErrorMessage());
            StartCoroutine(OnErrorMessage());
            return;
        }
        inputName_UI.SetActive(false);
        ranking_UI.SetActive(true);
        ranking_text.text = "순위표";
    }

    IEnumerator OnErrorMessage()
    {
        pleaseRetry_txt.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        pleaseRetry_txt.SetActive(false);
    }
}

