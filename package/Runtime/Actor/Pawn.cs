using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public class Pawn : Actor
    {
        public Controller OwningController { get; private set; }

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
