using System.Collections;
using System.Collections.Generic;
using Es.InkPainter.Sample;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    [SerializeField] float swerveSpeed;
        
    private Transform PlayerPosition;
    
    private Vector3 startPosition;
    private Animator animator;
    public bool stopPlayer=false;

   

    float swerve;

     void Start() {
        PlayerPosition=GetComponent<Transform>();
        startPosition=GetComponent<Transform>().position;
        animator=GetComponent<Animator>();
        Cursor.visible=false;
        
        
    }
    
    void Update (){
        swerve=Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(swerve*swerveSpeed*Time.deltaTime,0,forwardSpeed*Time.deltaTime));
        if(stopPlayer==true){
            Cursor.visible=true;
            forwardSpeed=0;
            swerveSpeed=2;
            animator.SetBool("walk_right",false);
            animator.SetBool("walk_left",false);
            
            if(Input.GetKey(KeyCode.A)){
                animator.SetBool("walk_left",true);
                animator.SetBool("look",false);
            
            }
            if(Input.GetKey(KeyCode.D)){
                animator.SetBool("walk_right",true);
                animator.SetBool("look",false);
            }
            

        }

              
        else{
           
            animator.SetBool("look",false);
            animator.SetBool("walk_right",false);
            animator.SetBool("walk_left",false);
            Cursor.visible=false;
        }
    }

         
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle" )
        {
            PlayerPosition.transform.position= startPosition;
        }

        if(other.gameObject.tag == "PaintWall" ){
            
            stopPlayer=true;

            animator.SetBool("look",true);
            
        }
            
    }

}

     
    


