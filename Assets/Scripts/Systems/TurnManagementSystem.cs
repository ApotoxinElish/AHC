using UnityEngine;

namespace AHC
{
    public class TurnManagementSystem : MonoBehaviour
    {
        public GameEvent PlayerTurnBegan;
        public GameEvent PlayerTurnEnded;
        public GameEvent EnemyTurnBegan;
        public GameEvent EnemyTurnEnded;

        private bool isEnemyTurn;
        private float accTime;

        private bool isEndOfGame;

        private const float EnemyTurnDuration = 3.0f;

        protected void Update()
        {
            if (isEnemyTurn)
            {
                accTime += Time.deltaTime;
                if (accTime >= EnemyTurnDuration)
                {
                    accTime = 0.0f;
                    EndEnemyTurn();
                    BeginPlayerTurn();
                }
            }
        }

        public void BeginGame()
        {
            BeginPlayerTurn();
        }

        public void BeginPlayerTurn()
        {
            PlayerTurnBegan.Raise();
        }

        public void EndPlayerTurn()
        {
            PlayerTurnEnded.Raise();
            BeginEnemyTurn();
        }

        public void BeginEnemyTurn()
        {
            EnemyTurnBegan.Raise();
            isEnemyTurn = true;
        }

        public void EndEnemyTurn()
        {
            EnemyTurnEnded.Raise();
            isEnemyTurn = false;
        }

        public void SetEndOfGame(bool value)
        {
            isEndOfGame = value;
        }

        public bool IsEndOfGame()
        {
            return isEndOfGame;
        }
    }
}
