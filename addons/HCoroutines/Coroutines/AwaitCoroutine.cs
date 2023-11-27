namespace HCoroutines;

using System.Threading.Tasks;

/// <summary>
/// A coroutine that waits until an asynchronous task has been completed.
/// If the coroutine is killed before completion, the async task
/// will currently *not* be canceled.
/// </summary>
/// <typeparam name="T"></typeparam>
public class AwaitCoroutine<T> : CoroutineBase {
    public Task<T> Task { get; }

    public AwaitCoroutine(Task<T> task) {
        Task = task;
    }

    private void TryEnd() {
        if (Task.IsCompleted) {
            Kill();
        }
    }

    public override void OnEnter() {
        TryEnd();
        if (IsAlive) {
            ResumeUpdates();
        }
    }

    public override void Update() {
        TryEnd();
    }
}

/// <summary>
/// A coroutine that waits until an asynchronous task has been completed.
/// If the coroutine is killed before completion, the async task
/// will currently *not* be canceled.
/// </summary>
public class AwaitCoroutine : CoroutineBase {
    public Task Task { get; }

    public AwaitCoroutine(Task task) {
        Task = task;
    }

    private void TryEnd() {
        if (Task.IsCompleted) {
            Kill();
        }
    }

    public override void OnEnter() {
        base.OnEnter();
        TryEnd();
    }

    public override void Update() {
        TryEnd();
    }
}