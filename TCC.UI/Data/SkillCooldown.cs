﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace TCC
{
    public class SkillCooldownOld
    {
        public uint Id { get; set; }
        public uint Cooldown { get; set; }
        public CooldownType Type { get; set; }
        public Timer Timer { get; set; }

        public SkillCooldownOld(uint id, uint cd, CooldownType t)
        {
            Id = id;
            Cooldown = cd;
            if(t == CooldownType.Item)
            {
                Cooldown = Cooldown * 1000;
            }
            Type = t;
            if(cd != 0)
            {
                Timer = new Timer(Cooldown);
            }
        }     
    }
}
