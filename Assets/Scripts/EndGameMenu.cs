using UnityEngine;

namespace Assets.Scripts
{
    internal class EndGameMenu : MonoBehaviour
    {
        public PlayerState PlayerState;

        public SpawnManager SpawnManager;

        public GameObject ChooseDifficulty;

        public PlayerController PlayerController;

        public GameObject DeathPannel;

        private void DestroyAnimalsAndFood()
        {
            var objects = FindObjectsOfType<Destroy>();
            foreach (var obj in objects)
            {
                Destroy(obj.gameObject);
            }
        }

        private void ClosePanel()
        {
            DestroyAnimalsAndFood();
            PlayerController.enabled = true;
            PlayerState.ResetCounters();
            DeathPannel.SetActive(false);
        }

        public void Restart()
        {
            SpawnManager.enabled = true;
            ClosePanel();
        }

        public void MainMenu()
        {
            ChooseDifficulty.SetActive(true);
            ClosePanel();
        }
    }
}
