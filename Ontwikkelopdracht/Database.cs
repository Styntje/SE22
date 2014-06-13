using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace Ontwikkelopdracht
{
    public class Database
    {
        //   ||<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>||
        //   ||                                              ||
        //   ||    Aanmaken Oracle Connectie benodigdheden   ||
        //   ||                                              ||
        //   ||<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>||


        private static OracleConnection conn;
        private static OracleCommand cmd;
        private static OracleDataReader rdr;
        private static OracleDataAdapter apt;
        private static DataTable ds;


        /// <summary>
        /// Constructor
        /// </summary>
        static Database()
        {
            conn = new OracleConnection();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            connectie();
        }

        /// <summary>
        /// Connectie gemaakt
        /// </summary>
        private static void connectie()
        {
            String pcn = "dbi300480";
            String pw = "HH9VTIT7qf";
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//192.168.15.50:1521/fhictora" + ";";
        }


        /// <summary>
        /// Probeer de Connectie te openen
        /// </summary>
        private static void Open()
        {
            try
            {
                conn.Open();
            }
            catch { }
        }

        /// <summary>
        /// Probeer de Connectie te sluiten
        /// </summary>
        private static void Close()
        {
            try
            {
                conn.Close();
            }
            catch { }
        }

        public static Lid GetLid(int lidnr)
        {
            Open();
            Lid lid = null;
            cmd.CommandText = "SELECT * FROM LID WHERE LIDNR = " + lidnr.ToString();
            cmd.CommandType = CommandType.Text;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int nummer;
                try
                {
                    nummer = Convert.ToInt32(rdr["ORGANISATORNR"]);
                }
                catch
                {
                    nummer = -1;
                }

                lid = new Lid(Convert.ToInt32(rdr["LIDNR"]),
                    rdr["NAAM"].ToString(),
                    Convert.ToDateTime(rdr["GEBOORTEDATUM"]),
                    (rdr["GESLACHT"].ToString() == "M" ? Lid.EGeslacht.M : Lid.EGeslacht.V),
                    rdr["REKENINGNUMMER"].ToString(),
                    rdr["TELEFOONNUMMER"].ToString(),
                    rdr["POSTCODE"].ToString(),
                    rdr["ADRES"].ToString(),
                    rdr["TEAMCODE"].ToString(),
                    nummer,
                    (rdr["RECHT"].ToString() == "Admin" ? Lid.ERecht.Admin : Lid.ERecht.Lid),
                    rdr["wachtwoord"].ToString());
            }
            Close();
            return lid;
        }

        public static Lid GetAanvraag(int nr)
        {
            Open();
            Lid lid = null;
            cmd.CommandText = "SELECT * FROM AANVRAAG WHERE LIDNR = " + nr;
            cmd.CommandType = CommandType.Text;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int nummer;
                try
                {
                    nummer = Convert.ToInt32(rdr["ORGANISATORNR"]);
                }
                catch
                {
                    nummer = -1;
                }

                lid = new Lid(Convert.ToInt32(rdr["LIDNR"]),
                    rdr["NAAM"].ToString(),
                    Convert.ToDateTime(rdr["GEBOORTEDATUM"]),
                    (rdr["GESLACHT"].ToString() == "M" ? Lid.EGeslacht.M : Lid.EGeslacht.V),
                    rdr["REKENINGNUMMER"].ToString(),
                    rdr["TELEFOONNUMMER"].ToString(),
                    rdr["POSTCODE"].ToString(),
                    rdr["ADRES"].ToString(),
                    rdr["TEAMCODE"].ToString(),
                    nummer,
                    (rdr["RECHT"].ToString() == "Admin" ? Lid.ERecht.Admin : Lid.ERecht.Lid),
                    rdr["wachtwoord"].ToString());
            }
            return lid;
        }


        public static string GetAanvraag()
        {
            Open();
            Lid lid = null;
            cmd.CommandText = "SELECT * FROM AANVRAAG WHERE ROWNUM < 2";
            cmd.CommandType = CommandType.Text;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int nummer;
                try
                {
                    nummer = Convert.ToInt32(rdr["ORGANISATORNR"]);
                }
                catch
                {
                    nummer = -1;
                }

                lid = new Lid(Convert.ToInt32(rdr["LIDNR"]),
                    rdr["NAAM"].ToString(),
                    Convert.ToDateTime(rdr["GEBOORTEDATUM"]),
                    (rdr["GESLACHT"].ToString() == "M" ? Lid.EGeslacht.M : Lid.EGeslacht.V),
                    rdr["REKENINGNUMMER"].ToString(),
                    rdr["TELEFOONNUMMER"].ToString(),
                    rdr["POSTCODE"].ToString(),
                    rdr["ADRES"].ToString(),
                    rdr["TEAMCODE"].ToString(),
                    nummer,
                    (rdr["RECHT"].ToString() == "Admin" ? Lid.ERecht.Admin : Lid.ERecht.Lid),
                    rdr["wachtwoord"].ToString());
            }
            Close();
            try
            {
                Lid.current = lid.LidNummer;
                return " Nr: " + lid.LidNummer + "<br /> Naam: " + lid.Naam + "<br /> Postcode: " + lid.Postcode + "<br /> Adres: " + lid.Adres + "<br /> Geboortedatum: " + lid.Geboortedatum.ToString() + "<br /> Geslacht: " + lid.Geslacht;
            }
            catch { return "Geen Aanmeldingen"; }
        }

        public static DataTable GetWedstrijden()
        {
            ds = new DataTable();
            try
            {
                Open();
                cmd.CommandText = @"SELECT CASE 
                                    WHEN WEDSTRIJD.WEDSTRIJDNR in (SELECT wedstrijdnr FROM THUISWEDSTRIJD) 
                                    THEN 'Thuis' 
                                    ELSE 'Uit' 
                                    END as WAAR,UITWEDSTRIJD.TEAMUIT AS BASKO, UITWEDSTRIJD.TEAMTHUIS AS TEGENSTANDER, to_char(WEDSTRIJD.DATUM,'DD/MM/YYYY HH:MI')as DATUM , WEDSTRIJD.UITSLAG 
                                    FROM WEDSTRIJD, UITWEDSTRIJD
                                    UNION
                                    SELECT CASE 
                                    WHEN WEDSTRIJD.WEDSTRIJDNR in (SELECT wedstrijdnr FROM THUISWEDSTRIJD) 
                                    THEN 'Thuis' 
                                    ELSE 'Uit'
                                    END as WAAR, THUISWEDSTRIJD.TEAMTHUIS AS BASKO, THUISWEDSTRIJD.TEAMUIT AS TEGENSTANDER,to_char(WEDSTRIJD.DATUM,'DD/MM/YYYY HH:MI')as DATUM , WEDSTRIJD.UITSLAG 
                                    FROM WEDSTRIJD, THUISWEDSTRIJD
                                    ORDER BY DATUM";
                cmd.CommandType = CommandType.Text;
                ds.Load(cmd.ExecuteReader());
                Close();
            }
            catch
            {
                Close();
            }

            return ds;
        }

        public static void AddLid(Lid lid)
        {
            Open();
            cmd.CommandText = @"INSERT INTO LID VALUES( " +
                lid.LidNummer + " , '" +
                lid.Naam + "' , '" +
                lid.Geboortedatum.ToString("dd-MMM-yyyy") + "' , '" +
                lid.Geslacht.ToString() + "' , '" +
                lid.RekeningNummer + "' , '" +
                lid.TelefoonNummer + "' , '" +
                lid.Adres + "' , '" +
                lid.Postcode + "' , '" +
                "Veldhoven" + "' , " +
                " NULL " + " , " +
                " NULL , " +
                "'ww88'" + " , '" +
                lid.Rechten.ToString() + "' )";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }


        public static void AddAanvraag(Lid lid)
        {
            Open();
            cmd.CommandText = @"INSERT INTO AANVRAAG VALUES( " +
                lid.LidNummer + " , '" +
                lid.Naam + "' , '" +
                lid.Geboortedatum.ToString("dd-MMM-yyyy") + "' , '" +
                lid.Geslacht.ToString() + "' , '" +
                lid.RekeningNummer + "' , '" +
                lid.TelefoonNummer + "' , '" +
                lid.Adres + "' , '" +
                lid.Postcode + "' , '" +
                "Veldhoven" + "' , '" +
                lid.TeamCode + "' , " +
                " NULL , " +
                "'ww88'" + " , '" +
                lid.Rechten.ToString() + "' )";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        public static void DeleteAanvraag(int nr)
        {
            cmd.CommandText = "DELETE FROM AANVRAAG WHERE LIDNR=" + nr;
            Open();
            cmd.ExecuteNonQuery();
            Close();
        }

        public static DataTable GetNieuwsberichten()
        {
            ds = new DataTable();
            try
            {
                Open();
                cmd.CommandText = @"SELECT TEKST, NIEUWSNR as NieuwsNr FROM NIEUWZBERICHT";
                cmd.CommandType = CommandType.Text;
                ds.Load(cmd.ExecuteReader());
                Close();
            }
            catch
            { }

            return ds;
        }

        public static DataTable GetNieuwsbericht(int nummer)
        {
            ds = new DataTable();
            try
            {
                Open();
                cmd.CommandText = @"SELECT * FROM NIEUWSBERICHT WHERE NIEUWSNR = " + nummer;
                cmd.CommandType = CommandType.Text;
                ds.Load(cmd.ExecuteReader());
                Close();
            }
            catch
            { }

            return ds;
        }

        public static void VoerUit(string query)
        {
            Open();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            ds.Load(cmd.ExecuteReader());
            Close();
        }

        public static void SetTeam(int nr, int teamcode)
        {
            Lid lid = Database.GetAanvraag(nr);
            lid.TeamCode = teamcode.ToString();
            Database.AddLid(lid);
            Database.DeleteAanvraag(nr);
        }

        public static List<string> GetTeamsBasko()
        {
            List<string> ls = new List<string>();
            try
            {
                Open();
                cmd.CommandText = @"SELECT TEAMCODE FROM TEAM";
                cmd.CommandType = CommandType.Text;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(rdr["TEAMCODE"].ToString());
                }
                Close();
            }
            catch
            {
                Close();
            }

            return ls;
        }

        public static List<string> GetTeamsTegenstander()
        {
            List<string> ls = new List<string>();
            try
            {
                Open();
                cmd.CommandText = @"SELECT TEAMCODE, CLUBNAAM FROM TEGENSTANDER";
                cmd.CommandType = CommandType.Text;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(rdr["CLUBNAAM"].ToString() + " - " + rdr["TEAMCODE"].ToString());
                }
                Close();
            }
            catch
            {
                Close();
            }

            return ls;
        }

        public static bool AddWedstrijd(string basko, string tegenstander, DateTime datum, bool thuis)
        {
            bool gelukt = false;
            try
            {
                cmd.CommandText = "SELECT MAX(WEDSTRIJDNR) FROM WEDSRIJD)";
                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {

                }

                if (thuis)
                {
                    cmd.CommandText = @"INSERT INTO WEDSTRIJD(TEAMTHUIS,TEAMUIT,DATUM) VALUES(" + basko + "," + tegenstander + "," + datum.ToOADate() + ")";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"INSERT INTO THUISWEDSTRIJD(TEAMTHUIS,TEAMUIT) VALUES(" + basko + "," + tegenstander + "," + datum.ToOADate() + ")";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO WEDSTRIJD(TEAMTHUIS,TEAMUIT,DATUM) VALUES(" + tegenstander + "," + basko + "," + datum.ToOADate() + ")";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"INSERT INTO THUISWEDSTRIJD(TEAMTHUIS,TEAMUIT) VALUES(" + tegenstander + "," + basko + ")";
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }

            return gelukt;
        }
    }
}