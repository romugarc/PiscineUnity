using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 move;
    private GameObject thomasObj;
    private GameObject johnObj;
    private GameObject claireObj;
    private Rigidbody thomasBody;
    private Rigidbody johnBody;
    private Rigidbody claireBody;
    public float speed = 5f;
    public float ySpeed = 0f;

    public bool thomasActive = false;
    public bool johnActive = false;
    public bool claireActive = false;

    // Start is called before the first frame update
    void Start()
    {
        thomasObj = GameObject.Find("Thomas");
        thomasBody = thomasObj.GetComponent<Rigidbody>();
        johnObj = GameObject.Find("John");
        johnBody = johnObj.GetComponent<Rigidbody>();
        claireObj = GameObject.Find("Claire");
        claireBody = claireObj.GetComponent<Rigidbody>();
        // johnController.Disable;
        // claireController.Disable;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            thomasActive = true;
            johnActive = true;
            claireActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            thomasActive = false;
            johnActive = true;
            claireActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            thomasActive = false;
            johnActive = false;
            claireActive = true;
        }

        if (thomasActive == true || johnActive == true || claireActive == true)
            move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (thomasActive == true)
        {
            Vector3 thomasVector = thomasObj.transform.TransformDirection(move) * speed;
            thomasBody.velocity = new Vector3(move.x, thomasBody.velocity.y, move.z);

            if (Input.GetKeyDown(KeyCode.Space) && thomasBody.velocity.y == 0)
            {
                thomasBody.AddForce(Vector3.up, ForceMode.Impulse);
            }
        }
        else if (johnActive == true)
        {
            Vector3 johnVector = johnObj.transform.TransformDirection(move) * speed;
            johnBody.velocity = new Vector3(move.x * 1.5f, johnBody.velocity.y, move.z);

            if (Input.GetKeyDown(KeyCode.Space) && johnBody.velocity.y == 0)
            {
                johnBody.AddForce(Vector3.up * 1.5f, ForceMode.Impulse);
            }
        }
        else if (claireActive == true)
        {
            Vector3 claireVector = claireObj.transform.TransformDirection(move) * speed * 0.5f;
            claireBody.velocity = new Vector3(move.x * 0.5f, claireBody.velocity.y, move.z);

            if (Input.GetKeyDown(KeyCode.Space) && claireBody.velocity.y == 0)
            {
                claireBody.AddForce(Vector3.up * 0.5f, ForceMode.Impulse);
            }
        }

        // if (thomasActive == true)
        // {
        //     // Vector3 thomasMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        
        //     // ySpeed += Physics.gravity.y * Time.fixedDeltaTime;

        //     // if (ySpeed < -10f)
        //     // {
        //     //     ySpeed = -10f;
        //     // }
        //     // if (thomasController.isGrounded)
        //     // {
        //     //     ySpeed = -0.5f;
        //     //     if (Input.GetButtonDown("Jump"))
        //     //     {
        //     //         ySpeed = jumpSpeed;
        //     //     }
        //     // }

        //     // thomasMove.y = ySpeed;

        //     // thomasController.Move(thomasMove * Time.fixedDeltaTime * speed);
        // }
    }
}
