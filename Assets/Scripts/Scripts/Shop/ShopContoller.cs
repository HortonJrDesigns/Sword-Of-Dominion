using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContoller : MonoBehaviour {
    public GameObject shopPanel;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        OpenShop ();
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        CloseShop ();
    }
    
    void OpenShop()
    {
        shopPanel.SetActive (true);
       // Time.timeScale = 0;
    }
    
    public void CloseShop()
    {
        shopPanel.SetActive (false);
      //  Time.timeScale = 1;
    }
}
