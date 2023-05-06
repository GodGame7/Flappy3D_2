using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region �̱��� ����
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                }
                DontDestroyOnLoad(_instance.gameObject);
            }
            else if (_instance != FindObjectOfType<GameManager>())
            {
                Destroy(FindObjectOfType<GameManager>().gameObject);
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        isStart = false;
        isGameOver = false;
        isBooster = false;
    }

    // ��ŸƮ������ �� true, ���� �� false
    public bool isStart;

    // UIƮ����
    // ���� �� true, ���ӿ���UI���� false�� ��ȯ
    public bool isGameOver;
    public bool isBooster;

    // ���ھ� ����
    [SerializeField] private int score;
    [SerializeField] private Text score_txt;
    public int SCORE { get; private set; }
    public void AddScore()
    {
        if (score_txt == null)
        {
            score = 0;
            GameObject scoreTextObject = GameObject.Find("Canvas/Score_txt");
            if (scoreTextObject != null)
            {
                score_txt = scoreTextObject.GetComponent<Text>();
            }
        }
        if (!isGameOver)
        {
            score++;
            SCORE = score;
            score_txt.text = "Score : " + score;
        }
    }





}