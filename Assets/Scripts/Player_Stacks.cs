using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stacks : MonoBehaviour
{
    [Header("Stack Attributes")]
    private Stack stack = new Stack();
    private Vector3 firstOffset = new Vector3(0, -0.5f, 0);
    private Vector3 secondOffset = new Vector3(0, -1f, 0);
    private Vector3 stackedScale = new Vector3(1, 0.5f, 1);
    public float stackAmount = 0;

    public void AddToStack(GameObject go)
    {
        if(stack.Count == 0)
        {
            go.transform.localScale = stackedScale;
            go.transform.localPosition = firstOffset;
        }
        else
        {
            GameObject topStack = (GameObject)stack.Peek();
            go.transform.localScale = stackedScale;
            go.transform.position = topStack.transform.position + secondOffset;
        }

        stack.Push(go);
        stackAmount++;
    }

    public void RemoveFromStack()
    {
        if(stack.Count>0)
        stack.Pop();
    }
    
}
