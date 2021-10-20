using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmey : MonoBehaviour
{
    [SerializeField] WaitForSeconds timeToWaitInTurning;
    [SerializeField] GameObject enemyHead;
    void Start()
    {
        StartCoroutine(TurnAround());
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(enemyHead.transform.position, -enemyHead.transform.forward*100);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, 1000))
        {
            Debug.Log(raycastHit.collider.name);
            if (raycastHit.collider.CompareTag("killable"))
            {
                print("Kill");
            }
        }
        Debug.DrawRay(enemyHead.transform.position, -enemyHead.transform.forward * 5, Color.red);
    }

    IEnumerator TurnAround()
    {
        Quaternion lookAt = Quaternion.Euler(0, 85, 0);
        Quaternion currentrotation =enemyHead.transform.localRotation;
        while (true)
        {
            yield return new WaitForSeconds(3f);
            enemyHead.transform.localRotation = Quaternion.Slerp(transform.rotation,lookAt , Time.deltaTime);
            yield return new WaitForSeconds(2f);
            enemyHead.transform.rotation = Quaternion.Slerp(lookAt, currentrotation,  Time.deltaTime);
        }
    }

  
}
