using ECommons.Automation;
using ECommons.DalamudServices;
using Splatoon.SplatoonScripting;
using System.Collections.Generic;

namespace SplatoonScriptsUnofficial.Island
{
    public class Island_Gather : SplatoonScript
    {
        TaskManager? TaskManager;

        public override HashSet<uint> ValidTerritories => new();

        public override Metadata? Metadata => new(1, "mOnkEYmC");

        public override void OnMessage(string message)
        {
            if (message.Contains("You obtain a"))
            {
                TaskManager?.Abort();
                TaskManager?.DelayNext(1_000);
                TaskManager?.Enqueue(() =>
                {
                    Chat.Instance.SendMessage("/targetnpc");
                    Chat.Instance.SendMessage("/lockon");
                    Chat.Instance.SendMessage("/automove");
                });
                TaskManager?.DelayNext(3_000);
                TaskManager?.Enqueue(() =>
                {
                    Svc.Targets.ClearTarget();
                    Chat.Instance.SendMessage("/e You obtain a");
                });
            }
        }

        public override void OnEnable()
        {
            TaskManager ??= new();
        }

        public override void OnDisable()
        {
            TaskManager?.Dispose();
        }

    }
}
