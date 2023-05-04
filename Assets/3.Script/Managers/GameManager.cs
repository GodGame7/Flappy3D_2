using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region 싱글턴 선언
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

    // 스타트점프할 때 true, 죽을 떄 false
    public bool isStart; 

    // UI트리거
    // 죽을 때 true, 게임오버UI에서 false로 전환
    public bool isGameOver;
    public bool isBooster;

    // 스코어 관련
    [SerializeField]private int score;
    public int SCORE { get; }
    public void AddScore()
    {
        if (!isGameOver)
        { score++; }
    }
}