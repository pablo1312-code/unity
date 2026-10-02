using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]

    private float force = 5;
    public Rigidbody2D rb;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Mouse.current.leftButton.isPressed)
        {

            //calculate the direction from the player to the mouse
            Debug.Log("The left button is clicked");
            Debug.Log("The current mouse position on the screen is:" + Mouse.current.position.value);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Debug.Log("The world position of the mouse is: " + mousePos);
            Vector2 dir = (mousePos - gameObject.transform.position).normalized;
            Debug.Log("The direction to the mouse is: " + dir.magnitude);
            transform.up = dir;
            rb.AddForce(dir * 10);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
