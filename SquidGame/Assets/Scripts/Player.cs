using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamagable
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private float magnitude;


    public Rigidbody rigidbody;

    private Vector3 velocity;
    float angle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movemenyVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        magnitude = movemenyVector.magnitude;
        float inputAngle = Mathf.Atan2(movemenyVector.x, movemenyVector.z) * Mathf.Rad2Deg;
        velocity = movemenyVector;
        angle = Mathf.LerpAngle(angle, inputAngle, turnSpeed * Time.deltaTime * magnitude);
        transform.eulerAngles = Vector3.up * angle;
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + (velocity * speed * Time.deltaTime));
    }

    public void TakeDamage(RaycastHit raycastHit,Transform transform)
    {
        throw new System.NotImplementedException();
    }
}
