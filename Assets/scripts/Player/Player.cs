using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    void MakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Le joueur est mort");
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            MakeDamage(collision.gameObject.GetComponent<Enemy>().damage);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
