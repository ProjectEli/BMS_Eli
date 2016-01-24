using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysion
{
    class SoundMgr
    {
        protected IrrKlang.ISound 재생중음원;
        protected IrrKlang.ISoundEngine 사운드엔진;

        public SoundMgr()
        {
            사운드엔진 = new IrrKlang.ISoundEngine();
        }

        public void Play()
        {
            재생중음원 = 사운드엔진.Play2D(@"./Content/SampleBMS/12C7.ogg", false);
        }
    }
}
