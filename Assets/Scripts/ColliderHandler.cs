using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderHandler : MonoBehaviour
{
    [SerializeField] GameObject Bang;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<PlayerControl>().enabled = false;
        GameObject Banging = Instantiate(Bang,transform.position,Quaternion.identity);
        Invoke("ReloadScene", 1f);
    }

    void ReloadScene()
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneIndex);
    }
}
