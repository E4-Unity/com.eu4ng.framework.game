using Eu4ng.Utilities;
using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public class GameMode : Actor
    {
        /* Properties */

        [field: Header("Player")]
        [field: SerializeField] protected Controller PlayerControllerPrefab { get; private set; }
        [field: SerializeField] protected Pawn PlayerPrefab { get; private set; }
        [field: SerializeField, ReadOnly] public Pawn Player { get; protected set; }
        [field: SerializeField, ReadOnly] public Controller PlayerController { get; protected set; }

        /* MonoBehaviour */

        protected override void Awake()
        {
            base.Awake();

            SpawnPlayerController();
            SpawnPlayer();
        }

        /* GameMode */

        protected virtual void SpawnPlayer()
        {
            // 유효성 검사
            if (PlayerPrefab == null) return;

            // 기존 플레이어 파괴
            if (Player is not null) Destroy(Player.gameObject);

            // 씬 오브젝트들 중 PlayerStart 컴포넌트를 지닌 오브젝트 목록 가져오기
            var playerStarts = FindObjectsByType<PlayerStart>(FindObjectsSortMode.None);
            if (playerStarts.Length <= 0) return;

            // 플레이어 스폰 위치 계산
            int playerStartIndex = playerStarts.Length == 1 ? 0 : Random.Range(0, playerStarts.Length);
            Vector3 playerSpawnPosition = playerStarts[playerStartIndex].transform.position;

            // 새로운 플레이어 스폰
            Player = Instantiate(PlayerPrefab, playerSpawnPosition, Quaternion.identity);

            // 플레이어 컨트롤러 빙의
            PlayerController.Possess(Player);
        }

        protected virtual void SpawnPlayerController()
        {
            // 유효성 검사
            if (PlayerControllerPrefab == null) return;

            // 기존 플레이어 컨트롤러 파괴
            if (PlayerController is not null) Destroy(PlayerController.gameObject);

            // 새로운 플레이어 컨트롤러 스폰
            PlayerController = Instantiate(PlayerControllerPrefab);

            // 플레이어가 존재하는 경우 컨트롤러 빙의
            if (Player is not null) PlayerController.Possess(Player);
        }
    }
}
