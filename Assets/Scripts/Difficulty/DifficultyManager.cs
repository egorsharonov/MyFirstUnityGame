using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;
    [SerializeField] private Slider difficultySlider;
    private int difficulty;
    private void Awake()
    {

        if (instance==null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty", 0);
        difficultySlider.value = difficulty;
    }
    public void onSliderChange()
    {
        difficulty = (int)difficultySlider.value;
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }
    public float GetEnemyHealthByDifficulty()
    {
        switch (difficulty)
        {
            case 0:
                return 80f;
            case 1:
                return 160f;
            case 2:
                return 240f;
        }
        return 0f;
    }
    public float GetEnemyDamageByDifficulty()
    {
        switch (difficulty)
        {
            case 0:
                return 12.5f;
            case 1:
                return 25f;
            case 2:
                return 50f;
        }
        return 0f;
    }
    public float GetTrapDamageByDifficulty()
    {
        switch (difficulty)
        {
            case 0:
                return 80f;
            case 1:
                return 160f;
            case 2:
                return 240f;
        }
        return 0f;
    }

}