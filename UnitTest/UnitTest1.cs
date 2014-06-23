using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        int testnr = Database.Get_New_LidNummer();

        [TestMethod]
        public void VoegAanvraagToe()
        {
            Lid lid = new Lid(testnr, "Henk", DateTime.Today, Lid.EGeslacht.M, "798hyt878", "872340", "098u98", "9yfwe", "098", "JA1", 1, Lid.ERecht.Lid, "ww88");
            Database.AddAanvraag(lid);
            Assert.AreEqual("Henk", Database.GetAanvraag(testnr).Naam);
        }

        [TestMethod]
        public void VoegLidToe()
        {
            Lid lid = new Lid(testnr, "Henk", DateTime.Today, Lid.EGeslacht.M, "798hyt878", "872340", "098u98", "9yfwe", "1", "JA1", 1, Lid.ERecht.Lid, "ww88");
            Database.AddLid(lid);
            Assert.AreEqual("Henk", Database.GetLid(testnr).Naam);
        }
        
        [TestMethod]
        public void DeleteAanvraag()
        {
            Database.DeleteAanvraag(testnr);
        }
    }
}
