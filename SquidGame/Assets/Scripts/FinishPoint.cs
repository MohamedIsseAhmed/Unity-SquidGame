using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] Win win;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("killable"))
        {
            SceneManager.LoadScene(2);
            win.winnerName.text="Winner is "+other.transform.parent.name;
        }
    }
}
