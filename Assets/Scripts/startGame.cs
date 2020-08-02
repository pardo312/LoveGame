using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public Animator transition;
    [SerializeField]private float transtionTime = 5f;

   public void startGameFunction(string initialScene)
   {
       StartCoroutine(LoadLevel(initialScene));
   }
   IEnumerator LoadLevel(string initialScene)
   {
       transition.SetTrigger("Start");
       yield return new WaitForSeconds(transtionTime);
       SceneManager.LoadScene(initialScene, LoadSceneMode.Single);
   }
}
