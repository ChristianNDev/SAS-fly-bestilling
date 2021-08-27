using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace SAS
{
    public partial class ProgressThread : Form
    {
       
        public Action Worker { get; set; }
        CancellationTokenSource cts;
        public ProgressThread(Action worker)
        {
            InitializeComponent();

            if (worker == null) 
            
                throw new ArgumentNullException();
                Worker = worker;
           
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            MessageBox.Show("Du annulleret dit køb");
        }
        private void ProgressThread_Load(object sender, EventArgs e)
        {

        }
    }
}
