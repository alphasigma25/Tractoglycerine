using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxHealth = 5;
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
            Destroy(GetComponent<PlayerMovement>());
            Destroy(GetComponent<PlayerController>());

        }
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

    }
}
