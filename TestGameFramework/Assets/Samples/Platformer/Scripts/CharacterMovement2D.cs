using Eu4ng.Framework.Game;
using Eu4ng.Utilities;
using UnityEngine;

namespace Project.Platformer
{
    public class CharacterMovement2D : ActorComponent
    {
        [field: SerializeField, ReadOnly] protected Rigidbody2D RigidbodyComponent { get; private set; }
        [field: SerializeField, ReadOnly] protected CapsuleCollider2D CapsuleColliderComponent { get; private set; }

        [field: SerializeField] protected float GroundCheckDistance { get; private set; } = 0.4f;
        [field: SerializeField] protected LayerMask GroundLayer { get; private set; } = 1;
        [field: SerializeField, ReadOnly] public bool IsGrounded { get; private set; }
        [field: SerializeField, ReadOnly] public Collider2D Ground { get; private set; }

        [field: SerializeField] protected float MoveSpeed { get; private set; } = 7;
        [field: SerializeField] protected float JumpForce { get; private set; } = 12;

        protected Vector2 GroundOrigin => new Vector2(
            CapsuleColliderComponent.transform.position.x,
            CapsuleColliderComponent.transform.position.y - CapsuleColliderComponent.size.y / 2
            );

        /* MonoBehaviour */

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            CheckGround();
        }

        /* ComponentBase */

        protected override void AssignReferences()
        {
            base.AssignReferences();

            var character = Owner as Character2D;
            if (character != null)
            {
                RigidbodyComponent = character.RigidbodyComponent;
                CapsuleColliderComponent = character.CapsuleColliderComponent;
            }
        }

        /* CharacterMovement2D */

        public virtual void Move(Vector2 moveVector)
        {
            if (RigidbodyComponent is null) return;

            RigidbodyComponent.linearVelocity = new Vector2(moveVector.x * MoveSpeed, RigidbodyComponent.linearVelocity.y);
        }

        public virtual void Jump()
        {
            if (RigidbodyComponent is null || !IsGrounded) return;

            RigidbodyComponent.linearVelocity = new Vector2(RigidbodyComponent.linearVelocity.x, JumpForce);
        }

        protected virtual void CheckGround()
        {
            if (CapsuleColliderComponent is null) return;

            var hits = new RaycastHit2D[10];
            Physics2D.RaycastNonAlloc(GroundOrigin, Vector2.down, hits, GroundCheckDistance, GroundLayer);
            foreach (var hit in hits)
            {
                if (hit.collider is null)
                {
                    Ground = null;
                    break;
                }

                if (hit.collider.gameObject != Owner.gameObject)
                {
                    Ground = hit.collider;
                    break;
                }
            }

            IsGrounded = Ground is not null;
        }

        protected virtual void OnDrawGizmos()
        {
            if (!Application.isPlaying) return;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(GroundOrigin, new Vector2(GroundOrigin.x, GroundOrigin.y - GroundCheckDistance));
        }
    }
}
