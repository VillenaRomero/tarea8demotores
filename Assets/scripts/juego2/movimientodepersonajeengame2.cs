using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimientodepersonajeengame2 : MonoBehaviour
{
    public float speed = 5f;
    public Color defaultColor;
    public int initialHealth = 100;
    public int damageOnWrongColor = 10;

    private Vector2 movement;
    private Renderer playerRenderer;
    private Color currentColor;
    private int currentHealth;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        playerRenderer.material.color = defaultColor;
        currentColor = defaultColor;
        currentHealth = initialHealth;
    }

    public void DirectionAxis(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 moveDir = movement.normalized * speed * Time.deltaTime;
        transform.Translate(moveDir);
    }

    void OnCollisionEnter(Collision collision)
    {
        Renderer collisionRenderer = collision.gameObject.GetComponent<Renderer>();

        if (collisionRenderer != null)
        {
            Color collisionColor = collisionRenderer.material.color;

            if (collisionColor != currentColor)
            {
                TakeDamage(damageOnWrongColor);

                currentColor = collisionColor;
                playerRenderer.material.color = currentColor;
            }
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Jugador ha recibido " + amount + " de daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
           Destroy(this.gameObject);
        }
    }
}