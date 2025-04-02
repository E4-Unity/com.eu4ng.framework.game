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

        /* Actor */

        protected override void AssignReferences()
        {
            base.AssignReferences();

            PlayerInputComponent = PlayerInputComponent != null ? PlayerInputComponent : GetComponent<PlayerInput>();
        }

        /* Controller */

        protected override void OnPossess()
        {
            base.OnPossess();

            OwningPawn.SetPlayerInputComponent(PlayerInputComponent);
        }

        protected override void OnUnPossess()
        {
            OwningPawn.SetPlayerInputComponent(null);

            base.OnUnPossess();
        }
    }
}
