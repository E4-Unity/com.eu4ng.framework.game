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

            PlayerInputComponent = PlayerInputComponent != null ? PlayerInputComponent : GetComponent<PlayerInput>();
            PlayerInputActionMap = PlayerInputComponent != null ? PlayerInputComponent.actions.FindActionMap(PlayerInputActionMapName) : null;
            MoveAction = PlayerInputActionMap?.FindAction(MoveActionName);
            JumpAction = PlayerInputActionMap?.FindAction(JumpActionName);
        }
    }
}
