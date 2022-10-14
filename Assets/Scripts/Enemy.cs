using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject DeathVFX;
    [SerializeField] private GameObject HitVFX;
    GameObject ParentObject;
    ScoreBoard Score;
    int Heal = 6;
    int Point = 30;
    private void Start()
    {
        ParentObject = GameObject.FindGameObjectWithTag("SpawnObject");
        Score = FindObjectOfType<ScoreBoard>();
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
    }
    private void OnParticleCollision(GameObject other)
    {
        HitPoint();
       Debug.Log("I am hit by " + other.gameObject.name);
        if (Heal == 0)
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        GameObject VFX = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = ParentObject.transform;
        Destroy(VFX, 3f);
        Destroy(gameObject);
        Score.IncreasedPoint(Point);
    }
    void HitPoint()
    {
        Heal--;
        GameObject VFX = Instantiate(HitVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = ParentObject.transform;
        Destroy(VFX, 3f);
    }
}
