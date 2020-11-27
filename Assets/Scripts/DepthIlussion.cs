using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthIlussion : MonoBehaviour
{
    [SerializeField] private bool activado;
    [SerializeField] private float limiteSuperior;
    [SerializeField] private float limiteInferior;

    // Update is called once per frame
    void Update()
    {
        if(activado){
            if(GetComponent<playerMovement>().velocidad[1]>0 && transform.position.y<limiteSuperior-0.15f ){
                transform.localScale -= new Vector3(0.0002f,0.0002f,0);
            }
            else if(GetComponent<playerMovement>().velocidad[1]<0 && transform.position.y >  limiteInferior+0.15f  )
            {
                transform.localScale += new Vector3(0.0002f,0.0002f,0);
            }
        }
    }
}
