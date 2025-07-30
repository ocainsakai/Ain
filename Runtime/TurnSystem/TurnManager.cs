using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Ain.TurnManager
{
    public class TurnManager : MonoBehaviour
    {
        public ReactiveProperty<TurnPhase> CurrentPhase = new(TurnPhase.Start);
        public ReactiveProperty<int> CurrentTurn = new(1);
        public ReactiveProperty<int> ActionPoints = new();



        private CancellationTokenSource _cts;

        private void Start()
        {
            _cts = new CancellationTokenSource();
            RunTurnLoop(_cts.Token).Forget(); // Không chờ
        }
        private async UniTaskVoid RunTurnLoop(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                // Phase 1: Start
                CurrentPhase.Value = TurnPhase.Start;
                await UniTask.Delay(1000, cancellationToken: ct);

                // Phase 2: Player Turn
                CurrentPhase.Value = TurnPhase.PlayerTurn;
                ActionPoints.Value = 3;

                await UniTask.WaitUntil(() => ActionPoints.Value <= 0, cancellationToken: ct);

                // Phase 3: Enemy Turn
                //CurrentPhase.Value = TurnPhase.EnemyTurn;
                //await EnemyTurn(ct);

                // Phase 4: End
                CurrentPhase.Value = TurnPhase.End;
                CurrentTurn.Value++;
                await UniTask.Delay(500, cancellationToken: ct);
            }
        }
        //private async UniTask EnemyTurn(CancellationToken ct)
        //{
        //    var enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        //    foreach (var enemy in enemies)
        //    {
        //        enemy.TakeTurn(); // Nếu là async, dùng await enemy.TakeTurnAsync()
        //        await UniTask.Delay(1000, cancellationToken: ct);
        //    }
        //}

        private void OnDestroy()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }
    }
}