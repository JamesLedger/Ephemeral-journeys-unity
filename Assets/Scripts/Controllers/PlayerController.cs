using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    public Interactable focus;

    public GameObject panel;
    public Transform playerTransform;
    public bool rightClickMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (rightClickMenu)
            {
                Vector3 panelPosition = Input.mousePosition;
                panelPosition.z = 0f; // Set the Z position to 0 to ensure proper visibility.

                // Offset the panel's position to align the top left corner with the mouse position.
                Vector3 offset = new Vector3(panel.GetComponent<RectTransform>().rect.width / 2f, -panel.GetComponent<RectTransform>().rect.height / 2f, 0f);
                panel.transform.position = panelPosition + offset;

                panel.SetActive(true);
            }
           



            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.onDefocused();
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        focus = newFocus;
        newFocus.OnFocused(transform);
        motor.FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.onDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}
