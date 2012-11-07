using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] slowa = new string[] { "Human", "Interface", "Computer", "User", "System", "Response", "Time", "EPS", "Survey", "Trees", "Graph", "Minors" };
            double[,] dane = new double[,] { { 1, 0, 0, 1, 0, 0, 0, 0, 0 }, { 1, 0, 1, 0, 0, 0, 0, 0, 0 }, { 1, 1, 0, 0, 0, 0, 0, 0, 0 }, { 0, 1, 1, 0, 1, 0, 0, 0, 0 }, { 0, 1, 1, 2, 0, 0, 0, 0, 0 }, { 0, 1, 0, 0, 1, 0, 0, 0, 0 }, { 0, 1, 0, 0, 1, 0, 0, 0, 0 }, { 0, 0, 1, 1, 0, 0, 0, 0, 0 }, { 0, 1, 0, 0, 0, 0, 0, 0, 1 }, { 0, 0, 0, 0, 0, 1, 1, 1, 0 }, { 0, 0, 0, 0, 0, 0, 1, 1, 1 }, { 0, 0, 0, 0, 0, 0, 0, 1, 1 } };
            double[,] u, vt, wynik;
            double[] w, srednie;
            alglib.rmatrixsvd(dane, 12, 9, 2, 2, 0, out w, out u, out vt);
            
            
            srednie = new double[9];
            double suma = 0;
            wynik = dane;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 12; j++)
                { 
                    suma += dane[j, i];
                }
                srednie[i] = suma / 9;
                suma = 0;
                for (int j = 0; j < 12; j++)
                {
                    wynik[j, i] = wynik[j, i] - srednie[i];
                }
            }
            double[] dlugosci_wektorow = new double[9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    dlugosci_wektorow[i] += Math.Pow(wynik[j, i], 2);
                }
                dlugosci_wektorow[i] = Math.Sqrt(dlugosci_wektorow[i]);
            }
            double[] iloczyny = new double[9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    iloczyny[i] = wynik[j, i];
                }
            }

            double[,] przed_svd = new double[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    przed_svd[i, j] = (dlugosci_wektorow[i] * dlugosci_wektorow[j]) / odleglosci[i, j];
                }
            }
            double[,] po_svd = new double[8, 8];
            double[] dl_po_svd = new double[9];
            for (int i = 0; i < 9; i++)
            {
                dl_po_svd[i] = Math.Sqrt(Math.Pow(vt[i, 0], 2) + Math.Pow(vt[i, 1], 2));
            }
            //double[,] odl_po_svd = new double[9, 9];


        }
    }
}
