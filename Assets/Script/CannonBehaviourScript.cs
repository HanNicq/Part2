using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{

    public AudioClip cannonShoot;
    public ParticleSystem smoke;
    public GameObject ui;

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
            ShowUI();

        }
    }

    public void ShootCannon()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(cannonShoot);

        smoke.Play();
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

    public void PressYes()
    {
        HideUI() ;
        ShootCannon();
    }

    public void PressNo()
    {
        HideUI();
    }
}
