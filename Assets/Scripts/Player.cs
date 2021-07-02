using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    
    private const float MoveSpeed = 10f;

    public DialogueUI DialogueUI => dialogueUI;
    
    public IInteractable Interactable { get; set; }
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (dialogueUI.IsOpen) return;
        
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        rb.MovePosition(rb.position + input.normalized * (MoveSpeed * Time.fixedDeltaTime));

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactable?.Interact(this);
        }
    }
}
