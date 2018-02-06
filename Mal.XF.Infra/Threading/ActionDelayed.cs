using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mal.XF.Infra.Threading
{
    public class ActionDelayed
    {
        private CancellationTokenSource cancellationTokenSource;
        private readonly int delayInMs;

        public ActionDelayed() : this(200)
        {
        }

        public ActionDelayed(int delayInMs)
        {
            this.delayInMs = delayInMs;
        }

        public void Start(Action action)
        {
            this.cancellationTokenSource?.Cancel();

            this.cancellationTokenSource = new CancellationTokenSource();
            this.StartWithDelay(action, this.cancellationTokenSource.Token);
        }

        private async void StartWithDelay(Action action, CancellationToken token)
        {
            await Task.Delay(this.delayInMs);
            try
            {
                if (token.IsCancellationRequested)
                    return;

                action.Invoke();
            }
            finally
            {
                this.cancellationTokenSource = null;
            }
        }
    }
}
