using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AS2021_4H_SIR_BertozziMattia_Verificasottoreti
{
    public class Program
    {
        static void Main(string[] args)
        {
            string strNetwork = "192.168.1.0";
            string strSubnetMask = "255.255.255.0";

            string strIp = "192.167.1.20";
            //string ip = "192.110.12.60";
            //string ip = "200.110.12.100";

            Metodi m = new Metodi();

            List<string> Network = new List<string>(strNetwork.Split('.'));
            List<string> IP = new List<string>(strIp.Split('.'));
            List<string> SubnetMask = new List<string>(strSubnetMask.Split('.'));

            List<string> IP1binario = m.ConvertiABinario(IP);
            List<string> SubnetMaskbinario = m.ConvertiABinario(SubnetMask);

            List<string> RisultatoAnd = m.And(IP1binario,SubnetMaskbinario);

            List<string> AndDecimale = m.ToDec(RisultatoAnd);

            Console.WriteLine(m.VediLista(AndDecimale));

            bool Appartiene = m.AppartieneAllaRete(Network, AndDecimale);

            Console.WriteLine(Appartiene);
        }
    }

    public class Metodi
    {
        public List<string> ConvertiABinario(List<string> IP)
        {
            List<string> IPBinario = new List<string>();

            for(int i=0;i<IP.Count;i++)
            {
                string binario = "";

                int n = 7;

                double numero = Convert.ToDouble(IP[i]);

                for (int j = 0; j <= 7; j++)
                {
                    if (numero >= Math.Pow(2, n))
                    {
                        numero -= Math.Pow(2, n);
                        binario += "1";
                    }
                    else
                    {
                        binario += "0";
                    }
                    n--;
                }
                IPBinario.Add(binario);
            }
            return IPBinario;

        }

        //public List<string> SplittaIP(string IP)
        //{
        //    List<string> IPDiviso = new List<string>();

        //    string[] arrayIP = IP.Split(".");

        //    for (int i = 0; i < arrayIP.Length; i++)
        //    {
        //        IPDiviso.Add(arrayIP[i]);
        //    }

        //    return IPDiviso;
        //}

        public List<string> And(List<string> IP, List<string> SubnetMask)
        {
            List<string> Convertito = new List<string>();

            for (int i=0; i<IP.Count;i++)
            {
                string nbinarioIP = IP[i];
                string nbinarioSubnet = SubnetMask[i];

                string binario = "";

                for (int j=0;j< nbinarioIP.Length;j++)
                {
                    if (nbinarioIP[j] == '1')
                    {
                        if (nbinarioSubnet[j] == '1')
                        {
                            binario += "1";
                        }
                        else
                        {
                            binario += "0";
                        }
                    }
                    else
                    {
                        binario += "0";
                    }
                }
                Convertito.Add(binario);
            }

            return Convertito;
        }

        public List<string> ToDec(List<string> IP)
        {
            List<string> IPDecimale = new List<string>();

            for (int i = 0; i < IP.Count; i++)
            {
                string prova = Convert.ToInt32(IP[i], 2).ToString();
                IPDecimale.Add(prova);
            }

            return IPDecimale;
        }

        public string VediLista(List<string>IP)
        {
            string ip = ($"{IP[0]}.{IP[1]}.{IP[2]}.{IP[3]}");
            return ip;
        }

        public bool AppartieneAllaRete(List<string> Network, List<string> IPAnd)
        {
            bool flag=false;
            int i = 0;
            foreach(var n in Network)
            {
                if(n==IPAnd[i])
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
                i++;
            }
            return flag;
        }

    }
}
