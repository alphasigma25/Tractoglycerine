using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float maxHealth = 5;
    private float health;
    private bool load = false;
    public bool hasDied { get; set; } = false;

    [SerializeField] GameObject GameOver;

    [SerializeField] TMP_Text life;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        life.text = health.ToString();
    }
    void MakeDamage(int damage)
    {
        health -= damage;
        life.text = health.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !hasDied)
        {
            MakeDamage(collision.gameObject.GetComponent<Enemy>().data.damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (!load)
            {
                load = true;
                hasDied = true;

                Debug.Log("Le joueur est mort");

                Destroy(GetComponent<PlayerMovement>());
                Destroy(GetComponent<PlayerController>());

                GameOver.SetActive(hasDied);
            }
        }
    }
}
