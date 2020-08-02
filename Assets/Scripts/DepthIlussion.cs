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
        if(activado ){
            if(GetComponent<playerMovement>().velocidad[1]>0 && transform.position.y<limiteSuperior ){
                transform.localScale -= new Vector3(0.001f,0.001f,0);
            }
            else if(GetComponent<playerMovement>().velocidad[1]<0 && transform.position.y >  limiteInferior  )
            {
                transform.localScale += new Vector3(0.001f,0.001f,0);
            }
        }
    }
}
