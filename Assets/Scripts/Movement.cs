using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Movement : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text winText;

    public float speed = 10.0f;
    private Rigidbody rb;
    private int count;

    private float movementX;
    private float movementY;


    void Start()
    {
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();
        winText.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Puntos:" + count.ToString();
        if(count >= 24)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
