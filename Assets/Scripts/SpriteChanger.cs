using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite _oldSprite;
    [SerializeField] private Sprite _newSprite;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _renderer.sprite = _newSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _renderer.sprite = _oldSprite;
        }
    }
}
