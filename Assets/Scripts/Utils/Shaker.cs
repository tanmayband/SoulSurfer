using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shaker : MonoBehaviour
{
    public Transform center;
    public Transform shakeThis;
    private Tween shaker;

    public void ShakeThatThing(int frequency)
    {
        StopShake();
        shaker = shakeThis.transform.DOShakePosition(
            duration: 0.2f,
            strength: new Vector2(0.1f, 0),
            vibrato: frequency,
            fadeOut: false
        ).SetLoops(-1);
    }

    public void StopShake()
    {
        shaker.Kill();
        Recenter();
    }

    private void Recenter()
    {
        shakeThis.position = center.position;
    }
}
