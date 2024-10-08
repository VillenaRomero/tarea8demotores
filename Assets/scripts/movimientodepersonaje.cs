using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Color defaultColor; 
    public Sprite defaultSprite; 

    private Vector2 movement;
    private Renderer playerRenderer; 
    private Color currentCollisionColor; 
    private Sprite currentCollisionSprite; 

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        playerRenderer.material.color = defaultColor;
        if (playerRenderer is SpriteRenderer)
        {
            ((SpriteRenderer)playerRenderer).sprite = defaultSprite;
        }
        currentCollisionColor = defaultColor;
        currentCollisionSprite = defaultSprite;
    }

    public void DirectionAxis(InputAction.CallbackContext context)
    {
        float moveX = Input.GetAxis("Horizontal");

        float moveY = Input.GetAxis("Vertical");

        movement = new Vector2(moveX, moveY);

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

            Sprite collisionSprite = null;
            if (collisionRenderer is SpriteRenderer)
            {
                collisionSprite = ((SpriteRenderer)collisionRenderer).sprite;
            }

            if (collisionColor != currentCollisionColor || collisionSprite != currentCollisionSprite)
            {
                currentCollisionColor = collisionColor;
                currentCollisionSprite = collisionSprite;
                playerRenderer.material.color = currentCollisionColor;
                if (playerRenderer is SpriteRenderer)
                {
                    ((SpriteRenderer)playerRenderer).sprite = currentCollisionSprite;
                }

                Transform playerTransform = transform;
                Transform collidedTransform = collision.gameObject.transform;
                playerTransform.localScale = collidedTransform.localScale;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {

    }
}