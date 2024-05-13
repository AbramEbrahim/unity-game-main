using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
   

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    public bool dead;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private AudioClip GameOverSound;
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;
    private void Awake()


    {
        startingHealth = GameManager.startHealthInit;
		currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
     
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
              anim.SetTrigger("hurt_player");
              StartCoroutine(Invunerability());
              SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {
                
               foreach (Behaviour component in components)
                      component.enabled = false;
                anim.SetTrigger("hurt_player");
                anim.SetBool("die", true);
                anim.SetTrigger("die_player");

                dead = true;
                SoundManager.instance.PlaySound(deathSound);
                if(_damage!= 10000)
                {

                    StartCoroutine(DelayDestroy());
                    
                }
                else
                {
					SoundManager.instance.PlaySound(GameOverSound);
					GameOver.SetActive(true);

				}

			}
        }
    }
    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.instance.PlaySound(GameOverSound);
		//Destroy(gameObject);
		GameOver.SetActive(true);


	}
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { TakeDamage(1); }
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
