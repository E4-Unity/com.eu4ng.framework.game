using Eu4ng.Framework.Game;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Platformer
{
    public class Character : Pawn
    {
        /* Components */

        [field: SerializeField] protected Rigidbody2D RigidbodyComponent { get; private set; }

        /* Config */

        [field: SerializeField] protected float MoveSpeed { get; private set; } = 7;
        [field: SerializeField] protected float JumpForce { get; private set; } = 12;

        [field: SerializeField] protected string PlayerInputActionMapName { get; private set; } = "Player";
        [field: SerializeField] protected string MoveActionName { get; private set; } = "Move";
        [field: SerializeField] protected string JumpActionName { get; private set; } = "Jump";

        /* State */

        protected InputActionMap PlayerInputActionMap { get; private set; }
        protected InputAction MoveAction { get; private set; }
        protected InputAction JumpAction { get; private set; }

        /* Actor */

        protected override void AssignReferences()
        {
            base.AssignReferences();

            RigidbodyComponent = RigidbodyComponent != null ? RigidbodyComponent : GetComponent<Rigidbody2D>();
        }

        /* Pawn */

        protected override void BindInputComponent()
        {
            base.BindInputComponent();

            PlayerInputActionMap = PlayerInputComponent.actions.FindActionMap(PlayerInputActionMapName);
            MoveAction = PlayerInputActionMap?.FindAction(MoveActionName);
            JumpAction = PlayerInputActionMap?.FindAction(JumpActionName);

            if (MoveAction != null)
            {
                MoveAction.performed += OnMove;
                MoveAction.canceled += OnMove;
            }

            if (JumpAction != null) JumpAction.performed += OnJump;
        }

        protected override void UnBindInputComponent()
        {
            if (MoveAction != null)
            {
                MoveAction.performed -= OnMove;
                MoveAction.canceled -= OnMove;
            }

            if (JumpAction != null) JumpAction.performed -= OnJump;

            PlayerInputActionMap = null;
            MoveAction = null;
            JumpAction = null;

            base.UnBindInputComponent();
        }

        /* Character */

        protected virtual void OnMove(InputAction.CallbackContext context)
        {
            if (RigidbodyComponent == null) return;

            if (context.performed)
            {
                var moveVector = context.ReadValue<Vector2>();
                RigidbodyComponent.linearVelocity = new Vector2(moveVector.x * MoveSpeed, RigidbodyComponent.linearVelocity.y);
            }
            else if (context.canceled)
            {
                RigidbodyComponent.linearVelocity = new Vector2(0, RigidbodyComponent.linearVelocity.y);
            }
        }

        protected virtual void OnJump(InputAction.CallbackContext context)
        {
            if (RigidbodyComponent == null) return;

            RigidbodyComponent.linearVelocity = new Vector2(RigidbodyComponent.linearVelocity.x, JumpForce);
        }
    }
}
