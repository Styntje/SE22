using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ontwikkelopdracht;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void VoegAanvraagToe()
        {
            Lid lid = new Lid(39, "Henk", DateTime.Today, Lid.EGeslacht.M, "798hyt878", "872340", "098u98", "9yfwe", "098", 1, Lid.ERecht.Lid, "ww88");
            Database.AddAanvraag(lid);
            Assert.AreEqual("Henk", Database.GetAanvraag(39).Naam);
        }

        [TestMethod]
        public void VoegLidToe()
        {
            Lid lid = new Lid(39, "Henk", DateTime.Today, Lid.EGeslacht.M, "798hyt878", "872340", "098u98", "9yfwe", "1", 1, Lid.ERecht.Lid, "ww88");
            Database.AddLid(lid);
            Assert.AreEqual("Henk", Database.GetLid(39).Naam);
        }
        
        [TestMethod]
        public void DeleteAanvraag()
        {
            Lid lid = new Lid(39, "Henk", DateTime.Today, Lid.EGeslacht.M, "798hyt878", "872340", "098u98", "9yfwe", "098", 1, Lid.ERecht.Lid, "ww88");
            Database.DeleteAanvraag(lid.LidNummer);
        }
    }
}
