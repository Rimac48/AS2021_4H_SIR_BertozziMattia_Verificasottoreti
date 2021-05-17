using Microsoft.VisualStudio.TestTools.UnitTesting;
using AS2021_4H_SIR_BertozziMattia_Verificasottoreti;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AS2021_4H_SIR_BertozziMattia_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            string strNetwork = "192.168.1.0";
            string strSubnetMask = "255.255.255.0";

            string strIp = "192.168.1.20";

            Metodi m = new Metodi();

            List<string> Network = new List<string>(strNetwork.Split('.'));
            List<string> IP = new List<string>(strIp.Split('.'));
            List<string> SubnetMask = new List<string>(strSubnetMask.Split('.'));

            List<string> IP1binario = m.ConvertiABinario(IP);
            List<string> SubnetMaskbinario = m.ConvertiABinario(SubnetMask);

            List<string> RisultatoAnd = m.And(IP1binario, SubnetMaskbinario);

            List<string> AndDecimale = m.ToDec(RisultatoAnd);

            bool Appartiene = m.AppartieneAllaRete(Network, AndDecimale);

            bool Aspettativa = true;

            Assert.AreEqual(Aspettativa, Appartiene, "l'IP non appartiene alla rete");


        }

        [TestMethod]
        public void Test2()
        {
            string strNetwork = "192.168.1.0";
            string strSubnetMask = "255.255.255.0";

            string strIp = "192.167.1.20";

            Metodi m = new Metodi();

            List<string> Network = new List<string>(strNetwork.Split('.'));
            List<string> IP = new List<string>(strIp.Split('.'));
            List<string> SubnetMask = new List<string>(strSubnetMask.Split('.'));

            List<string> IP1binario = m.ConvertiABinario(IP);
            List<string> SubnetMaskbinario = m.ConvertiABinario(SubnetMask);

            List<string> RisultatoAnd = m.And(IP1binario, SubnetMaskbinario);

            List<string> AndDecimale = m.ToDec(RisultatoAnd);

            bool Appartiene = m.AppartieneAllaRete(Network, AndDecimale);

            bool Aspettativa = false;

            Assert.AreEqual(Aspettativa, Appartiene, "l'IP non appartiene alla rete");
        }

        [TestMethod]
        public void Test3()
        {
            string strNetwork = "192.64.0.0";
            string strSubnetMask = "255.192.0.0";

            string strIp = "192.64.1.2";

            Metodi m = new Metodi();

            List<string> Network = new List<string>(strNetwork.Split('.'));
            List<string> IP = new List<string>(strIp.Split('.'));
            List<string> SubnetMask = new List<string>(strSubnetMask.Split('.'));

            List<string> IP1binario = m.ConvertiABinario(IP);
            List<string> SubnetMaskbinario = m.ConvertiABinario(SubnetMask);

            List<string> RisultatoAnd = m.And(IP1binario, SubnetMaskbinario);

            List<string> AndDecimale = m.ToDec(RisultatoAnd);

            bool Appartiene = m.AppartieneAllaRete(Network, AndDecimale);

            bool Aspettativa = true;

            Assert.AreEqual(Aspettativa, Appartiene, "l'IP non appartiene alla rete");
        }

        [TestMethod]
        public void Test4()
        {
            string strNetwork = "192.64.0.0";
            string strSubnetMask = "255.192.0.0";

            string strIp = "192.128.1.2";

            Metodi m = new Metodi();

            List<string> Network = new List<string>(strNetwork.Split('.'));
            List<string> IP = new List<string>(strIp.Split('.'));
            List<string> SubnetMask = new List<string>(strSubnetMask.Split('.'));

            List<string> IP1binario = m.ConvertiABinario(IP);
            List<string> SubnetMaskbinario = m.ConvertiABinario(SubnetMask);

            List<string> RisultatoAnd = m.And(IP1binario, SubnetMaskbinario);

            List<string> AndDecimale = m.ToDec(RisultatoAnd);

            bool Appartiene = m.AppartieneAllaRete(Network, AndDecimale);

            bool Aspettativa = false;

            Assert.AreEqual(Aspettativa, Appartiene, "l'IP non appartiene alla rete");
        }
    }
}
