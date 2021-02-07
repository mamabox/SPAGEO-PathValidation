using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    
    public float speed = 6.0f;
    public float lookSpeed = 50.0f;

    private Vector3 currentRotation;

    private PathValidation pathValidation;

    // Start is called before the first frame update
    void Start()
    {
        pathValidation = GameObject.Find("Game Manager").GetComponent<PathValidation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int numOfObjects = pathValidation.gameObjetsCollected.Count;

        //Debug.Log("Collision!");
        Debug.Log("Player has collided with " + other.name + " with instance ID " + other.gameObject.GetInstanceID());

        //OPTION 1 - does not record the same intersection twice
        //if (!pathValidation.gameObjetsCollected.Contains(other.gameObject)) 
        //{
        //    pathValidation.gameObjetsCollected.Add(other.gameObject);
        //    Debug.Log("Last object instance ID = " + pathValidation.gameObjetsCollected[pathValidation.gameObjetsCollected.Count - 1].gameObject.GetInstanceID());
        //}

        //OPTION 2 - Does not record the same intersection twice in a row
        if ((numOfObjects == 0) || !pathValidation.gameObjetsCollected[numOfObjects - 1].Equals(other.gameObject))
        {
            pathValidation.gameObjetsCollected.Add(other.gameObject);
            Debug.Log("Last object instance ID = " + pathValidation.gameObjetsCollected[pathValidation.gameObjetsCollected.Count - 1].gameObject.GetInstanceID());
        }

    }

    // Update ist called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        currentRotation.y += horizontalInput * Time.deltaTime * lookSpeed;
        transform.eulerAngles = new Vector3(0, currentRotation.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pathValidation.ValidatePath();
        }
    }
}
