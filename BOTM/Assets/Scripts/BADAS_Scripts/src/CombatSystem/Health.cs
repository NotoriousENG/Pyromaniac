using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float capacity = 3f;
    public Vector3 respawnPos;
    public float current;
    public bool isSceneChanger;
    public string SceneName = "default";

    private Color Red = new Color(255,0,0,255);
    private Color Default = new Color (255,255,255,255);
    private SpriteRenderer spriteRenderer;
    private float blinkTime = .25f;
    private float waitTime = 1f;
    private Vector2 knockback;
    private float knockbackSpeed = 5f;
    private bool inKnockback;

    private void Awake() 
    {
        current = capacity; // on awake, have full health
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        if (spriteRenderer.color != Default &&  Time.timeSinceLevelLoad > waitTime)
        {
            spriteRenderer.color = Default;
            inKnockback = false;
        }
        if (inKnockback)
        {
            applyKnockBack();
        }
        if (current >= capacity)
        {
            current = capacity;
        }
    }
    public void damageHealth(float damage, GameObject damager)
    {
        current -= damage; // take damage (Negative Values Heal)
        if (damage > 0)
        {
            spriteRenderer.color = Red; // RGBA -> Red
        }
        else if (damage < 0)
        {
            spriteRenderer.color = Color.green;
        }
        waitTime = Time.timeSinceLevelLoad + blinkTime;

        knockback = getKnockBack(damager.transform.position);
        inKnockback = true;

        if (current <= 0) // health is depleted
        {
            if (gameObject.tag.Equals ("Player"))
            {
                current = capacity;
                gameObject.transform.position = respawnPos;
            }
            else 
            {
                Kill();
            }
            
        }
        
    }

    private Vector2 getKnockBack(Vector2 damagerPos)
    {
        return ((Vector2)damagerPos - (Vector2)transform.position).normalized;
    }
    private void applyKnockBack()
    {
        // Debug.Log((Vector2)transform.position + knockback);
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position - knockback, knockbackSpeed * Time.deltaTime);
    }

    private void Kill() // call when health is depleted
    {
        gameObject.SetActive(false); // disable game object
        Destroy(gameObject);

        if (isSceneChanger && !SceneName.Equals("default"))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
