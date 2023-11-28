using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private TMP_Text scoreText;
    private int score = 0;

    [SerializeField] private TMP_Text mon;
    [SerializeField] private TMP_Text res;
    [SerializeField] private Money money;

    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();
        scoreText.text = score.ToString();
    }

    public void AddScore(int count)
    {
        score += count;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateMoney()
    {
        mon.text = money.GetMoneyCount().ToString();
    }
    
    public void UpdateResources()
    {
        res.text = money.GetResourcesCount().ToString();
    }
}
