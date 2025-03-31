using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public class Controller : Actor
    {
        public Pawn OwningPawn { get; private set; }

        public void Possess(Pawn pawn)
        {
            if (pawn == null) return;
            OwningPawn = pawn;

            OnPossess(pawn);
        }

        public void UnPossess()
        {
            if (OwningPawn == null) return;
            OwningPawn = null;

            OnUnPossess();
        }

        protected virtual void OnPossess(Pawn pawn) {}
        protected virtual void OnUnPossess() {}
    }
}
