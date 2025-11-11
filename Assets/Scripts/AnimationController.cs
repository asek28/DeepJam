using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // variables
    public bool isWalking;
    public bool isRunning;

    private Animator anim;
    private SimplePlayerMovement simplePlayerMovement;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        simplePlayerMovement = GetComponent<SimplePlayerMovement>();
        
        if (anim == null)
        {
            Debug.LogError("Animator component not found!");
        }
        
        if (simplePlayerMovement == null)
        {
            Debug.LogWarning("SimplePlayerMovement component not found!");
        }
    }

    void Update()
    {
        bool isMoving = false;
        bool isRunningState = false;
        
        // movement
        if (simplePlayerMovement != null)
        {
            isMoving = simplePlayerMovement.IsMoving();
            isRunningState = simplePlayerMovement.IsRunning();
        }
        else
        {
            Debug.LogWarning("No movement script found!");
            return;
        }

        // animation states
        if (isMoving && isRunningState)
        {
            
            isWalking = false;
            isRunning = true;
        }
        else if (isMoving)
        {
            
            isWalking = true;
            isRunning = false;
        }
        else
        {
            
            isWalking = false;
            isRunning = false;
        }

        
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
    }
}
