using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankSystem : MonoBehaviour
{
    // ��ŷ�� ������ �ڷᱸ��
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

    // ���� ���� �� �̸��� �Է��� UI Ȱ��ȭ
    public void On_InputName()
    {
        inputName_UI.SetActive(true);
        pleaseRetry_txt.SetActive(false);
    }

    // �̸� �Է� �� ��ŷ Ȱ��ȭ
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
        ranking_text.text = "����ǥ";
    }

    IEnumerator OnErrorMessage()
    {
        pleaseRetry_txt.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        pleaseRetry_txt.SetActive(false);
    }
}

