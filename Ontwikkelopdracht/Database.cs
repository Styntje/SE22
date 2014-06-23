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
            cmd.CommandText = "SELECT * FROM LID WHERE LIDNR = :lidnr";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("lidnr",OracleDbType.Int32,lidnr,ParameterDirection.Input);
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
                    rdr["WOONPLAATS"].ToString(),
                    rdr["TEAMCODE"].ToString(),
                    nummer,
                    (rdr["RECHT"].ToString() == "Admin" ? Lid.ERecht.Admin : Lid.ERecht.Lid),
                    rdr["WACHTWOORD"].ToString());
            }
            Close();
            return lid;
        }

        public static Lid GetAanvraag(int nr)
        {
            Open();
            Lid lid = null;
            cmd.CommandText = "SELECT * FROM AANVRAAG WHERE LIDNR =" + nr;
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
                    rdr["WOONPLAATS"].ToString(),
                    rdr["TEAMCODE"].ToString(),
                    nummer,
                    (rdr["RECHT"].ToString() == "Admin" ? Lid.ERecht.Admin : Lid.ERecht.Lid),
                    rdr["WACHTWOORD"].ToString());
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
                    rdr["WOONPLAATS"].ToString(),
                    rdr["TEAMCODE"].ToString(),
                    nummer,
                    (rdr["RECHT"].ToString() == "Admin" ? Lid.ERecht.Admin : Lid.ERecht.Lid),
                    rdr["WACHTWOORD"].ToString());
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
                                    WHERE WEDSTRIJD.WEDSTRIJDNR = UITWEDSTRIJD.WEDSTRIJDNR
                                    UNION
                                    SELECT CASE 
                                    WHEN WEDSTRIJD.WEDSTRIJDNR in (SELECT wedstrijdnr FROM THUISWEDSTRIJD) 
                                    THEN 'Thuis' 
                                    ELSE 'Uit'
                                    END as WAAR, THUISWEDSTRIJD.TEAMTHUIS AS BASKO, THUISWEDSTRIJD.TEAMUIT AS TEGENSTANDER,to_char(WEDSTRIJD.DATUM,'DD/MM/YYYY HH:MI')as DATUM , WEDSTRIJD.UITSLAG 
                                    FROM WEDSTRIJD, THUISWEDSTRIJD
                                    WHERE WEDSTRIJD.WEDSTRIJDNR = THUISWEDSTRIJD.WEDSTRIJDNR
                                    ORDER BY DATUM";
                cmd.CommandType = CommandType.Text;
                ds.Load(cmd.ExecuteReader());
            }
            finally
            {
                Close();
            }

            return ds;
        }

        public static void AddLid(Lid lid)
        {
            Open();
            cmd.CommandText = @"INSERT INTO LID(LIDNR,NAAM,GEBOORTEDATUM,GESLACHT,REKENINGNUMMER,TELEFOONNUMMER,ADRES,POSTCODE,WOONPLAATS,WACHTWOORD,RECHT) VALUES(:lidnr,:naam,:geboortedatum,:geslacht,:rekeningnummer,:telefoonnummer,:adres,:postcode, :woonplaats, :wachtwoord,:rechten)";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("lidnr", OracleDbType.Int32, lid.LidNummer, ParameterDirection.Input);
            cmd.Parameters.Add("naam", OracleDbType.Varchar2, lid.Naam, ParameterDirection.Input);
            cmd.Parameters.Add("geboortedatum", OracleDbType.TimeStamp, lid.Geboortedatum, ParameterDirection.Input);
            cmd.Parameters.Add("geslacht", OracleDbType.Varchar2, lid.Geslacht.ToString(), ParameterDirection.Input);
            cmd.Parameters.Add("rekeningnummer", OracleDbType.Varchar2, lid.RekeningNummer, ParameterDirection.Input);
            cmd.Parameters.Add("telefoonnummer", OracleDbType.Varchar2, lid.TelefoonNummer, ParameterDirection.Input);
            cmd.Parameters.Add("adres", OracleDbType.Varchar2, lid.Adres, ParameterDirection.Input);
            cmd.Parameters.Add("postcode", OracleDbType.Varchar2, lid.Postcode, ParameterDirection.Input);
            cmd.Parameters.Add("woonplaats", OracleDbType.Varchar2, lid.Woonplaats, ParameterDirection.Input);
            cmd.Parameters.Add("rechten", OracleDbType.Varchar2, lid.Rechten.ToString(), ParameterDirection.Input);
            cmd.Parameters.Add("wachtwoord", OracleDbType.Varchar2, lid.Wachtwoord, ParameterDirection.Input);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Close();
        }


        public static void AddAanvraag(Lid lid)
        {
            try
            {
                conn.Close();
            }
            catch { }
            int lidnr = Get_New_LidNummer();
            cmd = new OracleCommand(@"INSERT INTO AANVRAAG(LIDNR,NAAM,GEBOORTEDATUM,GESLACHT,REKENINGNUMMER,TELEFOONNUMMER,ADRES,POSTCODE,WOONPLAATS,RECHT, WACHTWOORD) VALUES(:lidnr,:naam,:geboortedatum,:geslacht,:rekeningnummer,:telefoonnummer,:adres,:postcode, :woonplaats,UPPER(:rechten), :wachtwoord)",conn);
            //cmd.CommandText = "INSERT INTO AANVRAAG(LIDNR,NAAM,GEBOORTEDATUM,GESLACHT,REKENINGNUMMER,TELEFOONNUMMER,ADRES,POSTCODE,RECHTEN) VALUES(':lidnr',':naam',':geboortedatum',':geslacht',':rekeningnummer',':telefoonnummer',':adres',':postcode',':rechten'";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("lidnr", OracleDbType.Int32, lidnr, ParameterDirection.Input);
            cmd.Parameters.Add("naam", OracleDbType.Varchar2, lid.Naam, ParameterDirection.Input);
            cmd.Parameters.Add("geboortedatum", OracleDbType.TimeStamp, lid.Geboortedatum, ParameterDirection.Input);
            cmd.Parameters.Add("geslacht", OracleDbType.Varchar2, lid.Geslacht.ToString(), ParameterDirection.Input);
            cmd.Parameters.Add("rekeningnummer", OracleDbType.Varchar2, lid.RekeningNummer, ParameterDirection.Input);
            cmd.Parameters.Add("telefoonnummer", OracleDbType.Varchar2, lid.TelefoonNummer, ParameterDirection.Input);
            cmd.Parameters.Add("adres", OracleDbType.Varchar2, lid.Adres, ParameterDirection.Input);
            cmd.Parameters.Add("postcode", OracleDbType.Varchar2, lid.Postcode, ParameterDirection.Input);
            cmd.Parameters.Add("woonplaats", OracleDbType.Varchar2, lid.Woonplaats, ParameterDirection.Input);
            cmd.Parameters.Add("rechten", OracleDbType.Varchar2, lid.Rechten.ToString(), ParameterDirection.Input);
            cmd.Parameters.Add("wachtwoord", OracleDbType.Varchar2, lid.Wachtwoord, ParameterDirection.Input);
            Open();
            cmd.ExecuteNonQuery();
            Close();
            cmd.Parameters.Clear();
        }

        public static int Get_New_LidNummer()
        {
            conn.Open();
            int lidnr = 1;
            cmd = new OracleCommand("SELECT  GREATEST(MAX(LID.LIDNR),MAX(AANVRAAG.LIDNR)) + 1 AS VOLGENDELIDNR FROM LID,AANVRAAG", conn);
            rdr = cmd.ExecuteReader();
            try
            {
                if (rdr.Read())
                {
                    lidnr = Convert.ToInt32(rdr["VOLGENDELIDNR"]);
                }
            }
            catch
            {
                cmd = new OracleCommand("SELECT MAX(LIDNR) + 1 AS VOLGENDELIDNR FROM LID", conn);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lidnr = Convert.ToInt32(rdr["VOLGENDELIDNR"]);
                }
            }
            conn.Close();
            return lidnr;
        }

        public static void DeleteAanvraag(int nr)
        {
            cmd.CommandText = "DELETE FROM AANVRAAG WHERE LIDNR = " + nr;
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
                cmd.CommandText = @"SELECT * FROM NIEUWZBERICHT WHERE NIEUWSNR = " + nummer;
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
            cmd.ExecuteNonQuery();
            Close();
        }

        public static void SetTeam(int nr, string teamcode)
        {
            Lid lid = Database.GetAanvraag(nr);
            lid.TeamCode = teamcode;
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
                Open();
                int wedstrijdnr = 1;
                cmd.CommandText = "SELECT MAX(WEDSTRIJDNR) AS NR FROM WEDSTRIJD";
                rdr = cmd.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        wedstrijdnr = Convert.ToInt32(rdr["NR"]) + 1;
                    }
                }
                catch { wedstrijdnr = 1; }

                cmd.CommandText = @"INSERT INTO WEDSTRIJD(WEDSTRIJDNR, DATUM) VALUES("+ wedstrijdnr + " , '" +  datum.ToString("dd-MMM-yyyy") + "')";
                cmd.ExecuteNonQuery();

                if (thuis)
                {
                    cmd.CommandText = @"INSERT INTO THUISWEDSTRIJD(WEDSTRIJDNR,TEAMTHUIS,TEAMUIT) VALUES(" + wedstrijdnr + ",'" + basko + "','" + tegenstander + "')";
                    cmd.ExecuteNonQuery();
                    gelukt = true;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO UITWEDSTRIJD(WEDSTRIJDNR,TEAMTHUIS,TEAMUIT) VALUES(" + wedstrijdnr + ",'" + tegenstander + "','" + basko + "')";
                    cmd.ExecuteNonQuery();
                    gelukt = true;
                }
                Close();
            }
            catch { Close(); }

            return gelukt;
        }
    }
}