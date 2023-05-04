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

    [Header("Ranking_UI")]
    [SerializeField] private GameObject ranking_UI;
    [SerializeField] private Text ranking_text;


}


