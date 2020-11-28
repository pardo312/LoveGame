using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogo : MonoBehaviour
{
    [SerializeField]  TextMeshProUGUI textDisplay;
    [SerializeField]private float typingSpeed;
    [SerializeField]private GameObject container;
    public string[] sentences;
    private int index;
    
    void Update(){
        if(ApplicationModel.startDialog)
        {
            ApplicationModel.startDialog = false;
            ApplicationModel.playerCanMove = false;
            StartCoroutine(Type());
        }
        if(textDisplay.text == sentences[index]){
            container.SetActive(true);
        }
    }
    IEnumerator Type(){
        foreach (char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    

    public void NextSentece(){
        
        container.SetActive(false);
        if(index < sentences.Length-1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else{
            //Cambiar
            GameObject.Find("Daniel").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            textDisplay.text = "";
            container.SetActive(false);
            this.gameObject.SetActive(false);
            index = 0;
            ApplicationModel.startDialog = true;
            ApplicationModel.playerCanMove = true;
        }
    }
}
