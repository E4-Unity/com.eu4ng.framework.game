using Eu4ng.Utilities;
using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public class Pawn : Actor
    {
        /* Properties */

        [field: SerializeField, ReadOnly]
        public Controller OwningController { get; private set; }

        /* MonoBehaviour */

        protected override void OnDestroy()
        {
            if (OwningController != null) OwningController.UnPossess();

            base.OnDestroy();
        }

        /* Pawn */

        public void PossessedBy(Controller controller)
        {
            if (controller == null) return;
            OwningController = controller;

            OnPossessedBy(controller);
        }

        public void UnPossessed()
        {
            if(OwningController == null) return;
            OwningController = null;

            OnUnPossessedBy();
        }

        protected virtual void OnPossessedBy(Controller controller) {}
        protected virtual void OnUnPossessedBy() {}
    }
}
