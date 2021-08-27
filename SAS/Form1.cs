using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAS
{
    public partial class Form1 : Form
    {

      
        public Form1()
        {
            InitializeComponent();

        }



        int i = 0;
        infomation info = new infomation();
        private bool GodkendtClicked = false;
        rabatKupon RabatKup = new rabatKupon();
        flyPriser flyPris = new flyPriser();
        void DisplayData()
        {
            for (int i = 0; i <= 500; i++)
                Thread.Sleep(5);
        }
        void ProgressTrinket()
        {

            for (int i = 0; i <= 15; i++)
                Thread.Sleep(TimeSpan.FromMinutes(15));
            MessageBox.Show("Du har nu reserevet din pladser. GOD REJSE");
        }
        void lockseat()
        {

            string seats = txtPersoner.Text;
            lock (seats)
            {
                using (ProgressThread prog = new ProgressThread(ProgressTrinket))
                {

                    DialogResult dialogResult = MessageBox.Show("Din plads er nu reserevet. Din pladser er nu reseveret i 15 min", "Plads reservation:", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        prog.ShowDialog(this);
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                        if (GodkendtClicked == true)
                        {

                            MessageBox.Show("Du har annuleret dit køb");
                        }

                        MessageBox.Show("Du har annuleret din køb");
                    }
                }

            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (comboHvorfra.SelectedIndex > -1)
            {

                info.hvorfra = comboHvorfra.Text;
                info.hvorTil = comboHvortil.Text;


                info.HvorMange = txtPersoner.Text;
                info.hvorfra = tab2txtHvorFra.Text;
                info.hvorTil = tab2txtHvorHen.Text;

                info.HvorMange = tab2txtPersoner.Text;
                info.navn = txtNavn.Text;
                info.efternavn = txtEfternavn.Text;


                //Tilføjer data til tab2
                tab2txtHvorFra.Text = comboHvortil.Text;
                tab2txtHvorHen.Text = comboHvorfra.Text;
                tab2txtDatoFra.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
                tab2txtDatoTil.Text = monthCalendar2.SelectionRange.Start.ToShortDateString();
                tab2txtPersoner.Text = txtPersoner.Text;
                tab2Navn.Text = txtNavn.Text;
                tab2Efternavn.Text = txtEfternavn.Text;
                tabControl1.SelectedIndex = 1;

                lPersoner.Text = tab2txtPersoner.Text + " Personer";
                lPersoner1.Text = tab2txtPersoner.Text + " Personer";


            }
            else
            {

                error.SetError(comboHvorfra, "Udfyld de tomme felter");
            }

            switch (cKupon.SelectedIndex)
            {
                case 0:
                     LPris.Text = (flyPris.pris1 - RabatKup.standardKunder) + " DKK,-".ToString();
                    break;

                case 1:
                    LPris1.Text = (flyPris.pris2 - RabatKup.premium) + " DKK,-".ToString();

                    break;
                case 2:
                    LPris2.Text = (flyPris.pris3 - RabatKup.CustomKunder) + " DKK,-".ToString();
                    break;
            }

        }
        private void btnBillgst_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 0;

        }
        private void btnBedst_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 1;
        }
        private void btnHurtigst_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 2;
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtDatoFra.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();

        }
        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtDatoTil.Text = monthCalendar2.SelectionRange.Start.ToShortDateString();
        }
        private void txtDatoFra_Click(object sender, System.EventArgs e)
        {
            if (txtDatoFra.Focused == true)
            {
                monthCalendar1.Visible = true;
            }
            else
            {
                monthCalendar1.Visible = true;
            }

        }

        private void txtDatoTil_Click(object sender, MouseEventArgs e)
        {
            if (txtDatoTil.Focused == true)
            {
                monthCalendar2.Visible = true;
            }
            else
            {
                monthCalendar2.Visible = true;
            }

        }
        private void cBoxBillgst_OnChange(object sender, EventArgs e)
        {


            if (cBoxBillgst.Checked == true)
            {
                //Hvis Billgst checkbox er checked
                //Loader den data fra display data / Progressthread
                using (ProgressThread prog = new ProgressThread(DisplayData))
                {

                    prog.ShowDialog(this);
                    tabControl2.SelectedIndex = 0;


                    #region Design
                    //Design dialog box 1

                    //Rejse dertil

                    LRejsefraLand.Visible = true;
                    lRejseFraTid.Visible = true;
                    LRejsetid.Visible = true;
                    LRejseTilTid.Visible = true;
                    LRejseTilSted.Visible = true;
                    TilFraBy.Visible = true;
                    PTab31.Visible = true;
                    lFraBy.Visible = true;
                    LRejseHjemTid.Visible = true;
                    LRejseHjemTid1.Visible = true;

                    //Hjemrejse 
                    LhjemLand.Visible = true;
                    LhjemTid.Visible = true;
                    LhjemBy.Visible = true;
                    LRejseTidHjem.Visible = true;
                    LRejseLandHjem.Visible = true;
                    LRejseByHjem.Visible = true;

                    //Panel knap samt pris
                    btnBillgst1.Visible = true;
                    LPris.Visible = true;
                    tabControl2.Visible = true;
                    Tab3Panel1.Visible = true;
                    cBoxBedst.Checked = false;
                    cBoxHurtigst.Checked = false;

                    /////////////////////////////////////////////////
                    //Design dialog box 2

                    //Rejse dertil

                    LRejsefraLand1.Visible = true;
                    lRejseFraTid1.Visible = true;
                    LRejsetid1.Visible = true;
                    LRejseTilTid1.Visible = true;
                    LRejseTilSted1.Visible = true;
                    TilFraBy1.Visible = true;
                    PTab31.Visible = true;
                    lFraBy1.Visible = true;
                    LPris1.Visible = true;

                    //Hjemrejse 
                    LhjemLand1.Visible = true;
                    LhjemTid1.Visible = true;
                    LhjemBy1.Visible = true;
                    LRejseTidHjem1.Visible = true;
                    LRejseLandHjem1.Visible = true;
                    LRejseByHjem1.Visible = true;
                    //Panel knap samt pris
                    btnBillgst1.Visible = true;
                    LPris.Visible = true;
                    tabControl2.Visible = true;
                    Tab3Panel1.Visible = true;
                    PTab32.Visible = true;



                    /////////////////////////////////////////////////
                    //Design dialog box 3

                    //Rejse dertil

                    LRejsefraLand2.Visible = true;
                    lRejseFraTid2.Visible = true;
                    LRejsetid2.Visible = true;
                    LRejseTilTid2.Visible = true;
                    LRejseTilSted2.Visible = true;
                    TilFraBy2.Visible = true;
                    PTab33.Visible = true;
                    lFraBy2.Visible = true;


                    //Hjemrejse 
                    LhjemLand2.Visible = true;
                    LhjemTid2.Visible = true;
                    LhjemBy2.Visible = true;

                    LRejseTidHjem2.Visible = true;
                    LRejseLandHjem2.Visible = true;
                    LRejseByHjem2.Visible = true;
                    LRejseHjemTid2.Visible = true;
                    //Panel knap samt pris

                    LPris2.Visible = true;
                    Tab3Panel2.Visible = true;
                    Tab3Panel3.Visible = true;

                    /////////////////////////////////////////////////
                    //Design dialog box 3

                    //Rejse dertil

                    LRejsefraLand3.Visible = true;
                    lRejseFraTid3.Visible = true;
                    LRejsetid3.Visible = true;
                    LRejseTilTid3.Visible = true;
                    LRejseTilSted3.Visible = true;
                    TilFraBy3.Visible = true;
                    PTab34.Visible = true;
                    lFraBy3.Visible = true;


                    //Hjemrejse 
                    LhjemLand3.Visible = true;
                    LhjemTid3.Visible = true;
                    LhjemBy3.Visible = true;

                    LRejseTidHjem3.Visible = true;
                    LRejseLandHjem3.Visible = true;
                    LRejseByHjem3.Visible = true;
                    LRejseHjemTid3.Visible = true;
                    //Panel knap samt pris

                    LPris3.Visible = true;
                    Tab3Panel3.Visible = true;
                    Tab3Panel4.Visible = true;


                    //Uncheck & check design

                    cBoxBedst.Checked = false;
                    cBoxHurtigst.Checked = false;


                    //Knapper
                    btnBillgst1.Visible = true;
                    btnBillgst2.Visible = true;
                    btnBillgst3.Visible = true;
                    btnBillgst4.Visible = true;

                    //Icon
                    Icon1.Visible = true;
                    Icon2.Visible = true;
                    Icon3.Visible = true;
                    Icon4.Visible = true;
                    Icon5.Visible = true;
                    Icon6.Visible = true;
                    Icon7.Visible = true;
                    Icon8.Visible = true;

                    //Status bar direkte/ikke diretke
                    tab3ProgressBar1.Visible = true;
                    tab3ProgressBar2.Visible = true;
                    tab3ProgressBar3.Visible = true;
                    tab3ProgressBar4.Visible = true;
                    tab3ProgressBar5.Visible = true;
                    tab3ProgressBar6.Visible = true;
                    tab3ProgressBar7.Visible = true;
                    tab3ProgressBar8.Visible = true;


                #endregion
                }

            }

        }
        private void cBoxBedst_OnChange(object sender, EventArgs e)
        {

            if (cBoxBedst.Checked == true)
            {
                using (ProgressThread prog = new ProgressThread(DisplayData))
                {

                    prog.ShowDialog(this);

                    tabControl2.SelectedIndex = 1;
                    cBoxBillgst.Checked = false;
                    cBoxHurtigst.Checked = false;

                    //Design
                    PictureBedst1.Visible = true;
                    PanelBedst1.Visible = true;
                    BedstePrisLabel2.Visible = true;
                    btnBedst1.Visible = true;
                    PanelBedstMain1.Visible = true;
                    BedstePrisLabel1.Visible = true;

                    //Design boks 2
                    PictureBedst2.Visible = true;
                    PanelBedst2.Visible = true;
                    btnBedst2.Visible = true;
                    PanelBedstMain2.Visible = true;
                    BedstePrisLabel2.Visible = true;

                    //Design boks 3
                    PictureBedst3.Visible = true;
                    PanelBedst3.Visible = true;
                    btnBedst3.Visible = true;
                    PanelBedstMain3.Visible = true;
                    BedstePrisLabel3.Visible = true;

                }

            }


        }

        private void cBoxHurtigst_OnChange(object sender, EventArgs e)
        {

            if (cBoxHurtigst.Checked == true)
            {



                using (ProgressThread prog = new ProgressThread(DisplayData))
                {

                    prog.ShowDialog(this);

                    tabControl2.SelectedIndex = 2;
                    cBoxBillgst.Checked = false;
                    cBoxBedst.Checked = false;

                    //Design
                    hurtigtPic1.Visible = true;
                    hurtigtPic2.Visible = true;
                    hurtigtPic3.Visible = true;

                    hurtigtBtn1.Visible = true;
                    hurtigtBtn2.Visible = true;
                    hurtigtBtn3.Visible = true;

                    hurtigPanel1.Visible = true;
                    hurtigPanel2.Visible = true;
                    hurtigPanel3.Visible = true;

                    HurtigtPanelMain1.Visible = true;
                    HurtigtPanelMain2.Visible = true;
                    HurtigtPanelMain3.Visible = true;


                }
            }

        }


        private void btnBillgst1_Click(object sender, EventArgs e)
        {

            adminAntalPersoner.Text = tab2txtPersoner.Text;
            AdminNavn.Text = tab2Navn.Text;
            adminEfternavn.Text = tab2Efternavn.Text;
            tabControl1.SelectedIndex = 2;
            
        }

        private void txtDatoFra_Click(object sender, MouseEventArgs e)
        {
            if (txtDatoFra.Focused == true)
            {
                monthCalendar1.Visible = true;
            }
            else
            {
                monthCalendar1.Visible = true;
            }
        }
        
        private void flyReserver_Click(object sender, EventArgs e)
        {
            GodkendtClicked = true;

        }

        private void paymentPay_Click(object sender, EventArgs e)
        {



            string seats = txtPersoner.Text;
            int y = 0;
            switch (seats)
            {
                case "1":
                    if (GodkendtClicked == true)
                    {
                        lockseat();
                        Flybtn1.BackColor = Color.Red;
                        AdminNavn.Text = tab2Navn.Text;
                        adminEfternavn.Text = tab2Efternavn.Text;
                        adminAntalPersoner.Text = tab2txtPersoner.Text;

                    }
                    break;
                case "2":
                    if (GodkendtClicked == true)
                    {
                        lockseat();
                        Flybtn2.BackColor = Color.Red;
                        Flybtn3.BackColor = Color.Red;
                        AdminNavn.Text = tab2Navn.Text;
                        adminEfternavn.Text = tab2Efternavn.Text;
                        adminAntalPersoner.Text = tab2txtPersoner.Text;
                    }
                    break;
                case "3":
                    if (GodkendtClicked == true)
                    {
                        lockseat();
                        Flybtn4.BackColor = Color.Red;
                        Flybtn5.BackColor = Color.Red;
                        Flybtn6.BackColor = Color.Red;
                        AdminNavn.Text = tab2Navn.Text;
                        adminEfternavn.Text = tab2Efternavn.Text;
                        adminAntalPersoner.Text = tab2txtPersoner.Text;
                    }
                    break;
                case "4":
                    MessageBox.Show("Der er desværre ikke flere pladser tilbage");
                    tabControl1.SelectedIndex = 0;
                    break;
            }
            if (string.IsNullOrEmpty(paymentCardNumber.Text))
            {
                errorCardnr.SetError(paymentCardNumber, "Udfyld de tomme felter");
            }
            else
            {
                errorCardnr.SetError(paymentCardNumber, "");
            }
            if (paymentMonth.SelectedIndex > -0)
            {
                errorExpriration.SetError(paymentMonth, "Udfyld de tomme felter");
            }
            else
            {
                errorExpriration.SetError(paymentMonth, "");
            }
            if (paymentYear.SelectedIndex > -0)
            {
                errorExpirationYear.SetError(paymentYear, "Udfyld de tomme felter");

            }
            else
            {
                errorExpirationYear.SetError(paymentYear, "");
            }
            if (string.IsNullOrWhiteSpace(paymentCode.Text))
            {
                errorSecurtiyCode.SetError(paymentCode, "Udfyld Sikkerheds koden");

            }
            else
            {
                errorSecurtiyCode.SetError(paymentCode, "");
            }
            if (string.IsNullOrWhiteSpace(paymentCardholderName.Text))
            {
                errorCardholder.SetError(paymentCardholderName, "Udfyld dit navn der står på kortet.");
            }
            else
            {
                errorCardholder.SetError(paymentCardholderName, "");
            }
        }
        
        private void btnBillgst2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            adminAntalPersoner.Text = tab2txtPersoner.Text;
            AdminNavn.Text = tab2Navn.Text;
            adminEfternavn.Text = tab2Efternavn.Text;

        }

        private void btnBillgst3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            adminAntalPersoner.Text = tab2txtPersoner.Text;
            AdminNavn.Text = tab2Navn.Text;
            adminEfternavn.Text = tab2Efternavn.Text;

        }

        private void paymentCreditLabel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void paymentCancel_Click(object sender, EventArgs e)
        {
            GodkendtClicked = true;
        }

        private void cKupon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}