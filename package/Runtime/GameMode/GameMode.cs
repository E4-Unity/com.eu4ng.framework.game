using Eu4ng.Utilities;
using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public class GameMode : Actor
    {
        /* Fields */

        [SerializeField] Controller m_PlayerControllerPrefab;
        [SerializeField] Pawn m_PlayerPrefab;

        [SerializeField, ReadOnly] Pawn m_Player;
        [SerializeField, ReadOnly] Controller m_PlayerController;

        /* Properties */

        Controller PlayerControllerPrefab => m_PlayerControllerPrefab;
        Pawn PlayerPrefab => m_PlayerPrefab;

        public Pawn Player
        {
            get => m_Player;
            protected set
            {
                if (m_Player == value) return;

                if (m_Player != null) Destroy(m_Player.gameObject);

                m_Player = value;
            }
        }

        public Controller PlayerController
        {
            get => m_PlayerController;
            protected set
            {
                if (m_PlayerController == value) return;

                if (m_PlayerController != null) Destroy(m_PlayerController.gameObject);

                m_PlayerController = value;
            }
        }

        /* MonoBehaviour */

        protected override void Awake()
        {
            base.Awake();

            SpawnPlayerController();
            SpawnPlayer();
        }

        /* GameMode */

        public void SpawnPlayer()
        {
            // 유효성 검사
            if (PlayerPrefab == null) return;

            // 플레이어 컨트롤러 빙의 해제
            PlayerController.UnPossess();

            // 씬 오브젝트들 중 PlayerStart 컴포넌트를 지닌 오브젝트 목록 가져오기
            var playerStarts = FindObjectsByType<PlayerStart>(FindObjectsSortMode.None);
            if (playerStarts.Length <= 0) return;

            // 플레이어 스폰 위치 계산
            int playerStartIndex = playerStarts.Length == 1 ? 0 : Random.Range(0, playerStarts.Length);
            Vector3 playerSpawnPosition = playerStarts[playerStartIndex].transform.position;

            // 플레이어 스폰
            Player = Instantiate(PlayerPrefab, playerSpawnPosition, Quaternion.identity);

            // 플레이어 컨트롤러 빙의
            PlayerController.Possess(Player);
        }

        protected void SpawnPlayerController()
        {
            // 유효성 검사
            if (PlayerControllerPrefab == null) return;

            PlayerController = Instantiate(PlayerControllerPrefab);
        }
    }
}
