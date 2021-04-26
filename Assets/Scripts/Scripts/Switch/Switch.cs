using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject DeactivatedPanel;
    
    public bool IsActivated = true;
    public bool IsDeactivated = false;
    
    public GameObject choice1;  //
    public GameObject choice2;  //
    
    void Start()
    {
        
        
        choice1 = FindObjectOfType<GameObject>();  // gets access to the p1 game object
        choice2 = FindObjectOfType<GameObject>();  // gets access to the p2 game object
        
        
      if  (IsActivated = true)
        {
            choice1.gameObject.SetActive(true);
            choice2.gameObject.SetActive(false);
            
            IsDeactivated = false;
            IsActivated = true;
            
        }
        
        else
        {
            IsActivated = false;
            
        }
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            choice1.gameObject.SetActive(false);
            choice2.gameObject.SetActive(true);
            
            IsDeactivated = true;
            IsActivated = false;
            
            OpenMessage();
            
        }
    
    }
    void OnTriggerExit(Collider other)
    {
      if(other.CompareTag("Player"))
      CloseMessage();
    }
    
    void OpenMessage()
    {
        DeactivatedPanel.SetActive (true);
        // Time.timeScale = 0;
    }
    
    public void CloseMessage()
    {
       DeactivatedPanel.SetActive (false);
        //  Time.timeScale = 1;
    }
    
    
    
 //   void Update()
  //  {
  //      if  (IsDeactivated = true)
   //    {
   //       choice1.gameObject.SetActive(false);
   //        choice2.gameObject.SetActive(true);
   //
    //       IsDeactivated = true;
    //       IsActivated = false;
    //   }
    //
    //   else
    //   {
    //       IsActivated = false;
     //      IsDeactivated = true;
     //
     //  }
 //   }
}
