using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Events
    public delegate void GameWon();
    public event GameWon gameWon;

    public delegate void GameWonUI();
    public event GameWonUI gameWonUI;

    public delegate void GameLost();
    public event GameLost gameLost;
    #endregion

    [Header("UI Timing")]
    private bool shouldCount = false;
    private float animTime;
    private float timer;

    public void GameWonInvoke()
    {
        gameWon?.Invoke();
    }
    public void GameLostInvoke()
    {
        gameLost?.Invoke();
    }

    public void GameWonUIInvoke()
    {
        gameWonUI?.Invoke();
    }
}
