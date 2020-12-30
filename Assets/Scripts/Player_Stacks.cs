using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stacks : MonoBehaviour
{
    private Stack stack = new Stack();
    private Vector3 offset = new Vector3(0, -0.5f, 0);
    private Vector3 stackedScale = new Vector3(1, 0.5f, 1);

    public void AddToStack(GameObject go)
    {
        if(stack.Count == 0)
        {
            go.transform.localScale = stackedScale;
            go.transform.localPosition = offset;
        }
        else
        {
            GameObject topStack = (GameObject)stack.Peek();
            go.transform.localScale = stackedScale;
            go.transform.position = topStack.transform.position + offset;
        }

        stack.Push(go);
    }

    public void RemoveFromStack()
    {
        stack.Pop();
    }
    
}
