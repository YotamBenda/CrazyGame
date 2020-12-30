using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stacks : MonoBehaviour
{
    private Stack stack = new Stack();
    private Vector3 offset = new Vector3(0, -0.5f, 0);

    public void AddToStack(GameObject go)
    {
        if(stack.Count == 0)
        {
            go.transform.localPosition = offset;
        }
        else
        {
            GameObject topStack = (GameObject)stack.Peek();
            go.transform.position = topStack.transform.position + offset;
        }

        stack.Push(go);
    }

    public void RemoveFromStack()
    {
        stack.Pop();
    }
    
}
