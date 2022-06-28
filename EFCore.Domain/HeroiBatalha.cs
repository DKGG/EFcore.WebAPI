using EFcore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain
{
    public class HeroiBatalha
    {
        public int HeroiId { get; set; }
        public Heroi Heroi { get; set; }
        public int BatalhaId { get; set; }
        public Batalha Batalha { get; set; }
    }
}
