using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]

    private float force = 5;
    public Rigidbody2D rb;
    [SerializeField]

    private float maxSpeed = 4;

    private float elapsedTime = 0f;

    private UIDocument uiDoc;
    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;


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
            rb.AddForce(dir * force);
            if(rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
