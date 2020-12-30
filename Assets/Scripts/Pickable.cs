using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private bool isStacked = false;
    private Player_Stacks stacks;
    [SerializeField] private Mesh stackedMesh;
    private MeshFilter currMesh;
    private BoxCollider coll;
    private Animator anim;

    private void Start()
    {
        currMesh = gameObject.GetComponent<MeshFilter>();
        coll = gameObject.GetComponent<BoxCollider>();
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isStacked == false)
        {
            stacks = other.GetComponent<Player_Stacks>();
            currMesh.mesh = stackedMesh;
            coll.size = Vector3.one;
            anim.enabled = false;
            //*** instantiate picking up particle effect 
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
