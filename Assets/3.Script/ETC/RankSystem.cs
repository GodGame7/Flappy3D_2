using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class RankSystem : MonoBehaviour
{
    public static RankSystem instance = null;

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

    private int score;
    private string path;
    private string fileName = "Ranking.json";

    // �н� �ʱ�ȭ
    private void Awake()
    {
        //if (!Directory.Exists(Application.persistentDataPath))
        //{
        //    Directory.CreateDirectory(Application.persistentDataPath);
        //}
        path = Path.Combine(Application.persistentDataPath, fileName);
    }

    // �׾����� Ȯ��
    private void Update()
    {
        if(!GameManager.Instance.isGameOver)
        {
            return;
        }
        On_InputName();
    }

    // ���� ���� �� �̸��� �Է��� UI Ȱ��ȭ
    public void On_InputName()
    {
        score = GameManager.Instance.SCORE;
        inputName_UI.SetActive(true);
        pleaseRetry_txt.SetActive(false);
    }

    // �̸� �Է� �� ��ŷ Ȱ��ȭ
    public void On_Ranking()
    {
        // string���� ��ȯ
        string name = inputName_InputField.text;
        string new_score = score.ToString();

        // 3�������� Ȯ��
        if ( 1 > name.Length || name.Length > 3)
        {
            StopCoroutine(OnErrorMessage());
            StartCoroutine(OnErrorMessage());
            return;
        }

        // UI ����
        inputName_UI.SetActive(false);
        ranking_UI.SetActive(true);

        Ranking ranking = new Ranking
        {
            name = name,
            score = new_score
        };

        M_input_ranking_jaon(ranking);
    }

    // ������ ���ư���
    public void SceneLoader(string Scenename)
    {
        SceneManager.LoadScene(Scenename, LoadSceneMode.Single);
    }

    // ���� �޼��� ����
    IEnumerator OnErrorMessage()
    {
        pleaseRetry_txt.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        pleaseRetry_txt.SetActive(false);
    }

    // ��ŷ ����
    public void M_input_ranking_jaon(Ranking ranking)
    {
        // Json�� new ��� ���� �� ����
        string json = JsonConvert.SerializeObject(ranking);
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
        }
        string exist_json = File.ReadAllText(path);
        List<Ranking> exist_ranking = JsonConvert.DeserializeObject<List<Ranking>>(exist_json);                     // ������ Json ��ü�� ��ȯ
        IEnumerable<Ranking> combine_ranking = exist_ranking.Concat(new[] { ranking });                             // �� Json ��ü�� ��ħ.
        IEnumerable<Ranking> sorted_ranking = combine_ranking.OrderByDescending(n => double.Parse(n.score));        // ����
        string new_json = JsonConvert.SerializeObject(sorted_ranking);                                              // �� Json ����
        File.WriteAllText(path, new_json);                                                                     // Json�� �����

        // Json�� ����� ��� top9 ���
        List<Ranking> ranking_list = JsonConvert.DeserializeObject<List<Ranking>>(new_json);
        List<Ranking> top9_ranks = new List<Ranking>();
        for (int i = 0; i < 9 && i < ranking_list.Count; i++)
        {
            top9_ranks.Add(ranking_list[i]);
        }

        ranking_text.text = "����ǥ\n";
        for (int i = 0; i < 9 && i < ranking_list.Count; i++)
        {
            ranking_text.text += (i+1) + ".  " + top9_ranks[i].name + " : " + top9_ranks[i].score + "\n"; 
        }

    }
}


