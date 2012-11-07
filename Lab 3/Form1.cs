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

            double[,] iloczyn_wektorow = new double[9, 9];
            double iloczyn = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    for (int k = 0; k < 12; k++)
                    {
                        iloczyn = wynik[k, i] * wynik[k, j];
                        iloczyn_wektorow[i, j] += iloczyn;
                    }
                    
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

            double[,] przed_svd = new double[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    przed_svd[i, j] = iloczyn_wektorow[i, j] / (dlugosci_wektorow[i] * dlugosci_wektorow[j]);
                }
            }
            string[] do_wyswietlenia = new string[9] { "C2", "C3", "C4", "C5", "M1", "M2", "M3", "M4", "0" };
            textBox2.Text = "Przed zastosowaniem SVD:\r\n";
            textBox2.Text += "      C1  ||  C2  ||  C3  ||  C4  ||  C5  ||  M1  ||  M2  ||  M3\r\n";

            textBox2.Text += do_wyswietlenia[0] + "  ";
            textBox2.Text += Math.Round(przed_svd[0, 1], 2);    
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[1] + "  ";
            textBox2.Text += Math.Round(przed_svd[0, 2], 2) + "  " + Math.Round(przed_svd[1, 2], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[2] + "  ";
            textBox2.Text += Math.Round(przed_svd[0, 3], 2) + "  " + Math.Round(przed_svd[1, 3], 2) + "  " + Math.Round(przed_svd[2, 3], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[3] + "  ";
            textBox2.Text += Math.Round(przed_svd[0, 4], 2) + "  " + Math.Round(przed_svd[1, 4], 2) + " " + Math.Round(przed_svd[2, 4], 2) + " " + Math.Round(przed_svd[3, 4], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[4] + "  ";
            textBox2.Text += Math.Round(przed_svd[0, 5], 2) + " " + Math.Round(przed_svd[1, 5], 2) + " " + Math.Round(przed_svd[2, 5], 2) + " " + Math.Round(przed_svd[3, 5], 2) + " " + Math.Round(przed_svd[4, 5], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[5] + "  ";
            textBox2.Text += Math.Round(przed_svd[0, 6], 2) + " " + Math.Round(przed_svd[1, 6], 2) + " " + Math.Round(przed_svd[2, 6], 2) + " " + Math.Round(przed_svd[3, 6], 2) + " " + Math.Round(przed_svd[4, 6], 2) + " " + Math.Round(przed_svd[5, 6], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[6] + "  ";
            textBox2.Text += Math.Round(przed_svd[0, 7], 2) + " " + Math.Round(przed_svd[1, 7], 2) + " " + Math.Round(przed_svd[2, 7], 2) + " " + Math.Round(przed_svd[3, 7], 2) + " " + Math.Round(przed_svd[4, 7], 2) + " " + Math.Round(przed_svd[5, 7], 2) + " " + Math.Round(przed_svd[6, 7], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[7] + "  ";
            textBox2.Text += Math.Round(przed_svd[0, 8], 2) + " " + Math.Round(przed_svd[1, 8], 2) + " " + Math.Round(przed_svd[2, 8], 2) + " " + Math.Round(przed_svd[3, 8], 2) + " " + Math.Round(przed_svd[4, 8], 2) + " " + Math.Round(przed_svd[5, 8], 2) + " " + Math.Round(przed_svd[6, 8], 2) + " " + Math.Round(przed_svd[7, 8], 2);
            textBox2.Text += "\r\n";
            

            // po svd
            double[,] po_svd = new double[9, 9];
            double x = 0;
            for (int i = 0; i < 9 ; i++)
                for (int j = i + 1; j < 9; j++)
                {
                    x = vt[i, j];
                    vt[i, j] = vt[j, i];
                    vt[j, i] = x;
                }

            double[,] nowe_u = new double[2, 12];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 12; j++) nowe_u[i, j] = u[j, i];
            double[,] nowe_vt = new double[9, 2];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 2; j++) nowe_vt[i, j] = vt[j, i];
            double[,] nowe_w = new double[2, 2];
            nowe_w[0, 0] = w[0];
            nowe_w[0, 1] = w[1];
            nowe_w[1, 0] = w[2];
            nowe_w[1, 1] = w[3];
            double[,] u_w = new double[12, 2];
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 2; j++)
                    for (int k = 0; k < 2; k++)
                    u_w[i, j] += nowe_u[k, i] * nowe_w[k, j];

            double[,] u_w_vt = new double[12, 9];
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 9; j++)
                    for (int k = 0; k < 2; k++)
                        u_w_vt[i, j] += u_w[i, k] * nowe_vt[j, k];
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    for (int k = 0; k < 12; k++)
                    {
                        iloczyn = u_w_vt[k, i] * u_w_vt[k, j];
                        iloczyn_wektorow[i, j] += iloczyn;
                    }
                    
                }

            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    dlugosci_wektorow[i] += Math.Pow(u_w_vt[j, i], 2);
                }
                dlugosci_wektorow[i] = Math.Sqrt(dlugosci_wektorow[i]);
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    po_svd[i, j] = iloczyn_wektorow[i, j] / (dlugosci_wektorow[i] * dlugosci_wektorow[j]);
                }
            }
            textBox2.Text += "\r\n";
            textBox2.Text += "\r\n";
            textBox2.Text += "\r\n";
            textBox2.Text += "Po zastosowaniu SVD:\r\n";
            textBox2.Text += "      C1  ||  C2  ||  C3  ||  C4  ||  C5  ||  M1  ||  M2  ||  M3\r\n";

            textBox2.Text += do_wyswietlenia[0] + "  ";
            textBox2.Text += Math.Round(po_svd[0, 1], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[1] + "  ";
            textBox2.Text += Math.Round(po_svd[0, 2], 2) + "  " + Math.Round(po_svd[1, 2], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[2] + "  ";
            textBox2.Text += Math.Round(po_svd[0, 3], 2) + "  " + Math.Round(po_svd[1, 3], 2) + "  " + Math.Round(po_svd[2, 3], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[3] + "  ";
            textBox2.Text += Math.Round(po_svd[0, 4], 2) + "  " + Math.Round(po_svd[1, 4], 2) + " " + Math.Round(po_svd[2, 4], 2) + " " + Math.Round(po_svd[3, 4], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[4] + "  ";
            textBox2.Text += Math.Round(po_svd[0, 5], 2) + " " + Math.Round(po_svd[1, 5], 2) + " " + Math.Round(po_svd[2, 5], 2) + " " + Math.Round(po_svd[3, 5], 2) + " " + Math.Round(po_svd[4, 5], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[5] + "  ";
            textBox2.Text += Math.Round(po_svd[0, 6], 2) + " " + Math.Round(po_svd[1, 6], 2) + " " + Math.Round(po_svd[2, 6], 2) + " " + Math.Round(po_svd[3, 6], 2) + " " + Math.Round(po_svd[4, 6], 2) + " " + Math.Round(po_svd[5, 6], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[6] + "  ";
            textBox2.Text += Math.Round(po_svd[0, 7], 2) + " " + Math.Round(po_svd[1, 7], 2) + " " + Math.Round(po_svd[2, 7], 2) + " " + Math.Round(po_svd[3, 7], 2) + " " + Math.Round(po_svd[4, 7], 2) + " " + Math.Round(po_svd[5, 7], 2) + " " + Math.Round(po_svd[6, 7], 2);
            textBox2.Text += "\r\n";

            textBox2.Text += do_wyswietlenia[7] + "  ";
            textBox2.Text += Math.Round(po_svd[0, 8], 2) + " " + Math.Round(po_svd[1, 8], 2) + " " + Math.Round(po_svd[2, 8], 2) + " " + Math.Round(po_svd[3, 8], 2) + " " + Math.Round(po_svd[4, 8], 2) + " " + Math.Round(po_svd[5, 8], 2) + " " + Math.Round(po_svd[6, 8], 2) + " " + Math.Round(po_svd[7, 8], 2);
            textBox2.Text += "\r\n";
        }
    }
}
