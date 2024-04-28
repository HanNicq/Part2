using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    public Animator animator;
    public GameObject ui;
    bool chest_open = false;
    public AudioClip Open;
    public AudioClip Close;

    void Start()
    {
        HideUI();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!chest_open)
            {
                ShowUI();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (chest_open)
            {
                CloseChest();
                chest_open = false;
            }
            HideUI();
        }
    }

    public void OpenChest()
    {
        animator.SetTrigger("Open");
        chest_open = true;
        gameObject.GetComponent<AudioSource>().PlayOneShot(Open);
    }

    public void CloseChest()
    {
        animator.SetTrigger("Close");
        chest_open = false;
        gameObject.GetComponent<AudioSource>().PlayOneShot(Close);
    }

    public void PressYes()
    {
        HideUI();
        OpenChest();
    }

    public void PressNo()
    {
        HideUI();
    }

    public void HideUI()
    {
        ui.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowUI()
    {
        ui.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
