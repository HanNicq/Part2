using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("dance", true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("dance", false);
        }
    }
}
