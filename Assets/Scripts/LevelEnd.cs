using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [Header("Inits")]
    private GameManager gm;
    private Player_Stacks stacks;
    private Camera cam;
    [SerializeField] private Animator EndingAnimation;

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        gm.gameWon += InitEnding;
        stacks = GameObject.FindObjectOfType<Player_Stacks>();
        cam = Camera.main;
    }

    private void InitEnding()
    {
        int currStacks = stacks.GetCurrenStacks();
        
        if(currStacks ==0)
            EndingAnimation.SetInteger("MultiplyAmount", 0);

        if (currStacks >= 3 && currStacks < 5)
            EndingAnimation.SetInteger("MultiplyAmount", 10);


        if (currStacks >= 5 && currStacks < 7)
        {
            EndingAnimation.SetInteger("MultiplyAmount", 20);
            return;
        }

        if (currStacks >= 7 && currStacks < 9)
        {
            EndingAnimation.SetInteger("MultiplyAmount", 30);
            return;
        }

        if (currStacks >= 9 && currStacks < 11)
        {
            EndingAnimation.SetInteger("MultiplyAmount", 40);
            return;
        }

        if (currStacks >= 11)
        {
            EndingAnimation.SetInteger("MultiplyAmount", 50);
            return;
        }

    }
}
