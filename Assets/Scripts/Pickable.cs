using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [Header("Inits")]
    private Player_Stacks stacks;
    private GameManager gm;
    private Animator anim;
    [SerializeField] private MeshFilter currMesh;
    [SerializeField] private BoxCollider coll;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject pickupFX;
    

    [Header("Pickable  Atributes")]
    private bool isStacked = false;
    [SerializeField] private Mesh stackedMesh;


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindObjectOfType<GameManager>();
        gm.gameLost += DropBox;
        gm.gameWon += DropBox;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isStacked == false)
        {
            stacks = other.GetComponent<Player_Stacks>();
            currMesh.mesh = stackedMesh;
            coll.size = Vector3.one;
            anim.enabled = false;
            Instantiate(pickupFX,transform.position, Quaternion.identity); 
            transform.SetParent(other.transform, false);
            stacks.AddToStack(gameObject);
            isStacked = true;
            coll.isTrigger = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && isStacked)
        {
            transform.SetParent(null);
            DropBox();
            stacks.RemoveFromStack();
        }
    }

    private void DropBox()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
    }

}
