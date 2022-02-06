using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveCharacter(true, 90, Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveCharacter(false, 0, Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveCharacter(true, -90, Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveCharacter(true, 0, Vector2.right);
        }




        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneLoadManager.Instance.ReloadScene();
        }
    }

    private void MoveCharacter(bool IsXFlip, float zRotateAngle,Vector2 moveDirection)
    {
        if (IfCanMove(moveDirection))
        {
            Rotate(IsXFlip, zRotateAngle);
            transform.position += (Vector3)moveDirection;
        }
    }

    private void Rotate(bool IsXFlip, float zRotateAngle)
    {
        _spriteRenderer.flipX = IsXFlip;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotateAngle));
    }

    private bool IfCanMove(Vector3 direction)
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, 1f);
        if (raycastHit.collider != null)
        {
            if (raycastHit.collider.CompareTag("Wall"))
            {
                return false;
            }
            else if (raycastHit.collider.CompareTag("Box"))
            {
                RaycastHit2D[] raycastHitForBox = Physics2D.RaycastAll(raycastHit.collider.transform.position, direction, 1f);
                foreach(RaycastHit2D raycastHit2DBox in raycastHitForBox)
                {
                    if (raycastHit2DBox.collider == raycastHit.collider) { continue; }
                    if (!raycastHit2DBox.collider.CompareTag("Untagged"))
                    {
                        return false;
                    }
                }
                raycastHit.collider.transform.position += direction;
            }
        }
        return true;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
#endif
}
