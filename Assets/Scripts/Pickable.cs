using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private bool isStacked = false;
    private Player_Stacks stacks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isStacked == false)
        {
            stacks = other.GetComponent<Player_Stacks>();
            transform.position = Vector3.zero;
            transform.SetParent(other.transform, false);
            stacks.AddToStack(gameObject);
            isStacked = true;
        }
        else if (other.gameObject.tag == "Obstacle" && isStacked)
        {
            transform.SetParent(null);
            stacks.RemoveFromStack();
        }
    }

}
