﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float speed = 10;
    public float gravity = 10;
    public float maxVelocityChange = 10; 
    public float jumpHeight = 2;
    public int Points = 0;
    private bool grounded;

      
    private bool dead; //a true or false call
    public int health;     
    private Transform PlayerTransform;
    private Rigidbody _rigidbody;

   
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.freezeRotation = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerTransform.Rotate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime  , 0);

        Vector3 targetVelocity = new Vector3(0,0,Input.GetAxis("Vertical"));
        targetVelocity = PlayerTransform.TransformDirection(targetVelocity);
        targetVelocity = targetVelocity * speed; 

        Vector3 velocity = _rigidbody.velocity;
        Vector3 velocityChange = targetVelocity - velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
        
        if(Input.GetButton("Jump") && grounded == true){
            _rigidbody.velocity = new Vector3(velocity.x, CalculateJump(),velocity.z); 
    
        }
        _rigidbody.AddForce(new Vector3(0, -gravity * _rigidbody.mass, 0));
        
        grounded = false;

        
    }
    void Update()
    {
        if (health < 1){
            Application.LoadLevel("Test");
        }
    }

    float CalculateJump(){
        float Jump = Mathf.Sqrt(2*jumpHeight*gravity);

        return Jump;
    }

    void OnCollisionStay(){
        grounded = true;

    }

    void OnTriggerEnter(Collider Buddy){
        if(Buddy.tag == "Coin")
        {
            Points = Points + 5;
            Destroy(Buddy.gameObject);
        }
    }
}
