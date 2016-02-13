using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Diagnostics;

namespace Elysion
{
    class SoundMgr
    {
        protected IrrKlang.ISound 재생중음원;
        protected IrrKlang.ISoundEngine 사운드엔진;
        protected System.Timers.Timer 타이머;
        public int timeflag = 0;
        public Dictionary<int, List<string>> 시간들; // in ms

        public SoundMgr()
        {
            사운드엔진 = new IrrKlang.ISoundEngine();
            타이머 = new System.Timers.Timer();
            타이머.Interval = 40; // ms
            타이머.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        public void Play()
        {
            타이머.Start();

        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string prefix = @"./Content/SampleBMS/";
            List<string> temp = 시간들[timeflag];
            for (int i=0; i<temp.Count; i++)
            {
                Debug.WriteLine("B: T={0}, i={1}, C={2}", timeflag, i, temp.Count);
                재생중음원 = 사운드엔진.Play2D(prefix + temp[i], false);
                Debug.WriteLine("A: T={0}, i={1}, C={2}", timeflag, i, temp.Count);
            }
            timeflag++;
        }



        
        
    }
}
