using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject messagePanel;
    
    public Switch Button1;
    public Switch Button2;
    
    void Start()
    {
       
    }
    
    void Update()
    {
        if (Button1.IsDeactivated && Button2.IsDeactivated)
        {
            // Open the Door
            Destroy (gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
       OpenDialog ();
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        CloseDialog ();
    }
    
    public void OpenDialog()
    {
        messagePanel.SetActive (true);
        // Time.timeScale = 0;
    }
    
    public void CloseDialog()
    {
        messagePanel.SetActive (false);
        //  Time.timeScale = 1;
    }
}
