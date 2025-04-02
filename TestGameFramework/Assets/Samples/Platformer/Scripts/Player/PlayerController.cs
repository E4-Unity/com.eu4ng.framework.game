using Eu4ng.Framework.Game;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Platformer
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : Controller
    {
        /* References */

        [field: SerializeField] protected PlayerInput PlayerInputComponent { get; private set; }

        /* Config */

        // Input

        [field: SerializeField] protected string PlayerInputActionMapName { get; private set; } = "Player";
        [field: SerializeField] protected string MoveActionName { get; private set; } = "Move";
        [field: SerializeField] protected string JumpActionName { get; private set; } = "Jump";

        // Locomotion

        [field: SerializeField] protected float MoveSpeed { get; private set; } = 7;
        [field: SerializeField] protected float JumpForce { get; private set; } = 12;

        /* State */

        protected InputActionMap PlayerInputActionMap { get; private set; }
        protected InputAction MoveAction { get; private set; }
        protected InputAction JumpAction { get; private set; }

        protected Rigidbody2D PlayerRigidbody { get; private set; }

        /* Actor */

        protected override void AssignReferences()
        {
            base.AssignReferences();

            PlayerInputComponent = PlayerInputComponent != null ? PlayerInputComponent : GetComponent<PlayerInput>();
            PlayerInputActionMap = PlayerInputComponent != null ? PlayerInputComponent.actions.FindActionMap(PlayerInputActionMapName) : null;
            MoveAction = PlayerInputActionMap?.FindAction(MoveActionName);
            JumpAction = PlayerInputActionMap?.FindAction(JumpActionName);
        }

        protected override void BindEvents()
        {
            base.BindEvents();

            if (MoveAction != null)
            {
                MoveAction.performed += OnMove;
                MoveAction.canceled += OnMove;
            }

            if (JumpAction != null) JumpAction.performed += OnJump;
        }

        /* Controller */

        protected override void OnPossess(Pawn pawn)
        {
            base.OnPossess(pawn);

            PlayerRigidbody = pawn.GetComponent<Rigidbody2D>();
        }

        protected override void OnUnPossess()
        {
            PlayerRigidbody = null;

            base.OnUnPossess();
        }

        /* PlayerController */

        protected virtual void OnMove(InputAction.CallbackContext context)
        {
            if (PlayerRigidbody == null) return;

            if (context.performed)
            {
                var moveVector = context.ReadValue<Vector2>();
                PlayerRigidbody.linearVelocity = new Vector2(moveVector.x * MoveSpeed, PlayerRigidbody.linearVelocity.y);
            }
            else if (context.canceled)
            {
                PlayerRigidbody.linearVelocity = new Vector2(0, PlayerRigidbody.linearVelocity.y);
            }
        }

        protected virtual void OnJump(InputAction.CallbackContext context)
        {
            if (PlayerRigidbody == null) return;

            PlayerRigidbody.linearVelocity = new Vector2(PlayerRigidbody.linearVelocity.x, JumpForce);
        }
    }
}
