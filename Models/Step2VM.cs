using Microsoft.EntityFrameworkCore;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Models
{
    public class Step2VM
    {
        public Step2VM()
        {
            CurrentUserInfo = new Person();
            Spouse = new Person()
            {
                FirstName = "spouseFName",
                MiddleName = "spouseMName",
                LastName = "spouseLName",
                Phone = "3472009415",
                Email = "spouse@gmail.com",
                Birthday = DateTime.Now.AddYears(-35),
                Occupation = "N/A",
                SSN = "888-55-8855",
                UserId = "oub4f4rmkmpo4r4mk4rxsf7u",
                id =1234
            };
            Depedents = new List<Dependent>();

        }

        //Main User
        public Person CurrentUserInfo { get; internal set; }
        public bool isCitizen { get; set; } = false;
        public bool isFullTimeStudent { get; set; } = false;
        public bool isPermanentlyDisabled { get; set; } = false;
        public bool isLegallyBlind { get; set; } = false;
        
        //Spouse
        public Person Spouse{ get; internal set; }
        public bool isSCitizen { get; set; } = false;
        public bool isSFullTimeStudent { get; set; } = false;
        public bool isSPermanentlyDisabled { get; set; } = false;
        public bool isSLegallyBlind { get; set; } = false;


        // address
        public bool neverMarried{ get; set; } = false;
        public bool isMarried { get; set; } = false;
        public bool isMarriedLastYear { get; set; } = false;
        public bool liveWithSpouse2017{ get; set; } = false;
        public bool isDivorced{ get; set; } = false;
        public bool isLeggalySeparated { get; set; } = false;
        public bool isWidowed { get; set; } = false;

        public DateTime decreeDate { get; set; } = DateTime.Now;
        public DateTime separateAgreementDate { get; set; } = DateTime.Now;
        public DateTime spouseDeathDate { get; set; } = DateTime.Now;


        //0 unsure, 1 yes, 2 no
        public int isClaimedOrSpouseAsDependent { get; set; } = 0;

        public bool identityTheft { get; set; } = false;
        public bool adoptedAChild { get; set; } = false;

        public List<Dependent> Depedents { get; set; }


    }
}
