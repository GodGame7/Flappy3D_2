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
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
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
        if (!isGameOver)
        { 
            score++;
            SCORE = score;
            score_txt.text = "Score : " + score;
        }
    }





}