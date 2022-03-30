using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBodyController  : MonoBehaviour
{
   
    Transform playerBody;
    CharacterController contr;
    public float speed = 12f;
    bool isGrounded = false;
    float jumpHeight = 5f;
    static int money = 0;
    [SerializeField] TextMeshProUGUI moneyText;
    void Start()
    {
        playerBody = GetComponent<Transform>();
        contr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 2;
        float vertical = Input.GetAxis("Vertical");
        float gravityValue = -9.81f;

        contr.Move(playerBody.forward * vertical * speed * Time.deltaTime);
        contr.Move(playerBody.up * gravityValue * Time.deltaTime);

        playerBody.Rotate(0,mouseX,0);
        if (Input.GetKeyDown("space") && isGrounded == true){
        
            contr.Move(playerBody.up * jumpHeight);
        }

        isGrounded = false;
    }

    void OnControllerColliderHit(ControllerColliderHit  col){
        if(col.gameObject.tag == "ground"){
            isGrounded = true;
        }

        if (col.gameObject.tag == "Coin")
        {
            money = money + 1;
            moneyText.text = money + "";
            Destroy(col.gameObject);
        }
    }
}
