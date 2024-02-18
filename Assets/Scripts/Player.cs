using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Player : MonoBehaviour
{
    
    [SerializeField] public NumberOrderMiniGame bal;
    //Components
    Rigidbody myRB;
    Transform myAvatar;
    Animator myAnim;
    //Player movement
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;

    [SerializeField] GameObject NPC;
    
     [SerializeField] GameObject NPCCollector;
     [SerializeField] GameObject GiftShop;

    [SerializeField] GameObject taskButton;

    [SerializeField] TMP_Text balanceText;

    [SerializeField] TMP_Text taskText;

      [SerializeField] TMP_Text task2Text;


    //Interaction
    [SerializeField] InputAction MOUSE;
    Vector2 mousePositionInput;
    Camera myCamera;
    [SerializeField] InputAction INTERACTION;
    [SerializeField] LayerMask interactLayer;

    public static int balance = 1000;

    public static int done = 0;
    public static int done2 = 0;

     GameObject highlight;
    private void OnEnable()
    {
        WASD.Enable();
        MOUSE.Enable();
        INTERACTION.Enable();

    }

    private void OnDisable()
    {
        WASD.Disable();
        MOUSE.Disable();
        INTERACTION.Disable();

    }


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        
        myAvatar = transform;

        myAnim = GetComponent<Animator>();
        
        balanceText.SetText(balance.ToString());

        DoneTask();

    }

    // Update is called once per frame
    void Update()
    {
        movementInput = WASD.ReadValue<Vector2>();
        // mousePositionInput = MOUSE.ReadValue<Vector2>();

        if (movementInput.x != 0)
        {
            // Flip the sprite horizontally based on movement direction
            if (movementInput.x > 0)
            {
                myAvatar.localScale = new Vector3(1, 1, 1); // No flip
            }
            else
            {
                myAvatar.localScale = new Vector3(-1, 1, 1); // Flip horizontally
            }
        }

        myAnim.SetFloat("Speed", movementInput.magnitude);

    }

    void DoneTask () {
        
        if (done != 0){
            Debug.Log("wooohoooo");
            taskText.SetText(" ");


        }
        if(done2 != 0){
            Debug.Log("yooohoooo");
            task2Text.SetText(" ");
        }
        
    }


    private void FixedUpdate()
    {
        myRB.velocity = movementInput * movementSpeed;
    }

    //     private void Awake()
    // {
    //     INTERACTION.performed += Interact;
    // }

    //  void Interact(InputAction.CallbackContext context)
    // {
    //     if (context.phase == InputActionPhase.Performed)
    //     {
    //         //Debug.Log("Here");
    //         RaycastHit hit;
    //         Ray ray = myCamera.ScreenPointToRay(mousePositionInput);
    //         if (Physics.Raycast(ray, out hit,interactLayer))
    //         {
    //             if (hit.transform.tag == "Interactable")
    //             {
    //                 if (!hit.transform.GetChild(0).gameObject.activeInHierarchy)
    //                     return;
    //                 AU_Interactable temp = hit.transform.GetComponent<AU_Interactable>();
    //                 temp.PlayMiniGame();
    //             }
    //         }
    //     } 
    // }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            NPC.SetActive(true);
            taskButton.SetActive(true);
        }
        if(other.tag == "NPCCollector")
        {
            Debug.Log("ROP");
            NPCCollector.SetActive(true);
            taskButton.SetActive(true);
            balance -=200;
            done2 +=1;
            DoneTask();
            balanceText.SetText(balance.ToString());

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "NPC")
        {
            NPC.SetActive(false);

        }
          if(other.tag == "NPCCollector")
        {
            NPCCollector.SetActive(false);
            taskButton.SetActive(true);
        }
    }

}