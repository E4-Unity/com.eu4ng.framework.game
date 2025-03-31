using Eu4ng.Utilities;
using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public class Controller : Actor
    {
        /* Properties */

        [field: SerializeField, ReadOnly]
        public Pawn OwningPawn { get; private set; }

        /* MonoBehaviour */

        protected override void OnDestroy()
        {
            UnPossess();

            base.OnDestroy();
        }

        /* Controller */

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
