﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Manager : MonoBehaviour
{

    [Header("Inits")]
    private Player_Stacks stacks;
    private GameManager gameManager;

    [Header("Game Status")]
    public static bool gameOver = false;
    public static bool gameWon = false;

    [Header("Menus")]
    [SerializeField] private GameObject overlay;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject pauseMenu;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI totalAmount;
    [SerializeField] private Button pauseMenuButton;

    private void Awake()
    {
        gameOver = false;
        gameWon = false;
    }

    private void Start()
    {
        stacks = GameObject.FindObjectOfType<Player_Stacks>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.gameWon += GameWon;
        gameManager.gameLost += GameLost;

    }

    private void Update()
    {
        totalAmount.text = stacks.stackAmount.ToString();
    }

    private void GameWon()
    {
        overlay.SetActive(false);
        totalAmount.enabled = false;
        winMenu.SetActive(true);
    }
    private void GameLost()
    {
        overlay.SetActive(false);
        totalAmount.enabled = false;
        loseMenu.SetActive(true);
    }

    public void Pause()
    {
        overlay.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        overlay.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
