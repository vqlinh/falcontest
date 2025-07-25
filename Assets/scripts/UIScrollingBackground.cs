using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollingBackground : MonoBehaviour
{
    public RectTransform bg1;
    public RectTransform bg2;
    public float scrollSpeed = 50f;

    private float height;

    void Start()
    {
        height = bg1.rect.height;
    }

    void Update()
    {
        Move(bg1);
        Move(bg2);
        CheckAndReset(bg1, bg2);
        CheckAndReset(bg2, bg1);
    }

    void Move(RectTransform bg)
    {
        bg.anchoredPosition -= new Vector2(0, scrollSpeed * Time.deltaTime);
    }

    void CheckAndReset(RectTransform moving, RectTransform other)
    {
        if (moving.anchoredPosition.y <= -height)
        {
            moving.anchoredPosition = new Vector2(0, other.anchoredPosition.y + height);
        }
    }
}