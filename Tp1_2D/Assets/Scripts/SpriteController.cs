using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRenderer = null;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minSpritePositionX;
    [SerializeField] private float maxSpritePositionX;

    private Vector3 position = Vector3.zero;
    private int direction = 0;

    private void Start()
    {
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            position = spriteRenderer[i].transform.position;
            position.x += spriteRenderer[i].sprite.bounds.size.x * i;
            spriteRenderer[i].transform.position = position;
        }
    }
    private void Update()
    {
        CheckInput();
        ControlMouvement();
    }


    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

    }

    private void ControlMouvement()
    {
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            position = spriteRenderer[i].transform.position;
            position.x += direction * speed * Time.deltaTime;
            spriteRenderer[i].transform.position = position;
        }

        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            if (direction == -1)
            {
                if (spriteRenderer[i].transform.position.x < minSpritePositionX)
                {
                    position = spriteRenderer[i].transform.position;
                    position.x += spriteRenderer[i].sprite.bounds.size.x * spriteRenderer.Length;
                    spriteRenderer[i].transform.position = position;
                }
            }
            else if (direction == 1)
            {
                if (spriteRenderer[i].transform.position.x > maxSpritePositionX)
                {
                    position = spriteRenderer[i].transform.position;
                    position.x -= spriteRenderer[i].sprite.bounds.size.x * spriteRenderer.Length;
                    spriteRenderer[i].transform.position = position;
                }
            }

            position = spriteRenderer[i].transform.position;
            position.x += direction * speed * Time.deltaTime;
            spriteRenderer[i].transform.position = position;
        }

    }
}
