using Godot;
using System;
using System.Collections;

namespace HCoroutines {
    /// <summary>
    /// Class that allows for easy access to the standard coroutine types.
    /// </summary>
    public static class Co {
        private static Coroutine[] GetCoroutines(IEnumerator[] enumerators) {
            Coroutine[] coroutines = new Coroutine[enumerators.Length];

            for (int i = 0; i < enumerators.Length; i ++) {
                coroutines[i] = new Coroutine(enumerators[i]);
            }

            return coroutines;
        }

        public static float DeltaTime => CoroutineManager.Instance.DeltaTime;


        public static void Run(CoroutineBase coroutine)
            => CoroutineManager.Instance.StartCoroutine(coroutine);

        public static Coroutine Run(IEnumerator coroutine) {
            Coroutine co = new Coroutine(coroutine);
            CoroutineManager.Instance.StartCoroutine(co);
            return co;
        }

        public static Coroutine Run(Func<IEnumerator> creator) {
            Coroutine co = new Coroutine(creator());
            CoroutineManager.Instance.StartCoroutine(co);
            return co;
        }

        public static Coroutine Run(Func<Coroutine, IEnumerator> creator) {
            Coroutine coroutine = new Coroutine();
            coroutine.routine = creator(coroutine);
            CoroutineManager.Instance.StartCoroutine(coroutine);
            return coroutine;
        }


        public static Coroutine Coroutine(IEnumerator enumerator)
            => new Coroutine(enumerator);


        public static ParallelCoroutine Parallel(params IEnumerator[] enumerators)
            => new ParallelCoroutine(GetCoroutines(enumerators));

        public static ParallelCoroutine Parallel(params CoroutineBase[] coroutines)
            => new ParallelCoroutine(coroutines);


        public static SequentialCoroutine Sequence(params IEnumerator[] enumerators)
            => new SequentialCoroutine(GetCoroutines(enumerators));

        public static SequentialCoroutine Sequence(params CoroutineBase[] coroutines)
            => new SequentialCoroutine(coroutines);


        public static WaitDelayCoroutine Wait(float delay)
            => new WaitDelayCoroutine(delay);


        public static WaitForSignalCoroutine WaitForSignal(Godot.Object obj, string signal)
            => new WaitForSignalCoroutine(obj, signal);



        public static RepeatCoroutine Repeat(int times, Func<RepeatCoroutine, CoroutineBase> creator)
            => new RepeatCoroutine(times, creator);

        public static RepeatCoroutine Repeat(int times, Func<CoroutineBase> creator)
            => new RepeatCoroutine(times, coroutine => creator());

        public static RepeatCoroutine Repeat(int times, Func<RepeatCoroutine, IEnumerator> creator)
            => new RepeatCoroutine(times, coroutine => new Coroutine(creator(coroutine)));

        public static RepeatCoroutine Repeat(int times, Func<IEnumerator> creator)
            => new RepeatCoroutine(times, coroutine => new Coroutine(creator()));


        public static RepeatCoroutine RepeatInfinitely(Func<RepeatCoroutine, CoroutineBase> creator)
            => new RepeatCoroutine(-1, creator);

        public static RepeatCoroutine RepeatInfinitely(Func<CoroutineBase> creator)
            => new RepeatCoroutine(-1, coroutine => creator());

        public static RepeatCoroutine RepeatInfinitely(Func<RepeatCoroutine, IEnumerator> creator)
            => new RepeatCoroutine(-1, coroutine => new Coroutine(creator(coroutine)));

        public static RepeatCoroutine RepeatInfinitely(Func<IEnumerator> creator)
            => new RepeatCoroutine(-1, coroutine => new Coroutine(creator()));
    }
}