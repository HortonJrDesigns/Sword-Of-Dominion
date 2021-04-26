using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClinicControler : MonoBehaviour {

    public GameObject clinicPanel;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        OpenClinic ();
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        CloseClinic ();
    }
    
    void OpenClinic()
    {
        clinicPanel.SetActive (true);
        // Time.timeScale = 0;
    }
    
    public void CloseClinic()
    {
        clinicPanel.SetActive (false);
        //  Time.timeScale = 1;
    }
}
