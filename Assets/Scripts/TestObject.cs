using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Shaking");
        transform.DOShakePosition(
            duration: 0.2f,
            strength: new Vector2(0.3f, 0),
            vibrato: 10,
            fadeOut: false
        ).SetLoops(-1);
    }
}
