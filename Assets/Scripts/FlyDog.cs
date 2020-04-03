using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Health
using UnityEngine.SceneManagement;

public class FlyDog : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    public float velocity = 1;
    private Rigidbody2D rb;

    Animator animator;
    SpriteRenderer spriteRenderer;

    bool GetDamage = false;

    bool LockMoving = false;






    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();




    }

        //This "myFunction" calculates how many seconds to wait -> yield return new WaitForSeconds(?);
        IEnumerator waitFrameEndFunction()
        {
        animator.Play("laika_hpgain");
        health += 1;
        //yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1.5f);

        animator.Play("laika_idle2");

    }

    IEnumerator waitFrameEndDamageFunction()
    {
        GetDamage = true;
        health -= 1;
        animator.Play("laika_dmg");

        yield return new WaitForSeconds(0.1f);
        animator.Play("laika_dmg_rev");

        yield return new WaitForSeconds(0.3f);
        animator.Play("laika_idle2");
        GetDamage = false;
    }

    IEnumerator DeathToEndScreenFunction()
    {
        LockMoving = true;
        GetDamage = true;
        animator.Play("laika_death");

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("EndMenuScene");

    }

    void FixedUpdate()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {



            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i <numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }

        if (Input.GetMouseButton(0))
        {
            if (LockMoving == false)
            {
                SoundManager.instance.PlaySound(SoundManager.instance.jump);
                rb.velocity = Vector2.up * velocity;
            }
        }

        if (health >= 3)
            {
            health = 3;

        }
        if (health == 0 || health <= 0)
        {
            StartCoroutine(DeathToEndScreenFunction());
            //SceneManager.LoadScene("EndMenuScene");
        }

    }

    void OnBecameInvisible()
    {
        //Jump to the starting point
        //transform.position = new Vector3(transform.position.x, 0);
        //rb.velocity = Vector2.up * velocity;

        //Bounce back (NEW)

        rb.velocity = Vector2.down * velocity;

        health -= 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == 9) //Asteroids
        {


            Destroy(other.gameObject);

            if (GetDamage == false)
            {

                StartCoroutine(waitFrameEndDamageFunction());
                SoundManager.instance.PlaySound(SoundManager.instance.explosion);
                SoundManager.instance.PlaySound(SoundManager.instance.whimper);
            }
        }

        if (other.gameObject.layer == 10) //HP
        {
            SoundManager.instance.PlayEat();

            //animator.Play("laika_hpgain");
            Destroy(other.gameObject);

            StartCoroutine(waitFrameEndFunction());

        }

        if (other.gameObject.layer == 11) //HP Max
        {
            SoundManager.instance.PlayEat();

            Destroy(other.gameObject);
            health += 1;
            StartCoroutine(waitFrameEndFunction());
        }

        if (other.gameObject.layer == 12) //Deadman
        {



            Destroy(other.gameObject);
            if (GetDamage == false)
            {

                StartCoroutine(waitFrameEndDamageFunction());
                SoundManager.instance.PlaySound(SoundManager.instance.impact);
                SoundManager.instance.PlaySound(SoundManager.instance.whimper);
            }
        }

        if (other.gameObject.layer == 13) //Satellite
        {


            Destroy(other.gameObject);

            if (GetDamage == false)
            {

                StartCoroutine(waitFrameEndDamageFunction());
                SoundManager.instance.PlaySound(SoundManager.instance.impact);
                SoundManager.instance.PlaySound(SoundManager.instance.whimper);
            }

        }

        if (other.gameObject.layer == 14) //Planet
        {


            rb.velocity = Vector2.up * velocity;

            if (GetDamage == false)
            {

                StartCoroutine(waitFrameEndDamageFunction());
                SoundManager.instance.PlaySound(SoundManager.instance.impact);
                SoundManager.instance.PlaySound(SoundManager.instance.whimper);
            }

        }

        if (other.gameObject.layer == 30) //When you hit ceiling
        {


            rb.velocity = Vector2.down * velocity;

            if (GetDamage == false)
            {

                StartCoroutine(waitFrameEndDamageFunction());
                SoundManager.instance.PlaySound(SoundManager.instance.impact);
                SoundManager.instance.PlaySound(SoundManager.instance.whimper);
            }

        }

        if (other.gameObject.layer == 31) //When you fall on planet
        {


            if (LockMoving == false)
            {
                rb.velocity = Vector2.up * velocity;
            }
            if (GetDamage == false)
            {

                StartCoroutine(waitFrameEndDamageFunction());

            }
            if (GetDamage && !LockMoving)
            {
                SoundManager.instance.PlaySound(SoundManager.instance.impact);
                SoundManager.instance.PlaySound(SoundManager.instance.whimper);
            }
        }

    }

}

