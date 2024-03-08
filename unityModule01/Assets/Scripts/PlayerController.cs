using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 move;
    private GameObject thomasObj;
    private GameObject johnObj;
    private GameObject claireObj;
    private GameObject currentObj;
    private Camera currCamera;
    private Rigidbody currentBody;
    public float speed;
    public float jumpspeed;
    public float ySpeed = 0f;

    public bool thomasActive = false;
    public bool johnActive = false;
    public bool claireActive = false;
    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        currCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        thomasObj = GameObject.Find("Thomas");
        johnObj = GameObject.Find("John");
        claireObj = GameObject.Find("Claire");
        thomasActive = false;
        johnActive = false;
        claireActive = false;
        isGrounded = true;
        speed = 0f;
        jumpspeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            thomasActive = true;
            johnActive = false;
            claireActive = false;
            currentBody = thomasObj.GetComponent<Rigidbody>();
            currentObj = thomasObj;
            speed = 20f;
            jumpspeed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            thomasActive = false;
            johnActive = true;
            claireActive = false;
            currentBody = johnObj.GetComponent<Rigidbody>();
            currentObj = johnObj;
            speed = 25f;
            jumpspeed = 7f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            thomasActive = false;
            johnActive = false;
            claireActive = true;
            currentBody = claireObj.GetComponent<Rigidbody>();
            currentObj = claireObj;
            speed = 15f;
            jumpspeed = 3f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (thomasActive == true || johnActive == true || claireActive == true)
        {
            currCamera.transform.position = new Vector3(currentBody.transform.position.x, currentBody.transform.position.y, currCamera.transform.position.z);
            string currentName = currentBody.name;
            if (currentName == gameObject.name)
            {
                float horizontal = currentBody.velocity.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                if (horizontal > speed * 0.1f)
                    horizontal = speed * 0.1f;
                else if (horizontal < speed * -0.1f)
                    horizontal = speed * -0.1f;
                currentBody.velocity = new Vector3(horizontal, currentBody.velocity.y, 0f);
                if (isGrounded == true)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        currentBody.velocity += new Vector3(0f, jumpspeed, 0f);
                        isGrounded = false;
                    }
                }
            }
        }
    }

    void OnCollisionStay(Collision collider)
    {
        //Debug.Log("Stay");
        if (thomasActive == true || johnActive == true || claireActive == true)
        {
            ContactPoint[] contacts =  collider.contacts;
            string currName = currentObj.name;
            if (currName == gameObject.name)
            {
                foreach(ContactPoint contact in contacts)
                {
                    Vector3 normals = contact.normal.normalized;
                    Debug.DrawRay(contact.point, contact.normal * 1000, Color.red);
                    if (normals == Vector3.up)
                        isGrounded = true;
                }
            }
        }
    }
    void OnCollisionExit()
    {
        if (currentObj.name == gameObject.name)
        {
            isGrounded = false;
        }
    }
}

