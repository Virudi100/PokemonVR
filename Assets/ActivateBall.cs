using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBall : MonoBehaviour
{
    private Animator animator;
    private int i = 0;
    private bool isOpen;
    [SerializeField] private GameObject insidePkmPrefab;
    private GameObject pkmOut;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void GrowBall()
    {
        if (i == 0)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            i = 1;
            Debug.Log("Activated");
            animator.SetBool("IsActivated", true);
        }
        else
        {
            UnGrowBall();
            i = 0;
        }
    }

    public void UnGrowBall()
    {
        Debug.Log("Activated");
        animator.SetBool("IsActivated", false);
    }

    public void ReactivateCollider()
    {
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }

    public void TryClose()
    {
        if (isOpen == true)
        {
            animator.SetBool("IsOpen", false);
            animator.SetBool("IsActivated", false);
            isOpen = false;
            Destroy(pkmOut);        //a test
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.transform.localEulerAngles = new Vector3(-90f,90,transform.localEulerAngles.z);
            animator.SetBool("IsOpen", true);
            isOpen = true;

            pkmOut = Instantiate(insidePkmPrefab, transform.position, Quaternion.identity);     //a test

            //Play FX, Instantiate Pokemon

        }
    }
}
