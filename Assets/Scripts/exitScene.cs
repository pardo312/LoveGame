using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitScene : MonoBehaviour
{
    [SerializeField] private string padreScene;
    
    [SerializeField] private Vector3 positionWanted;
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player")
        {
            SceneManager.LoadScene(padreScene);
            ApplicationModel.posicionDelJugador = positionWanted;
        }
    }
}
