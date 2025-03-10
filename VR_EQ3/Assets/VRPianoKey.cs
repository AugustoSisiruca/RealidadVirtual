using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(HingeJoint), typeof(XRSimpleInteractable))]
public class VRPianoKey : MonoBehaviour
{


    [Header("Key Physics")]
    [Range(0, 45)] public float pressAngleThreshold = 10f;
    public float returnSpringForce = 100f;
    public float damper = 5f;

    private Rigidbody rb;
    private HingeJoint hinge;
    private XRSimpleInteractable simpleInteractable;

    private bool isPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
        simpleInteractable = GetComponent<XRSimpleInteractable>();

        ConfigureHingeJoint();
        ConfigureSimpleInteractable();
    }

    void ConfigureHingeJoint()
    {
        hinge.useSpring = true;
        JointSpring spring = new JointSpring
        {
            spring = returnSpringForce,
            damper = damper
        };
        hinge.spring = spring;
    }



    void ConfigureSimpleInteractable()
    {
        // Configura el XRSimpleInteractable para detectar hover y select
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);
        simpleInteractable.selectExited.AddListener(OnSelectExited);
    }

    void Update()
    {
        CheckKeyPressState();
    }

    void CheckKeyPressState()
    {
        float currentAngle = hinge.angle;

        if (!isPressed && currentAngle >= pressAngleThreshold)
        {
            OnKeyPressed();
        }
        else if (isPressed && currentAngle < pressAngleThreshold * 0.5f)
        {
            OnKeyReleased();
        }
    }

    void OnKeyPressed()
    {
        isPressed = true;
    }

    void OnKeyReleased()
    {
        isPressed = false;
    }




    // Eventos del XRSimpleInteractable
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Simula la presión de la tecla cuando se selecciona (poke)
        rb.AddTorque(Vector3.right * 50f, ForceMode.Impulse);
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // Simula la liberación de la tecla
        rb.AddTorque(Vector3.right * -50f, ForceMode.Impulse);
    }
}