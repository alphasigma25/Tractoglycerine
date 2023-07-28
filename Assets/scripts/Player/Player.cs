using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxHealth = 5;
    private float health;
    private bool load = false;
    

    [SerializeField] GameObject GameOver;
    public bool hasDied { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    void MakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            MakeDamage(collision.gameObject.GetComponent<Enemy>().data.damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            hasDied = true;

            if (!load)
            {

                load = true;
                

                Debug.Log("Le joueur est mort");
                                
                Destroy(GetComponent<PlayerMovement>());
                Destroy(GetComponent<PlayerController>());

                GameOver.SetActive(hasDied);

            }
        }
    }
}
