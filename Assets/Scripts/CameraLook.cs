using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    Vector2 smoothV;

    public float sensibilidad = 5f;
    public float smooth = 2f;
    GameObject player;

    private float rotationX = 0f;
    private float rotationY = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));


        md = Vector2.Scale(md, new Vector2(sensibilidad * smooth, sensibilidad * smooth));


        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f/smooth);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f/smooth);


        rotationX -= smoothV.y;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);


        rotationY += smoothV.x;

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        player.transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
