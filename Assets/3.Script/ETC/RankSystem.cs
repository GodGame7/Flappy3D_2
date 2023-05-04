using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankSystem : MonoBehaviour
{
    // Json�� ������ ��ŷ ����
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

    [Header("InputNameUI")]
    [SerializeField] private static GameObject inputName_UI;
    [SerializeField] private static InputField inputName_inputfield;

    [Header("RankingUI")]
    [SerializeField] private static GameObject ranking_UI;


    // ���� ���� �� ����Ǿ� �̸��� �Է��� UI�� ��� �޼ҵ�
    private static void On_InputUI()
    {
        inputName_UI.SetActive(true);
    }

    private static void On_Ranking()
    {

        inputName_UI.SetActive(false);
    }
  


}
