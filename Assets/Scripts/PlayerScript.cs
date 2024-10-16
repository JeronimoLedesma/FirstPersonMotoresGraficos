using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Vector2 inputVector;
    public Rigidbody rigidBody;
    bool canJump;
    int collectedItems;
    public TMPro.TextMeshProUGUI scoreText;
    public int totalItems;
    public GameObject goal;

    void Start()
    {
       rigidBody = GetComponent<Rigidbody>();
       canJump = true;
       totalItems = GameObject.FindGameObjectsWithTag("collect").Length;
       goal = GameObject.FindGameObjectWithTag("Goal");
       goal.SetActive(false);
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 moveRelative = transform.TransformDirection(move) * speed * Time.deltaTime;

        rigidBody.MovePosition(rigidBody.position + moveRelative);

        if (Input.GetKeyDown(KeyCode.Space) && canJump) { 

            rigidBody.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            canJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("deathPlane"))
        {
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collect"))
        {
            Destroy(other.gameObject);
            collectedItems++;
            scoreText.text = collectedItems.ToString();
            if (collectedItems == totalItems)
            {
               goal.SetActive(true);
            }
        }
    }
}


