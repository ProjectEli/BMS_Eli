using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using System;

namespace Elysion
{
    public class BMSReader
    {
        public Dictionary<string, string> 소리들;
        public Dictionary<string, string> 그림들;
        public List<int> 위치들;
        public List<string> 노트들;
        public List<int> 마디들;
        public List<int> 시간들; // in ms
        public int 플레이어;
        public string 장르;
        public string 제목;
        public string 작곡자;
        public Single BPM;
        public int 플레이레벨;
        private int 랭크구분;
        private int 토탈;
        private string 로딩그림;
        private int 난이도;
        private string 배너그림;


        public BMSReader()
        {
        }

        public bool BMS파일분석()
        {

            플레이어 = 0;
            장르 = "";
            제목 = "";
            작곡자 = "";
            BPM = 0;
            플레이레벨 = 0;
            랭크구분 = 0;
            토탈 = 200;
            로딩그림 = "";
            난이도 = 0;
            배너그림 = "";
            소리들 = new Dictionary<string, string>();
            그림들 = new Dictionary<string, string>();
            마디들 = new List<int>();
            위치들 = new List<int>();
            노트들 = new List<string>();

            string s;
            int k;
            string BPM패턴 = @"#BPM\s.+\n\r?";
            string 소리패턴 = @"#WAV\S+\s+.+\n\r?";
            string 그림패턴 = @"#BMP\S+\s+.+\n\r?";
            string 노트패턴 = @"#\d{5}:.+\n\r?";
            //string pattern = @"^#\S+\s+.+"; // # nonwhite white nonwhite 순서. @은 regexp용
            GC.Collect();

            // 읽기
            StreamReader sr = new StreamReader("Content/SampleBMS/EliSample.bms");
            try { s = sr.ReadToEnd(); }
            catch { return false; }
            finally { sr.Close(); }

            // BPM찾기. 빠른 매칭을 위해 첫 매칭만 사용
            Regex BPMrgx = new Regex(BPM패턴, RegexOptions.IgnoreCase);
            Match BPM매치 = BPMrgx.Match(s);
            Single.TryParse(BPM매치.Value.Substring(5).Trim(), out BPM);
            Console.WriteLine(BPM.ToString());


            //소리분석
            Regex 소리rgx = new Regex(소리패턴, RegexOptions.IgnoreCase);
            MatchCollection 소리매치 = 소리rgx.Matches(s);
            foreach (Match match in 소리매치)
            {
                소리들.Add(match.Value.Substring(4, 2), match.Value.Substring(6).Trim());
            }

            //그림분석
            Regex 그림rgx = new Regex(그림패턴, RegexOptions.IgnoreCase);
            MatchCollection 그림매치 = 그림rgx.Matches(s);
            foreach (Match match in 그림매치)
            {
                그림들.Add(match.Value.Substring(4, 2), match.Value.Substring(6).Trim());
            }

            //노트분석
            Regex 노트rgx = new Regex(노트패턴, RegexOptions.IgnoreCase);
            MatchCollection 노트매치 = 노트rgx.Matches(s);
            foreach (Match match in 노트매치)
            {
                s = match.Value;
                if (s.Substring(7).TrimEnd() != "00") // 존재하는 노트만
                {
                    노트들.Add(s.Substring(7).TrimEnd());
                    if (Int32.TryParse(s.Substring(1, 3), out k)) { 마디들.Add(k); }
                    else { return false; }
                    if (Int32.TryParse(s.Substring(4, 2), out k)) { 위치들.Add(k); }
                    else { return false; }
                }
            }
            return true;

        }


        public bool 노트시간계산()
        {
            Double t = 0;
            if (노트들.Count == 0) { return false; }
            else
            {
                for (int i =0; i<마디들.Count; i++)
                {
                    
                }
                return true;
            }
        }
    }
}
