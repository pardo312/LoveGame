using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionButton : MonoBehaviour
{
    [SerializeField] private GameObject dialogo;
    [SerializeField]private string[] newSentences;
    [SerializeField]private GameObject buttonNext;
    private int enableTriggerTimer = 50;
     void Update()
     {
         if(ApplicationModel.startDialog)
         {
             if(enableTriggerTimer<50)
             {
                enableTriggerTimer++;
             }
         }
        if(Input.GetButton("Jump") && buttonNext.active ){
            dialogo.GetComponent<dialogo>().NextSentece();
        }
     }
     void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag =="Player"){
            if(Input.GetButton("Jump") && enableTriggerTimer==50){
                enableTriggerTimer=0;
                dialogo.GetComponent<dialogo>().sentences = newSentences;
                dialogo.SetActive(true);
            }
        }
    }

}
