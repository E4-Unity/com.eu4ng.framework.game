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
            // Old Pawn
            if (OwningPawn != null)
            {
                UnPossess();
            }

            OwningPawn = pawn;

            // New Pawn
            if (OwningPawn != null)
            {
                OwningPawn.PossessedBy(this);
                OnPossess();
            }
        }

        public void UnPossess()
        {
            if (OwningPawn == null) return;

            OnUnPossess();
            OwningPawn.UnPossessed();

            OwningPawn = null;
        }

        protected virtual void OnPossess() {}
        protected virtual void OnUnPossess() {}
    }
}
