using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Events
    public delegate void GameWon();
    public event GameWon gameWon;

    public delegate void GameLost();
    public event GameLost gameLost;
    #endregion

    public void GameWonInvoke()
    {
        gameWon?.Invoke();
    }
    public void GameLostInvoke()
    {
        gameLost?.Invoke();
    }
}
