using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void FrmBanks_Load(object sender, EventArgs e)
        {

            // Banka bakiyeleri

            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "Vakıfbank").Select(y => y.BankBalance).FirstOrDefault();
            var isBankasiBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblisBankasiBalance.Text = isBankasiBalance.ToString() + " ₺";
            lblVakifbankBalance.Text = vakifBankBalance.ToString() + " ₺";
            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " ₺";

            // Banka hareketleri

            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = "1- " + bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = "2- " + bankProcess2.Description + " " + bankProcess2.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = "3- " + bankProcess3.Description + " " + bankProcess3.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = "4- " + bankProcess4.Description + " " + bankProcess4.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = "5- " + bankProcess5.Description + " " + bankProcess5.Amount + " " + bankProcess1.ProcessDate;
        }
    }
}
