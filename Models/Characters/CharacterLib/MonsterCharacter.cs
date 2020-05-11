using System;

namespace CharacterLib
{
    public class MonsterCharacter : CharacterBase
    {
        //Character Stats
        public int Level { get; set; }
        

        //Starting Constants
        
        private const int STARTINGhealth = 100;
        private const int STARTINGenergy = 50;
        private const double ATKPWR = 10;
        private const double CRITCHANCE = .15;
        private const double CRITMTPL = 1.5;
        private const double DODGECHANCE = .3;
        private const int MOVE = 5;
        private const int INIT = 5;

        //Default Level Gain Values

        private const double HEALTHgainPERlevel = .1;
        private const double ATTACKgainPERlevel = 5;
        private const double CRITchancePERlevel = .01;
        private const double CRITmultPERlevel = .1;
        private const double DODGEperLEVEL = .05;
        private const int INITperLEVEL = 2;

        public MonsterCharacter() : this(1)
        {
            
        }

        public MonsterCharacter(int startingLevel) : base()
        {
            this.HealthCurrent = STARTINGhealth;
            this.HealthMax = STARTINGhealth;

            this.EnergyMax = STARTINGenergy;
            this.EnergyCurrent = STARTINGenergy;

            this.AttackPower = ATKPWR;
            this.DodgeChance = DODGECHANCE;
            this.CritChance = CRITCHANCE;
            this.CritMultiplier = CRITMTPL;
            this.MovementRate = MOVE;
            this.Initiative = INIT;
            this.Level = startingLevel;
            this.IncreaseLevel(startingLevel-1);
            
        }

        



        public void IncreaseLevel(int increaseLevelBy)
        {
            AdjustHealthLevels(increaseLevelBy);
            AdjustCombatValues(increaseLevelBy);
        }

        private void AdjustCombatValues(int increaseLevelBy)
        {
            this.CritChance += CRITchancePERlevel * increaseLevelBy;
            this.CritMultiplier += CRITmultPERlevel * increaseLevelBy;
            this.AttackPower += ATTACKgainPERlevel * increaseLevelBy;
            this.DodgeChance += DODGEperLEVEL * increaseLevelBy;
            this.Initiative += INITperLEVEL * increaseLevelBy;
        }

        

        private void AdjustHealthLevels(int increaseLevelBy)
        {
            for (int i=0; i < increaseLevelBy; i++)
            {
                this.HealthMax += (int)Math.Floor(HEALTHgainPERlevel * this.HealthMax);
            }
            this.HealthCurrent = this.HealthMax;
        }

        
    }
}
