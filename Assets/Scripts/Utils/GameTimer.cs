using System;

namespace Utils
{
    public class GameTimer
    {
        public float remainTime { get; private set; }

        public bool isFinished => remainTime <= 0.0f;

        private bool isPaused = true;
        private float startTime;

        public GameTimer(float startTime)
        {
            this.startTime = startTime;
            this.remainTime = startTime;
        }

        public void Restart()
        {
            this.remainTime = startTime;
        }

        public void Start()
        {
            isPaused = false;
        }

        public void Pause()
        {
            isPaused = true;
        }

        public void UpdateDeltaTime(float deltaTime)
        {
            if (isPaused) return;
            remainTime = Math.Max(0.0f, remainTime - deltaTime);
            
        }
    }
}