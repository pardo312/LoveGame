using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Aceleracion del personaje
    [SerializeField,Range(2f, 4f)]private float aceleracion = 1f;
    [SerializeField] private Animator walkingAnimation;
    [SerializeField] private Sprite spriteUp;
    [SerializeField] private Sprite spriteDown;
    [SerializeField]public Vector2 velocidad= Vector2.zero;

    //Rigibody del objeto
    private Rigidbody2D rb;

    //Determina direccion horizontal que tiene el personaje
    private bool facingLeft = true;
    //Arreglo que guarda la velocidad horizontal y vertical, en ese orden.

    // Start is called before the first frame update
    void Start()
    {
        transform.position = ApplicationModel.posicionDelJugador;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ApplicationModel.playerCanMove){
            playerMovementDirection();
            //Actualiza la posicion basado en la velocidad actual
            rb.velocity= new Vector3(velocidad[0],velocidad[1],0)*200;
            if (this.gameObject.GetComponent<Rigidbody2D>().IsSleeping() ) {
                this.gameObject.GetComponent<Rigidbody2D>().WakeUp();
            }
        }
        
    }
    void playerMovementDirection()
    {
        if(Input.GetAxis("Horizontal") != 0){
            walkingAnimation.SetBool("walkingHorizontal",true);
            if(Input.GetAxis("Horizontal") >0){
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                facingLeft =false;
                velocidad[0] = aceleracion*Time.deltaTime;
            }
            else{
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                facingLeft =true;
                velocidad[0] = -aceleracion*Time.deltaTime;
            }
        }
        else{
            walkingAnimation.SetBool("walkingHorizontal",false);
            velocidad[0] = 0;
        }
        if(Input.GetAxis("Vertical") != 0){
            if(Input.GetAxis("Vertical") >0){
                walkingAnimation.SetBool("walkingUp",true);
                velocidad[1] = aceleracion*Time.deltaTime;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteUp;
            }
            else{
                walkingAnimation.SetBool("walkingDown",true);
                velocidad[1] = -aceleracion*Time.deltaTime;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteDown;
            }
        }
        else{
            walkingAnimation.SetBool("walkingUp",false);
            walkingAnimation.SetBool("walkingDown",false);
            velocidad[1] = 0;
        }
    }
}
