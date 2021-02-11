using Funzioni;
using System;
using System.IO;
using System.Windows.Forms;

namespace FORMBicicletteRota
{
    public partial class Form1 : Form
    {
        private Bicicletta[] eleBici = new Bicicletta[1000];
        private int num = 0;

        public Form1()
        {
            InitializeComponent();

            eleBici[0].matricola = "Bici Zero";
            eleBici[0].marca = "None";
            eleBici[0].categoria = "Mountain Bike";
            eleBici[0].telaio = "Carbonio";
            eleBici[0].prezzo = 200;
            eleBici[0].potenza = 60;
            eleBici[0].speed = 45;
            eleBici[0].autonomia = 125;
            eleBici[0].ruote = 22;
            num++;
            eleBici[1].matricola = "Bici Uno";
            eleBici[1].marca = "Merida";
            eleBici[1].categoria = "Mountain Bike";
            eleBici[1].telaio = "Acciaio";
            eleBici[1].prezzo = 300;
            eleBici[1].potenza = 100;
            eleBici[1].speed = 1000;
            eleBici[1].autonomia = 100;
            eleBici[1].ruote = 24;
            num++;
            eleBici[2].matricola = "Bici Due";
            eleBici[2].marca = "Kona";
            eleBici[2].categoria = "Bici da Corsa";
            eleBici[2].telaio = "Titanio";
            eleBici[2].prezzo = 400;
            eleBici[2].potenza = 40;
            eleBici[2].speed = 60;
            eleBici[2].autonomia = 70;
            eleBici[2].ruote = 26;
            num++;
        }

        private void btnInserisci_Click(object sender, EventArgs e)
        {
            if (num > 1000)
            {
                MessageBox.Show("Errore di elenco!", "Errore");
                return;
            }

            if (string.IsNullOrEmpty(txtMatricola.Text) || (string.IsNullOrEmpty(txtMarca.Text) || string.IsNullOrEmpty(cmbCate.Text) || string.IsNullOrEmpty(cmbTelaio.Text) || string.IsNullOrEmpty(txtPrezzo.Text) || string.IsNullOrEmpty(txtPotenza.Text) || string.IsNullOrEmpty(txtSpeed.Text) || string.IsNullOrEmpty(txtAuto.Text) || string.IsNullOrEmpty(cmbRuote.Text)))
            {
                MessageBox.Show("Inserire i dati mancanti!", "Errore");
                return;
            }

            Bicicletta nuovaBici = default(Bicicletta);

            if (nuovaBici.prezzo < 0)
            {
                MessageBox.Show("Prezzo troppo basso!", "Errore");
                return;
            }

            nuovaBici.matricola = txtMatricola.Text;
            nuovaBici.marca = txtMarca.Text;
            nuovaBici.categoria = cmbCate.Text;
            nuovaBici.telaio = cmbTelaio.Text;
            nuovaBici.prezzo = decimal.Parse(txtPrezzo.Text);
            nuovaBici.potenza = decimal.Parse(txtPotenza.Text);
            nuovaBici.speed = decimal.Parse(txtSpeed.Text);
            nuovaBici.autonomia = int.Parse(txtAuto.Text);
            nuovaBici.ruote = int.Parse(cmbRuote.Text);

            eleBici[num] = nuovaBici;
            num++;

            txtMatricola.Clear();
            txtMarca.Clear();
            cmbCate.Items.Clear();
            cmbTelaio.Items.Clear();
            txtPrezzo.Clear();
            txtPotenza.Clear();
            txtSpeed.Clear();
            txtAuto.Clear();
            cmbRuote.Items.Clear();
        }

        private void btnVisualizza_Click(System.Object sender, System.EventArgs e)
        {
            if (!(rdbtnRuote.Checked == true || rdbtnCate.Checked == true))
            {
                return;
            }

            int x = 0;

            if (rdbtnRuote.Checked == true)
            {
                MyLibrary.OrdinamentoRuote(eleBici, num);
            }

            if (rdbtnCate.Checked == true)
            {
                MyLibrary.OrdinamentoCate(eleBici, num);
            }

            ListViewItem riga = default(ListViewItem);
            listView1.Items.Clear();

            x = 0;

            while (x < num)
            {
                riga = new ListViewItem(new string[]
                    { eleBici[x].matricola,
                      eleBici[x].marca,
                      eleBici[x].categoria,
                      eleBici[x].telaio,
                      eleBici[x].potenza.ToString(),
                      eleBici[x].speed.ToString(),
                      eleBici[x].potenza.ToString(),
                      eleBici[x].prezzo.ToString(),
                      eleBici[x].ruote.ToString()}); ;
                listView1.Items.Add(riga);
                x = x + 1; ;
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
                return;

            StreamWriter mioFile;
            mioFile = new StreamWriter(System.IO.Path.Combine("@risorse", txtPathSalva.Text)); // Crea Cartella

            int x = 0;

            while (x < 0)
            {
                Bicicletta tmpProd = eleBici[x];
                mioFile.WriteLine(tmpProd.matricola);
                mioFile.WriteLine(tmpProd.marca);
                mioFile.WriteLine(tmpProd.categoria);
                mioFile.WriteLine(tmpProd.telaio);
                mioFile.WriteLine(tmpProd.prezzo);
                mioFile.WriteLine(tmpProd.potenza);
                mioFile.WriteLine(tmpProd.speed);
                mioFile.WriteLine(tmpProd.autonomia);
                mioFile.WriteLine(tmpProd.ruote);
                x++;
            }
            mioFile.Close();
            MessageBox.Show(string.Format($"Scritti {num} record su file"));
        }

        private void btnLeggi_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(System.IO.Path.Combine("@risorse", txtPath.Text)))
                return; // File Ignoto

            StreamReader mioFile;
            mioFile = new StreamReader(System.IO.Path.Combine("@risorse", txtPath.Text));

            int num = 0;

            while (num < 0 && mioFile.EndOfStream == false)
            {
                Bicicletta nuovaBici = default(Bicicletta);

                nuovaBici.matricola = mioFile.ReadLine();
                nuovaBici.marca = mioFile.ReadLine();
                nuovaBici.categoria = mioFile.ReadLine();
                nuovaBici.telaio = mioFile.ReadLine();
                nuovaBici.prezzo = decimal.Parse(mioFile.ReadLine());
                nuovaBici.potenza = decimal.Parse(mioFile.ReadLine());
                nuovaBici.speed = decimal.Parse(mioFile.ReadLine());
                nuovaBici.autonomia = int.Parse(mioFile.ReadLine());
                nuovaBici.ruote = int.Parse(mioFile.ReadLine());

                eleBici[num] = nuovaBici;
                num++;
            }

            mioFile.Close();
            MessageBox.Show(string.Format($"Letti {num} record su file"));
        }

        private void btnCerca_Click(System.Object sender, System.EventArgs e)
        {
            int K = 0;

            if (string.IsNullOrEmpty(txtCerca.Text))
                return;

            K = MyLibrary.Cerca(eleBici, num, txtCerca.Text);

            if (K == -1)
            {
                MessageBox.Show("Dato non trovato");
                return;
            }

            txtModiMarca.Text = eleBici[K].marca;
            txtModiPotenza.Text = eleBici[K].potenza.ToString();
            txtModiPrezzo.Text = eleBici[K].prezzo.ToString();
            cmbModiCate.SelectedItem = eleBici[K].categoria;
            cmbModiTelaio.SelectedItem = eleBici[K].telaio;
            txtModiSpeed.Text = eleBici[K].speed.ToString();
            txtModiAuto.Text = eleBici[K].autonomia.ToString();
            cmbModiRuote.SelectedItem = eleBici[K].ruote.ToString();

            btnModifica.Enabled = true;
        }

        private void btnCancella_Click(object sender, EventArgs e)
        {
            decimal inputPotenza = default;
            inputPotenza = decimal.Parse(txtCancellaPotenza.Text);

            if (string.IsNullOrEmpty(txtCancellaPotenza.ToString()))
            {
                MessageBox.Show("Inserire un valore di potenza!", "Errore");
                return;
            }

            if (num == 0)
            {
                MessageBox.Show("Non ci sono elementi da cancellare", "Errore");
                return;
            }

            if (num > 1000)
            {
                MessageBox.Show("Errore di elenco!", "Errore");
                return;
            }

            MyLibrary.CancellaPerPotenza(eleBici, ref num, inputPotenza);
            return;
        }

        private void CalcolaMassimo_Click(object sender, EventArgs e)
        {
            string telaioScelto = "";

            if (string.IsNullOrEmpty(cmbTelai.Text))
                return;

            telaioScelto = cmbTelai.Text;

            decimal biciMax = default(decimal);

            biciMax = MyLibrary.PrezzoMassimo(eleBici, num, telaioScelto);

            if (biciMax == -1)
            {
                MessageBox.Show("Elenco vuoto o telaio inesistente");
                return;
            }

            lbMassimo.Text = $"Valore massimo con telaio in {telaioScelto} : {biciMax.ToString()}";
        }

        private void CalcolaMedia_Click(object sender, EventArgs e)
        {
            string telaioScelto = "";
            decimal media = default;

            if (string.IsNullOrEmpty(cmbTelai.Text))
                return;

            telaioScelto = cmbTelai.Text;

            media = MyLibrary.MediaPrezzi(eleBici, num, telaioScelto);

            if (media == -1)
            {
                MessageBox.Show("Elenco vuoto o telaio inesistente");
                return;
            }

            lbMedia.Text = $"Valore medio dei telaio in {telaioScelto} : {media.ToString()}";
        }

        private void CalcolaMinimo_Click(object sender, EventArgs e)
        {
            string telaioScelto = "";

            if (string.IsNullOrEmpty(cmbTelai.Text))
                return;

            telaioScelto = cmbTelai.Text;

            decimal biciMin = default(decimal);

            biciMin = MyLibrary.PrezzoMinimo(eleBici, num, telaioScelto);

            if (biciMin == -1)
            {
                MessageBox.Show("Elenco vuoto o telaio inesistente");
                return;
            }

            lbMinimo.Text = $"Valore minimo con telaio in {telaioScelto} : {biciMin.ToString()}";
        }

        private void btnTotale_Click(System.Object sender, System.EventArgs e)
        {
            string cateScelta = "";

            cateScelta = cmbInputCate.Text;

            decimal totaleCate = default;

            totaleCate = MyLibrary.ValoreCategoria(eleBici, num, cateScelta);

            if (totaleCate <= 0)
            {
                MessageBox.Show("Archivio vuoto");
                return;
            }
            lbTotale.Text = $"Valore totale della categoria {cateScelta} : {totaleCate.ToString()}";
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            int k = 0;

            if (string.IsNullOrEmpty(txtModiMarca.Text) || string.IsNullOrEmpty(cmbModiCate.Text) || string.IsNullOrEmpty(cmbModiTelaio.Text) || string.IsNullOrEmpty(txtModiPrezzo.Text) || string.IsNullOrEmpty(txtModiPotenza.Text) || string.IsNullOrEmpty(txtModiSpeed.Text) || string.IsNullOrEmpty(txtModiAuto.Text) || string.IsNullOrEmpty(cmbModiRuote.Text))
            {
                MessageBox.Show("Inserire i dati mancanti!", "Errore");
                return;
            }

            k = MyLibrary.Cerca(eleBici, num, txtCerca.Text);

            if (k == -1)
            {
                MessageBox.Show("Dato non trovato");
                return;
            }

            Bicicletta modiBici = default(Bicicletta);

            modiBici.matricola = txtModiMatricola.Text;
            modiBici.marca = txtModiMarca.Text;
            modiBici.categoria = cmbModiCate.Text;
            modiBici.telaio = cmbModiTelaio.Text;
            modiBici.prezzo = decimal.Parse(txtModiPrezzo.Text);
            modiBici.potenza = decimal.Parse(txtModiPotenza.Text);
            modiBici.autonomia = int.Parse(txtModiAuto.Text);
            modiBici.ruote = int.Parse(cmbModiRuote.Text);
            modiBici.speed = int.Parse(txtModiSpeed.Text);

            eleBici[k] = modiBici;

            txtModiMatricola.Clear();
            txtModiMarca.Clear();
            txtModiPotenza.Clear();
            txtModiAuto.Clear();
            txtModiPrezzo.Clear();
            txtModiSpeed.Clear();
            cmbModiCate.Refresh();
            cmbModiRuote.Refresh();
            cmbModiTelaio.Refresh();

            btnModifica.Enabled = true;
        }

        private void MediaVelocità(object sender, EventArgs e)
        {
            decimal mediaVelocità = default;

            mediaVelocità = MyLibrary.MediaVelocità(eleBici, num);

            if (mediaVelocità == -1)
            {
                MessageBox.Show("Elenco vuoto o telaio inesistente");
                return;
            }

            lbMediaSpeed.Text = $"Valore medio delle velocità : {mediaVelocità.ToString()}";
        }

        private void btnMatSpeed_Click(object sender, EventArgs e)
        {
            decimal mediaVelocità = default;

            mediaVelocità = MyLibrary.MediaVelocità(eleBici, num);

            ListViewItem riga2 = default(ListViewItem);
            listView2.Items.Clear();

            int x = 0;

            while (x < num)
            {
                if (eleBici[x].speed < mediaVelocità)
                {
                    riga2 = new ListViewItem(new string[]
                        {
                        eleBici[x].matricola,
                        eleBici[x].speed.ToString()});
                    listView2.Items.Add(riga2);
                }
                x = x + 1;
            }
        }

        private void btnAutoMagg60_Click(object sender, EventArgs e)
        {
            ListViewItem riga3 = default(ListViewItem);
            listView3.Items.Clear();

            int x = 0;

            while (x < num)
            {
                if (eleBici[x].autonomia > 60)
                {
                    riga3 = new ListViewItem(new string[]
                        {
                      eleBici[x].matricola,
                      eleBici[x].marca,
                      eleBici[x].categoria,
                      eleBici[x].telaio,
                      eleBici[x].potenza.ToString(),
                      eleBici[x].speed.ToString(),
                      eleBici[x].autonomia.ToString(),
                      eleBici[x].prezzo.ToString(),
                      eleBici[x].ruote.ToString()});
                    listView3.Items.Add(riga3);
                }
                x = x + 1;
            }
        }

        private void btnVisualizzaPerPotenza_Click(object sender, EventArgs e)
        {
            decimal mediaPotenza = default;

            mediaPotenza = MyLibrary.MediaPotenza(eleBici, num);

            if (!(btnPotenzaMagg.Checked == true || btnPotenzaMin.Checked == true))
            {
                return;
            }

            int x = 0;

            ListViewItem riga4 = default(ListViewItem);
            listView4.Items.Clear();

            if (btnPotenzaMagg.Checked == true)
            {
                while (x < num)
                {
                    if (eleBici[x].potenza > mediaPotenza)
                    {
                        riga4 = new ListViewItem(new string[]
                            { eleBici[x].matricola,
                      eleBici[x].marca,
                      eleBici[x].categoria,
                      eleBici[x].telaio,
                      eleBici[x].potenza.ToString(),
                      eleBici[x].speed.ToString(),
                      eleBici[x].potenza.ToString(),
                      eleBici[x].prezzo.ToString(),
                      eleBici[x].ruote.ToString()});
                        listView4.Items.Add(riga4);
                        x = x + 1;
                    }
                }

                listView4.Items.Clear();

                if (btnPotenzaMin.Checked == true)
                {
                    while (x < num)
                    {
                        if (eleBici[x].potenza < mediaPotenza)
                        {
                            riga4 = new ListViewItem(new string[]
                                { eleBici[x].matricola,
                      eleBici[x].marca,
                      eleBici[x].categoria,
                      eleBici[x].telaio,
                      eleBici[x].potenza.ToString(),
                      eleBici[x].speed.ToString(),
                      eleBici[x].potenza.ToString(),
                      eleBici[x].prezzo.ToString(),
                      eleBici[x].ruote.ToString()});
                            listView4.Items.Add(riga4);
                            x = x + 1;
                        }
                    }
                }
            }
        }
    }
}