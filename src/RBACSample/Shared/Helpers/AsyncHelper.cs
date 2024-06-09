using System.Diagnostics.Contracts;
using System.Windows.Threading;

namespace RBACSample.Shared.Helpers;

public static class AsyncHelper
{
    public static TResult AwaitByPushFrame<TResult>(this Task<TResult> task)
    {
        if (task == null) throw new ArgumentNullException(nameof(task));
        Contract.EndContractBlock();

        var frame = new DispatcherFrame();
        task.ContinueWith(t =>
        {
            frame.Continue = false;
        });
        Dispatcher.PushFrame(frame);
        return task.Result;
    }

    public static TResult AwaitByTaskCompleteSource<TResult>(Task<TResult> func)
    {
        var taskCompletionSource = new TaskCompletionSource<TResult>();
        var task1 = taskCompletionSource.Task;

        Task.Run(async () =>
        {
            var result = await func;
            taskCompletionSource.SetResult(result);
        });
        var task1Result = task1.Result;
        return task1Result;
    }
}