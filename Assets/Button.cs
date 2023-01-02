using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public float pressLength;
    public bool pressed;
    public ButtonEvent downEvent;

    Vector3 startPos;
    Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, startPos);
        if (distance >= pressLength)
        {
            transform.position = new Vector3(transform.position.x, startPos.y - pressLength, transform.position.z);
            if (!pressed)
            {
                pressed = true;
                downEvent?.Invoke();
            }
        } else
        {
            pressed = false;
        }
        if (transform.position.y > startPos.y)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
    }

    public void OnCustomButtonPress()
    {
        Debug.Log("We pushed our custom button!");
    }
}