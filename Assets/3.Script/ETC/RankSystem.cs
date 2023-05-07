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

    private int score;
    private string path;
    private string fileName = "Ranking.json";

    // 패스 초기화
    private void Awake()
    {
        //if (!Directory.Exists(Application.persistentDataPath))
        //{
        //    Directory.CreateDirectory(Application.persistentDataPath);
        //}
        path = Path.Combine(Application.persistentDataPath, fileName);
    }

    // 죽었는지 확인
    private void Update()
    {
        if(!GameManager.Instance.isGameOver)
        {
            return;
        }
        On_InputName();
    }

    // 게임 종료 후 이름을 입력할 UI 활성화
    public void On_InputName()
    {
        score = GameManager.Instance.SCORE;
        inputName_UI.SetActive(true);
        pleaseRetry_txt.SetActive(false);
    }

    // 이름 입력 후 랭킹 활성화
    public void On_Ranking()
    {
        // string으로 변환
        string name = inputName_InputField.text;
        string new_score = score.ToString();

        // 3글자인지 확인
        if ( 1 > name.Length || name.Length > 3)
        {
            StopCoroutine(OnErrorMessage());
            StartCoroutine(OnErrorMessage());
            return;
        }

        // UI 변경
        inputName_UI.SetActive(false);
        ranking_UI.SetActive(true);

        Ranking ranking = new Ranking
        {
            name = name,
            score = new_score
        };

        M_input_ranking_jaon(ranking);
    }

    // 씬으로 돌아가기
    public void SceneLoader(string Scenename)
    {
        SceneManager.LoadScene(Scenename, LoadSceneMode.Single);
    }

    // 에러 메세지 띄우기
    IEnumerator OnErrorMessage()
    {
        pleaseRetry_txt.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        pleaseRetry_txt.SetActive(false);
    }

    // 랭킹 저장
    public void M_input_ranking_jaon(Ranking ranking)
    {
        // Json에 new 기록 정렬 및 저장
        string json = JsonConvert.SerializeObject(ranking);
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
        }
        string exist_json = File.ReadAllText(path);
        List<Ranking> exist_ranking = JsonConvert.DeserializeObject<List<Ranking>>(exist_json);                     // 정보를 Json 객체로 변환
        IEnumerable<Ranking> combine_ranking = exist_ranking.Concat(new[] { ranking });                             // 두 Json 객체를 합침.
        IEnumerable<Ranking> sorted_ranking = combine_ranking.OrderByDescending(n => double.Parse(n.score));        // 정렬
        string new_json = JsonConvert.SerializeObject(sorted_ranking);                                              // 새 Json 저장
        File.WriteAllText(path, new_json);                                                                     // Json에 덮어쓰기

        // Json에 저장된 기록 top9 출력
        List<Ranking> ranking_list = JsonConvert.DeserializeObject<List<Ranking>>(new_json);
        List<Ranking> top9_ranks = new List<Ranking>();
        for (int i = 0; i < 9 && i < ranking_list.Count; i++)
        {
            top9_ranks.Add(ranking_list[i]);
        }

        ranking_text.text = "순위표\n";
        for (int i = 0; i < 9 && i < ranking_list.Count; i++)
        {
            ranking_text.text += (i+1) + ".  " + top9_ranks[i].name + " : " + top9_ranks[i].score + "\n"; 
        }

    }
}


