using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Paddle : MonoBehaviour
{
    public bool Player2=false;
    private float FieldHeight = 2.93f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    Vector3 up = Vector3.up;
    Vector3 down = Vector3.down;


    Vector3 down1 = transform.position;
    Vector3 down2 = down1 + down * 5.0f;

    Vector3 up1 = transform.position;
    Vector3 up2 = up1 + up * 5.0f;


    float dt = Time.deltaTime;
    float speed = 3.0f;

    if ((Input.GetKey(KeyCode.W)&&!Player2)||(Input.GetKey(KeyCode.UpArrow)&&Player2))
    transform.position += Vector3.up * speed * Time.deltaTime;
    
    if ((Input.GetKey(KeyCode.S)&&!Player2)||(Input.GetKey(KeyCode.DownArrow)&&Player2))
    transform.position += Vector3.down * speed * Time.deltaTime;

     transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-FieldHeight,FieldHeight),transform.position.z);
    }
    
   
}
