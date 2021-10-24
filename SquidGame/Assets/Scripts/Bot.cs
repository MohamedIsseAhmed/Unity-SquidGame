using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot :MonoBehaviour,IDamagable
{
    private float xRange;
    [SerializeField] float speed;
    [SerializeField] float health;

    private float timeToDesroyBot = 2f;

   
    void Update()
    {
        BotMovement();
    }

    private void BotMovement()
    {
        if (!Enmey.CanMove) return;
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }

    public  void TakeDamage()
    {
        health--;
        print("Bot health"+health);
        if (health <= 0)
        {
            print("Destroy Bot");
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            transform.eulerAngles = Vector3.right * 90;
            Destroy(this.gameObject, timeToDesroyBot);
        }
    }

}
