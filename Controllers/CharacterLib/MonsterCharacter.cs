using System;

namespace CharacterLib
{
    public class MonsterCharacter
    {
        //Character Stats
        public int Level { get; set; }
        public int HealthCurrent { get; set; }
        public int HealthMax { get; set; }
        public int EnergyCurrent { get; set; }
        public int EnergyMax { get; set; }

        //CombatStats

        public double AttackPower { get; set; }
        public double CritChance { get; set; }
        public double CritMultiplier { get; set; }
        public double DodgeChance { get; set; }
        public int MovementRate { get; set; }
        public int Initiative { get; set; }


        //Starting Constants
        
        private const int STARTINGhealth = 100;
        private const double ATKPWR = 10;
        private const double CRITCHANCE = .15;
        private const double CRITMTPL = 1.5;
        private const double DODGECHANCE = .3;
        private const int MOVE = 5;
        private const int INIT = 5;

        //Level Gain Values

        private const double HEALTHgainPERlevel = .1;
        private const double ATTACKgainPERlevel = 5;
        private const double CRITchancePERlevel = .01;
        private const double CRITmultPERlevel = .1;
        private const double DODGEperLEVEL = .05;
        private const int INITperLEVEL = 2;

        public MonsterCharacter() : this(1)
        {
            
        }

        public MonsterCharacter(int startingLevel)
        {
            this.HealthCurrent = STARTINGhealth;
            this.HealthMax = STARTINGhealth;
            this.AttackPower = ATKPWR;
            this.DodgeChance = DODGECHANCE;
            this.CritChance = CRITCHANCE;
            this.CritMultiplier = CRITMTPL;
            this.MovementRate = MOVE;
            this.Initiative = INIT;
            this.Level = startingLevel;
            this.IncreaseLevel(startingLevel-1);
            
        }

        public void TakeDamage(int damage)
        {
            this.HealthCurrent -= damage;

            if(this.HealthCurrent <0)
            {
                this.HealthCurrent = 0;
            }
        }

        public void HealDamage(int heal)
        {
            this.HealthCurrent += heal;

            if(this.HealthCurrent > this.HealthMax)
            {
                this.HealthCurrent = this.HealthMax;
            }
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
            double increaseMaxHealth = HEALTHgainPERlevel * increaseLevelBy * this.HealthCurrent;
            this.HealthMax += (int)increaseMaxHealth;
            this.HealthCurrent = this.HealthMax;
        }
    }
}
