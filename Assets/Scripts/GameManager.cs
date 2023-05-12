using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject singleton = new GameObject(typeof(GameManager).Name);
                    instance = singleton.AddComponent<GameManager>();
                    DontDestroyOnLoad(singleton);
                }
            }

            return instance;
        }
    }

    public enum PlayerType { One, Two }
    private Dictionary<PlayerType, int> pointsDictionary;
    public List<TextMeshProUGUI> scoreTexts;



    private void Start()
    {
        ClearTexts();


        pointsDictionary = new Dictionary<PlayerType, int>();
        pointsDictionary.Add(PlayerType.One, 0);
        pointsDictionary.Add(PlayerType.Two, 0);
    }

    public void AddPlayerPoints(PlayerType player, int amount)
    {
        pointsDictionary[player] += amount;
        UpdateScoreText(player, pointsDictionary[player]);
    }

    private void UpdateScoreText(PlayerType player, int newScore)
    {
        scoreTexts[(int)player].text = newScore.ToString();
    }

    private void ClearTexts()
    {
        foreach (var element in scoreTexts)
        {
            element.text = 0.ToString();
        }
    }
}
