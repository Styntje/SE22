using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ontwikkelopdracht
{
    public class Lid
    {
        public static int current;

        public enum EGeslacht { M, V }
        public enum ERecht { Admin, Lid }
        public int LidNummer
        {
            get;
            private set;
        }

        public string Naam
        {
            get;
            private set;
        }

        public DateTime Geboortedatum
        {
            get;
            private set;
        }

        public DateTime DatumLidGeworden
        {
            get;
            private set;
        }

        public EGeslacht Geslacht
        {
            get;
            private set;
        }

        public string RekeningNummer
        {
            get;
            private set;
        }

        public string TelefoonNummer
        {
            get;
            private set;
        }

        public string Postcode
        {
            get;
            private set;
        }

        public string Adres
        {
            get;
            private set;
        }

        public string Woonplaats
        {
            get;
            private set;
        }

        public string TeamCode
        {
            get;
            set;
        }

        public int OrganisatorNummer
        {
            get;
            private set;
        }

        public ERecht Rechten
        {
            get;
            private set;
        }

        public string Wachtwoord
        {
            get;
            private set;
        }

        public Lid(int lidNummer,
                    string naam,
                    DateTime geboortedatum,
                    EGeslacht geslacht,
                    string rekeningNummer,
                    string TelefoonNummer,
                    string postcode,
                    string adres,
                    string woonplaats,
                    string teamCode,
                    int organisatorNummer,
                    ERecht rechten,
                    string wachtwoord)
        {
            this.LidNummer = lidNummer;
            this.Naam = naam;
            this.Geboortedatum = geboortedatum;
            this.Geslacht = geslacht;
            this.RekeningNummer = rekeningNummer;
            this.TelefoonNummer = TelefoonNummer;
            this.Postcode = postcode;
            this.Adres = adres;
            this.Woonplaats = woonplaats;
            this.TeamCode = teamCode;
            this.OrganisatorNummer = organisatorNummer;
            this.Rechten = rechten;
            this.Wachtwoord = wachtwoord;
        }

        public bool CheckWachtwoord(string wachtwoord)
        {
            if(this.Wachtwoord == wachtwoord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}