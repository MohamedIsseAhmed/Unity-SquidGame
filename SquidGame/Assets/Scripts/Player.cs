using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour,IDamagable
{
    public static event Action GameOverEven;

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] float health;

    private float delayEvent = 1f;
    private float delayPlayerDeath = 2f;
    private float magnitude;
    

    bool isDead;
    public Rigidbody rigidbody;

    private Vector3 velocity;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        TakeInPut();

    }

  

    private void FixedUpdate()
    {
        Move();
    }
    private void TakeInPut()
    {
        Vector3 movemenyVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        velocity = movemenyVector;
    }
    private void Move()
    {
        if (!Enmey.CanMove) return;
        if (isDead) return;
        rigidbody.MovePosition(rigidbody.position + (velocity * speed * Time.deltaTime));
    }

    public  void TakeDamage()
    {
        health--;
        print("player health" + health);
        if (health <= 0)
        {
            print("Destroy player");
            isDead = true;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            transform.eulerAngles = Vector3.right * 90;
            Destroy(this.gameObject,delayPlayerDeath);

            Invoke("Delay", delayEvent);
            
        }
    }
    void Delay()
    {
        GameOverEven?.Invoke();
    }

}
