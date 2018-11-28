using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float startHealth;
    public Transform projectileSpawnPosition;
    public ProjectileToPrefabMapping[] projectileToPrefabMap;

    private Dictionary<ProjectileType, GameObject> projectileToPrefabLookup;
    private bool isDeath = false;
    private float currentHealth;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentHealth = startHealth;
        projectileToPrefabLookup = new Dictionary<ProjectileType, GameObject>();
        foreach (var mapping in projectileToPrefabMap)
        {
            projectileToPrefabLookup.Add(mapping.projectileType, mapping.projectilePrefab);
        }
    }

    public void Shoot(ProjectileType projectileType)
    {
        if (!isDeath)
        {
            GameObject projectToShoot = projectileToPrefabLookup[projectileType];

            Instantiate(projectToShoot, projectileSpawnPosition.position, Quaternion.identity);
        }     
    }

    public void Hit()
    {
        currentHealth--;
        if (currentHealth <= 0)
            Die();
        else
            animator.SetTrigger("Hit");
    }

    private void Die()
    {
        isDeath = true;
        animator.SetBool("IsDead", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Enemy" && !isDeath)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Die();
            Hit();
        }
            
    }

    [System.Serializable]
    public class ProjectileToPrefabMapping
    {
        public ProjectileType projectileType;
        public GameObject projectilePrefab;
    }

}

public enum ProjectileType
{
    Circle,
    Square,
    Triangle
}