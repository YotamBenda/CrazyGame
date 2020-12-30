using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Game Status")]
    public static bool gameOver = false;
    public static bool gameWon = false;

    [Header("Menus")]
    [SerializeField] private GameObject overlay;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        gameOver = false;
        gameWon = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            overlay.SetActive(false);
            loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (gameWon)
        {
            overlay.SetActive(false);
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }


}
