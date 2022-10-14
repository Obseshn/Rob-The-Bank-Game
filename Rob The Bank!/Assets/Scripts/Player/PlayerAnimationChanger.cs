using UnityEngine.InputSystem;
using UnityEngine;

namespace StarterAssets
{
    public class PlayerAnimationChanger : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private StarterAssetsInputs playerInput;


        private void Update()
        {
            if (playerInput.move != Vector2.zero)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
    }
}

