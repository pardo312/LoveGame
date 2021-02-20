using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Aceleracion del personaje
    [SerializeField,Range(2f, 4f)]private float aceleracion = 1f;
    [SerializeField] private bool isCurrentPlayer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField]public Vector2 velocidad= Vector2.zero;
    private Animator walkingAnimation;
    private Rigidbody2D rb;

    //Determina direccion horizontal que tiene el personaje
    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        if(isCurrentPlayer)
            transform.position = ApplicationModel.posicionDelJugador;
        
        TryGetComponent<Rigidbody2D>(out rb);
        walkingAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ApplicationModel.playerCanMove){
            playerMovementDirection();
            //Actualiza la posicion basado en la velocidad actual
            if(rb!=null){
                rb.velocity= new Vector3(velocidad[0],velocidad[1],0)*200;
                //Fix colliders not working properlly
                if (rb.IsSleeping() ) {
                    rb.WakeUp();
                }
            }
        }
        
    }
    void playerMovementDirection()
    {
        moveHorizontal();
        moveVertical();
    }

    void moveHorizontal(){
        if(Input.GetAxis("Horizontal") != 0){
            walkingAnimation.SetBool("walkingHorizontal",true);

            //Walking Right
            if(Input.GetAxis("Horizontal") >0){
                transform.rotation = Quaternion.Euler(0, 180, 0);
                facingLeft =false;
                if(isCurrentPlayer){
                    velocidad[0] = aceleracion*Time.deltaTime;
                }
                else{
                    transform.localPosition = new Vector3(2,-0.4f,1);
                }
            }
            //Walking Left
            else{
                transform.rotation = Quaternion.Euler(0, 0, 0);
                facingLeft =true;
                if(isCurrentPlayer){
                    velocidad[0] = -aceleracion*Time.deltaTime;
                }
                else{
                    transform.localPosition =  new Vector3(2,-0.4f,1);
                }
            }
        }
        else{
            walkingAnimation.SetBool("walkingHorizontal",false);
            velocidad[0] = 0;
        }
    }
    void moveVertical(){
        if(Input.GetAxis("Vertical") != 0){

            
            if(Input.GetAxis("Vertical") >0){
                walkingAnimation.SetBool("walkingUp",true);
                if(isCurrentPlayer){
                    velocidad[1] = aceleracion*Time.deltaTime;
                }
                else{
                    transform.localPosition = -1 * new Vector3(0,2,1);
                    GetComponent<SpriteRenderer>().sortingOrder = 2;
                }
            }
            else{
                
                walkingAnimation.SetBool("walkingDown",true);
                if(isCurrentPlayer){
                    velocidad[1] = -aceleracion*Time.deltaTime;
                }
                else{
                    transform.localPosition =  new Vector3(0,2,1);
                    GetComponent<SpriteRenderer>().sortingOrder = 0;
                }
            }
        }
        else{
            walkingAnimation.SetBool("walkingUp",false);
            walkingAnimation.SetBool("walkingDown",false);
            velocidad[1] = 0;
        }
    }


}
