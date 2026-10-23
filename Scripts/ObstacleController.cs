using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private float minSize = 0.3f;

    [SerializeField]
    private float maxSize = 2f;

    [SerializeField]
    private float minForce = 20f;

    [SerializeField]
    private float maxForce = 48f;

    [SerializeField]
    private float minTorque = 20f;

    [SerializeField]
    private float maxTorque = 48f;

    // NUEVO: el prefab del efecto de partículas
    [SerializeField]
    private ParticleSystem impactEffect;

    void Start()
    {
        // Assign a random size to each obstacle object
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size, 1);

        // Get the rigidbody component on our game object
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Transform tf = GetComponent<Transform>();
        Vector2 randomDirection = Random.insideUnitCircle;

        // Generate a random force
        float force = Random.Range(minForce, maxForce);
        rb.AddForce(randomDirection * force);

        // Apply a random torque to each obstacle
        float torque = Random.Range(minTorque, maxTorque);
        rb.AddTorque(-torque);

        Debug.Log(transform == tf);

        rb.mass = size * 2;
    }

    // NUEVO: se ejecuta cuando el obstáculo choca con algo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Punto exacto del choque
        Vector2 impactPoint = collision.contacts[0].point;

        // Crear el efecto en ese punto
        Instantiate(impactEffect, impactPoint, Quaternion.identity);
    }
}   
