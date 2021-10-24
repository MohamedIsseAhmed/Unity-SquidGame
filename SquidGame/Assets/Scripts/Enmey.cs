using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enmey : MonoBehaviour
{
    [SerializeField] WaitForSeconds timeToWaitInTurning;
    [SerializeField] GameObject enemyHead;

    private float maxRayDistance = 1000f;
    private float timeBetweenTextShows = 2f;
    private float timeToWaitToReturnBack = 2f;

    public Text redLightText;

    bool angleHasReached;
    public static bool CanMove=true;

    private Animator animator;


   
    void FixedUpdate()
    {
        HeadRotation();
    }

    private void HeadRotation()
    {
        Debug.DrawRay(enemyHead.transform.position, -enemyHead.transform.forward * 5, Color.red);
        if (!angleHasReached)
        {
            float angle = Mathf.MoveTowardsAngle(enemyHead.transform.localEulerAngles.y, 0f, 45 * Time.deltaTime);
            enemyHead.transform.localEulerAngles = Vector3.up * angle;

        }

        if (enemyHead.transform.localEulerAngles.y == 0)
        {

            Invoke("BackToOrigin", 2f);
            angleHasReached = true;
            Ray ray = new Ray(enemyHead.transform.position, -enemyHead.transform.forward * 100);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, maxRayDistance))
            {

                var damagable = raycastHit.collider.GetComponentInParent<IDamagable>();
                if (damagable != null)
                {
                    damagable.TakeDamage();
                }

                if (raycastHit.collider.tag == "killable") ;
                {
                    print(raycastHit.collider.name);

                }
            }
            if (CanMove)
                StartCoroutine(ShowRedLineText());
        }
        if (enemyHead.transform.localEulerAngles.y == 75 || enemyHead.transform.localEulerAngles.y > 60)
        {
            StartCoroutine(BackTo());
        }
    }

    IEnumerator BackTo()
    {
        yield return new WaitForSeconds(timeToWaitToReturnBack);
        float angle = Mathf.MoveTowardsAngle(enemyHead.transform.localEulerAngles.y, 0f, 45 * Time.deltaTime);
        enemyHead.transform.localEulerAngles = Vector3.up * angle;

       
    }
    void BackToOrigin()
    {
        float angle = Mathf.MoveTowardsAngle(enemyHead.transform.localEulerAngles.y, 75, 45 * Time.deltaTime);
        enemyHead.transform.localEulerAngles = Vector3.up * angle;
       
        Ray ray = new Ray(enemyHead.transform.position, -enemyHead.transform.forward * 100);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, maxRayDistance))
        {

            var damagable = raycastHit.collider.GetComponentInParent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage();
            }

            if (raycastHit.collider.tag == "killable") ;
            {
                print(raycastHit.collider.name);

            }
        }
    }
    
    IEnumerator ShowRedLineText()
    {
        yield return new WaitForSeconds(timeBetweenTextShows);
        redLightText.gameObject.SetActive(true);
        CanMove = false;
        yield return new WaitForSeconds(timeBetweenTextShows);
        redLightText.gameObject.SetActive(false);
        CanMove = true;
    }

}
