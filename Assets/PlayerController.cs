using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 5f;
    public float jumpSpeed = 3f;
    public float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        ySpeed += Physics.gravity.y * Time.fixedDeltaTime;

        if (ySpeed < -10f)
        {
            ySpeed = -10f;
        }
        if (characterController.isGrounded)
        {
            ySpeed = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }

        move.y = -ySpeed;

        //Debug.Log(characterController.transform.position);
        characterController.Move(move * Time.fixedDeltaTime * -speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game Over");
        Destroy(this.gameObject);
    }
}
