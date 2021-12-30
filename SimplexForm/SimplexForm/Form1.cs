using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexForm
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        public class Kisit
        {
            public List<double> kisit = new List<double>();
            public double kisitDegeri;
            public double amacKatsayisi = 0;

        } 

        public class Simplex
        {
            public static int kisitSayisi;
            public static int degiskenSayisi;

            public List<double> cj = new List<double>();
            public List<double> zj = new List<double>();
            public double zjDegeri = 0;
            public List<double> optimumKontrolu = new List<double>();
            public int tabloSayisi = 0;

            public bool optimumMu;

            public int anahtarSutunIndex = 0;
            public int anahtarSatirIndex = 0;
            public double anahtarSayi;
            public List<double> anahtarSatir = new List<double>();

            public Kisit[] kisitlar = new Kisit[kisitSayisi];

            public Simplex(double[] _cj)
            {
                for (int i = 0; i < kisitSayisi; i++)
                {
                    kisitlar[i] = new Kisit();

                }
                cj.AddRange(_cj);
            }


            public void DolguEkle()
            {
                for (int i = 0; i < kisitSayisi; i++)
                {
                    for (int j = 0; j < kisitSayisi; j++)
                    {
                        if (j == i)
                        {
                            kisitlar[i].kisit.Add(1);
                            cj.Add(0);
                        }
                        else
                        {
                            kisitlar[i].kisit.Add(0);
                        }
                    }
                }


                for (int j = 0; j < kisitSayisi + degiskenSayisi; j++)
                {
                    zj.Add(0);
                    optimumKontrolu.Add(0);
                }

            }

            public void zjHesapla()
            {
                double toplam = 0;


                for (int j = 0; j < kisitSayisi + degiskenSayisi; j++)
                {
                    for (int k = 0; k < kisitSayisi; k++)
                    {
                        toplam = toplam + kisitlar[k].kisit[j] * kisitlar[k].amacKatsayisi;
                    }
                    zj[j] = toplam;
                    toplam = 0;
                }

                double temp = 0;
                for (int i = 0; i < kisitSayisi; i++)
                {
                    temp += kisitlar[i].kisitDegeri * kisitlar[i].amacKatsayisi;
                }
                zjDegeri = temp;


            }

            public bool OptimumHesapla()
            {
                double enBuyuk = 0;


                for (int i = 0; i < kisitSayisi + degiskenSayisi; i++)
                {
                    optimumKontrolu[i] = cj[i] - zj[i];
                }


                for (int i = 0; i < optimumKontrolu.Count; i++)
                {
                    if (optimumKontrolu[i] > enBuyuk)
                    {
                        enBuyuk = optimumKontrolu[i];
                    }

                }
                anahtarSutunIndex = optimumKontrolu.IndexOf(enBuyuk);

                for (int i = 0; i < kisitSayisi + degiskenSayisi; i++)
                {
                    if (optimumKontrolu[i] > 0)
                    {
                        optimumMu = false;
                        break;
                    }
                    else
                    {
                        optimumMu = true;
                    }

                }


                return optimumMu;

            }

            public void TabloOlustur()
            {
                DolguEkle();
                zjHesapla();
                OptimumHesapla();
                tabloSayisi++;
                

                do
                {
                    tabloSayisi++;
                    double enKucuk = kisitlar[0].kisit[anahtarSutunIndex];
                    for (int i = 0; i < kisitSayisi; i++)
                    {
                        if ((kisitlar[i].kisitDegeri / kisitlar[i].kisit[anahtarSutunIndex]) < enKucuk)
                        {
                            enKucuk = kisitlar[i].kisitDegeri / kisitlar[i].kisit[anahtarSutunIndex];
                            anahtarSatirIndex = i;
                        }
                    }

                    anahtarSayi = kisitlar[anahtarSatirIndex].kisit[anahtarSutunIndex];

                    List<double> temp = new List<double>();

                    for (int i = 0; i < kisitSayisi + degiskenSayisi; i++)
                    {
                        temp.Add(kisitlar[anahtarSatirIndex].kisit[i] / anahtarSayi);

                    }
                    temp.Add(kisitlar[anahtarSatirIndex].kisitDegeri / anahtarSayi);


                    double geciciAnahtarSayi = 0;



                    for (int i = 0; i < kisitSayisi; i++)
                    {
                        geciciAnahtarSayi = kisitlar[i].kisit[anahtarSutunIndex];

                        if (i != anahtarSatirIndex)
                        {
                            kisitlar[i].kisitDegeri = kisitlar[i].kisitDegeri - (temp[degiskenSayisi + kisitSayisi] * geciciAnahtarSayi);
                        }
                        else
                        {
                            kisitlar[i].kisitDegeri = kisitlar[i].kisitDegeri / anahtarSayi;
                        }
                        for (int j = 0; j < kisitSayisi + degiskenSayisi; j++)
                        {
                            if (i == anahtarSatirIndex)
                            {
                                kisitlar[i].kisit[j] = temp[j];

                            }
                            else
                            {
                                kisitlar[i].kisit[j] = kisitlar[i].kisit[j] - (temp[j] * geciciAnahtarSayi);
                            }
                        }
                    }

                    kisitlar[anahtarSatirIndex].amacKatsayisi = cj[anahtarSutunIndex];


                    zjHesapla();
                    OptimumHesapla();
                } while (!optimumMu);
            }



        }

        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        
        TextBox[] TextZmax;
        TextBox[,] textKisit;
        TextBox[] textKisitDegeri;
        private void button1_Click(object sender, EventArgs e)
        {
            
            Label[] LabelZmax;

            int kisitSayisi = int.Parse(kisit_txt.Text);
            int degiskenSayisi = int.Parse(degisken_txt.Text);

                      
            
            int left = 15;
            int top = 25;


            LabelZmax = new Label[degiskenSayisi];
            int x = 1;
            for (int i = 0; i < degiskenSayisi; i++)
            {
                LabelZmax[i] = new Label();
                LabelZmax[i].Left = left;
                LabelZmax[i].Top = top;
                LabelZmax[i].Width = 50;
                LabelZmax[i].Text = "x"+x;
                x++;
                groupBox1.Controls.Add(LabelZmax[i]);
                left += 50;
            }

            top +=25;
            left = 15;
            TextZmax = new TextBox[degiskenSayisi];
            
            for (int i = 0; i < degiskenSayisi; i++)
            {
                TextZmax[i] = new TextBox();
                TextZmax[i].Left = left;
                TextZmax[i].Top = top;
                TextZmax[i].Width = 50;
                x++;
                groupBox1.Controls.Add(TextZmax[i]);
                left += 50;
            }
            groupBox1.Visible = true;

            Label isaret = new Label();
            Label miktar = new Label();

            left = 15;
            top = 25;
            x = 1;
            for (int i = 0; i < degiskenSayisi + 2; i++)
            {
                if(i == degiskenSayisi)
                {
                    isaret.Left = left;
                    isaret.Top = top;
                    isaret.Width = 50;
                    isaret.Text = "İşaret";
                    groupBox2.Controls.Add(isaret);
                    left += 50;
                    continue;
                }
                if(i == degiskenSayisi + 1)
                {
                    miktar.Left = left;
                    miktar.Top = top;
                    miktar.Width = 50;
                    miktar.Text = "Miktar";
                    groupBox2.Controls.Add(miktar);
                    left += 50;
                    continue;
                }
                LabelZmax[i] = new Label();
                LabelZmax[i].Left = left;
                LabelZmax[i].Top = top;
                LabelZmax[i].Width = 50;
                LabelZmax[i].Text = "x" + x;
                x++;
                groupBox2.Controls.Add(LabelZmax[i]);
                left += 50;
            }
            

            left = 15;
            top += 25;
            
            TextBox textIsaret;
            textKisit = new TextBox[kisitSayisi,degiskenSayisi];
            textKisitDegeri = new TextBox[degiskenSayisi];

            int kisitDegeriSayaci = 0;
            for (int i = 0; i < kisitSayisi; i++)
            {
                for (int j = 0; j < degiskenSayisi + 2; j++)
                {
                    if (j == degiskenSayisi)
                    {
                        textIsaret = new TextBox();
                        textIsaret.Left = left;
                        textIsaret.Top = top;
                        textIsaret.Width = 50;
                        textIsaret.Text = "<=";
                        groupBox2.Controls.Add(textIsaret);
                        left += 50;
                        continue;

                    }
                    if (j == degiskenSayisi + 1)
                    {
                        textKisitDegeri[kisitDegeriSayaci] = new TextBox();
                        textKisitDegeri[kisitDegeriSayaci].Left = left;
                        textKisitDegeri[kisitDegeriSayaci].Top = top;
                        textKisitDegeri[kisitDegeriSayaci].Width = 50;
                        groupBox2.Controls.Add(textKisitDegeri[kisitDegeriSayaci]);
                        kisitDegeriSayaci++;
                        left += 50;
                        continue;

                    }
                    textKisit[i, j] = new TextBox();
                    textKisit[i, j].Left = left;
                    textKisit[i, j].Top = top;
                    textKisit[i, j].Width = 50;
                    groupBox2.Controls.Add(textKisit[i, j]);

                    left += 50;
                }
                top += 25;
                left = 15;
            }
            groupBox2.Visible = true;
            button2.Visible = true;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Simplex.kisitSayisi = int.Parse(kisit_txt.Text);
            Simplex.degiskenSayisi = int.Parse(degisken_txt.Text);
            double[] cj = new double[Simplex.degiskenSayisi];


            for (int i = 0; i < Simplex.degiskenSayisi; i++)
            {
                cj[i] = double.Parse(TextZmax[i].Text);
            }

            Simplex s = new Simplex(cj);
            for (int i = 0; i < Simplex.kisitSayisi; i++)
            {
                
                for (int j = 0; j < Simplex.degiskenSayisi; j++)
                {                   
                    s.kisitlar[i].kisit.Add(double.Parse(textKisit[i, j].Text));
                    
                    s.kisitlar[i].kisitDegeri = double.Parse(textKisitDegeri[i].Text);

                }
            }

            s.TabloOlustur();

            int left = 15;
            int top = 25;
            int x = 1;
            int degiskenSayisi = Simplex.degiskenSayisi;
            Label isaret = new Label();
            Label miktar = new Label();
            Label[] LabelZmax = new Label[degiskenSayisi];
            for (int i = 0; i < degiskenSayisi + 2; i++)
            {
                if (i == degiskenSayisi)
                {
                    isaret.Left = left;
                    isaret.Top = top;
                    isaret.Width = 50;
                    isaret.Text = "Zmax";
                    isaret.BackColor = Color.AntiqueWhite;
                    groupBox3.Controls.Add(isaret);
                    left += 50;
                    continue;
                }
                if (i == degiskenSayisi + 1)
                {
                    miktar.Left = left;
                    miktar.Top = top;
                    miktar.Width = 70;
                    miktar.Text = "Tablo Sayısı";
                    miktar.BackColor = Color.AntiqueWhite;
                    groupBox3.Controls.Add(miktar);
                    left += 50;
                    continue;
                }
                LabelZmax[i] = new Label();
                LabelZmax[i].Left = left;
                LabelZmax[i].Top = top;
                LabelZmax[i].Width = 50;
                LabelZmax[i].Text = "x" + x;
                LabelZmax[i].BackColor = Color.AntiqueWhite;
                x++;
                groupBox3.Controls.Add(LabelZmax[i]);
                left += 50;
            }
            top += 25;
            left = 15;
            Label Zmax = new Label();
            Label Tablo = new Label();
            Label[] LbllZmax = new Label[degiskenSayisi];
            for (int i = 0; i < degiskenSayisi + 2; i++)
            {
                if (i == degiskenSayisi)
                {
                    Zmax.Left = left;
                    Zmax.Top = top;
                    Zmax.Width = 50;
                    Zmax.Text = s.zjDegeri.ToString();
                    //Zmax.Text = s.kisitlar[1].kisitDegeri.ToString();
                    groupBox3.Controls.Add(Zmax);
                    left += 50;
                    continue;
                }
                if (i == degiskenSayisi + 1)
                {
                    Tablo.Left = left;
                    Tablo.Top = top;
                    Tablo.Width = 100;
                    Tablo.Text = s.tabloSayisi.ToString();
                    groupBox3.Controls.Add(Tablo);
                    left += 50;
                    continue;
                }
                LbllZmax[i] = new Label();
                LbllZmax[i].Left = left;
                LbllZmax[i].Top = top;
                LbllZmax[i].Width = 50;
                LbllZmax[i].Text = s.kisitlar[i].kisitDegeri.ToString();
                x++;
                groupBox3.Controls.Add(LbllZmax[i]);
                left += 50;
            }

            groupBox3.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
