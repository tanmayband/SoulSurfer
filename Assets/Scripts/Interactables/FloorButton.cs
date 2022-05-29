using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Constants;

public class FloorButton : MonoBehaviour
{
    public Transform top;
    public BetterBoxCollider2D topTrigger;
    public Operable operable;
    private bool isButtonActive;
    public AudioSource pressSound;

    void Start()
    {
        topTrigger.ClearEventHandlers();
        topTrigger.OnTriggerEnterEvent += OnTopEnter;
    }

    void OnTopEnter(Collider2D other)
    {
        if (!ConstantsUtils.CheckLayer(other.gameObject.layer, LAYER.Ghost))
        {
            ToggleButton(true);
            pressSound.Play();
        }
    }

    private void ToggleButton(bool down)
    {
        top.localPosition = new Vector2(top.localPosition.x, down ? 0 : 0.5f);
        if(operable != null)
        {
            if(down) operable.Operate();
            else operable.Stop();
        }
    }

}
