using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USStockTrading
{
    public partial class SymbolListForm : Form
    {
        public SymbolListForm()
        {
            InitializeComponent();
            LoadSymbols();
        }

        private void LoadSymbols()
        {
            // 事前に入力されたシンボルと会社名をDataGridViewに追加
            dataGridView1.Rows.Add("AAPL", "Apple");
            dataGridView1.Rows.Add("GOOGL", "Google");
            dataGridView1.Rows.Add("AMZN", "Amazon");
            dataGridView1.Rows.Add("MSFT", "Microsoft");
            dataGridView1.Rows.Add("FB", "Meta Platforms (Facebook)");
            dataGridView1.Rows.Add("TSLA", "Tesla");
            dataGridView1.Rows.Add("NVDA", "NVIDIA");
            dataGridView1.Rows.Add("BRK.B", "Berkshire Hathaway");
            dataGridView1.Rows.Add("V", "Visa");
            dataGridView1.Rows.Add("MA", "Mastercard");
            dataGridView1.Rows.Add("DIS", "Walt Disney");
            dataGridView1.Rows.Add("INTC", "Intel");
            dataGridView1.Rows.Add("CSCO", "Cisco Systems");
            dataGridView1.Rows.Add("PYPL", "PayPal");
            dataGridView1.Rows.Add("NFLX", "Netflix");
            dataGridView1.Rows.Add("HD", "Home Depot");
            dataGridView1.Rows.Add("KO", "Coca-Cola");
            dataGridView1.Rows.Add("PFE", "Pfizer");
            dataGridView1.Rows.Add("XOM", "ExxonMobil");
            dataGridView1.Rows.Add("JNJ", "Johnson & Johnson");
            dataGridView1.Rows.Add("WMT", "Walmart");
            dataGridView1.Rows.Add("MRK", "Merck");
            dataGridView1.Rows.Add("PEP", "PepsiCo");
            dataGridView1.Rows.Add("NKE", "Nike");
            dataGridView1.Rows.Add("GS", "Goldman Sachs");
            dataGridView1.Rows.Add("IBM", "IBM");
            dataGridView1.Rows.Add("T", "AT&T");
            dataGridView1.Rows.Add("VZ", "Verizon Communications");
            dataGridView1.Rows.Add("C", "Citigroup");
            dataGridView1.Rows.Add("F", "Ford Motor");
            dataGridView1.Rows.Add("GM", "General Motors");
            dataGridView1.Rows.Add("BA", "Boeing");
            dataGridView1.Rows.Add("CVX", "Chevron");
            dataGridView1.Rows.Add("LMT", "Lockheed Martin");
            dataGridView1.Rows.Add("MCD", "McDonald's");
            dataGridView1.Rows.Add("AMT", "American Tower");
            dataGridView1.Rows.Add("UPS", "United Parcel Service");
            dataGridView1.Rows.Add("CAT", "Caterpillar");
            dataGridView1.Rows.Add("GS", "Goldman Sachs");
            dataGridView1.Rows.Add("RTX", "Raytheon Technologies");
            dataGridView1.Rows.Add("SPG", "Simon Property Group");
            dataGridView1.Rows.Add("CVS", "CVS Health");
            dataGridView1.Rows.Add("ADBE", "Adobe");
            dataGridView1.Rows.Add("UNH", "UnitedHealth Group");
            dataGridView1.Rows.Add("TMO", "Thermo Fisher Scientific");
            dataGridView1.Rows.Add("TXN", "Texas Instruments");
            dataGridView1.Rows.Add("BMY", "Bristol-Myers Squibb");
            dataGridView1.Rows.Add("LLY", "Eli Lilly and Company");
            dataGridView1.Rows.Add("AMGN", "Amgen");
            dataGridView1.Rows.Add("ISRG", "Intuitive Surgical");
            dataGridView1.Rows.Add("MS", "Morgan Stanley");
            dataGridView1.Rows.Add("NSC", "Norfolk Southern");
            dataGridView1.Rows.Add("REGN", "Regeneron Pharmaceuticals");
            dataGridView1.Rows.Add("LULU", "Lululemon Athletica");
            dataGridView1.Rows.Add("ECL", "Ecolab");
            dataGridView1.Rows.Add("SHW", "Sherwin-Williams");
            dataGridView1.Rows.Add("GILD", "Gilead Sciences");
            dataGridView1.Rows.Add("CL", "Colgate-Palmolive");
            dataGridView1.Rows.Add("DE", "Deere & Company");
            dataGridView1.Rows.Add("COST", "Costco Wholesale");
            dataGridView1.Rows.Add("AON", "Aon");
            dataGridView1.Rows.Add("AMCR", "Amcor");
            dataGridView1.Rows.Add("HSY", "Hershey");
            dataGridView1.Rows.Add("ZTS", "Zoetis");
            dataGridView1.Rows.Add("STT", "State Street Corporation");
            dataGridView1.Rows.Add("TGT", "Target");
            dataGridView1.Rows.Add("MO", "Altria");
            dataGridView1.Rows.Add("EXC", "Exelon");
            dataGridView1.Rows.Add("FIS", "Fidelity National Information Services");
            dataGridView1.Rows.Add("MMC", "Marsh & McLennan");
            dataGridView1.Rows.Add("WM", "Waste Management");
            dataGridView1.Rows.Add("NEM", "Newmont Corporation");
            dataGridView1.Rows.Add("PGR", "Progressive");
            dataGridView1.Rows.Add("DHR", "Danaher");
            dataGridView1.Rows.Add("SYY", "Sysco");
            dataGridView1.Rows.Add("MO", "Altria");
            dataGridView1.Rows.Add("EQIX", "Equinix");
            dataGridView1.Rows.Add("O", "Realty Income");
            dataGridView1.Rows.Add("SCHW", "Charles Schwab");
            dataGridView1.Rows.Add("VLO", "Valero Energy");
            dataGridView1.Rows.Add("CB", "Chubb");
            dataGridView1.Rows.Add("PXD", "Pioneer Natural Resources");
            dataGridView1.Rows.Add("MSCI", "MSCI Inc.");
            dataGridView1.Rows.Add("WFC", "Wells Fargo");
            dataGridView1.Rows.Add("LVS", "Las Vegas Sands");
            dataGridView1.Rows.Add("KMB", "Kimberly-Clark");
            dataGridView1.Rows.Add("F", "Ford Motor");
            dataGridView1.Rows.Add("JCI", "Johnson Controls");
            dataGridView1.Rows.Add("NUE", "Nucor");
            dataGridView1.Rows.Add("SBUX", "Starbucks");
            dataGridView1.Rows.Add("DUK", "Duke Energy");
            dataGridView1.Rows.Add("MET", "MetLife");
            dataGridView1.Rows.Add("RSG", "Republic Services");
            dataGridView1.Rows.Add("CNP", "CenterPoint Energy");
            dataGridView1.Rows.Add("AIG", "American International Group");
            dataGridView1.Rows.Add("BAX", "Baxter International");
            dataGridView1.Rows.Add("VZ", "Verizon Communications");
            dataGridView1.Rows.Add("PRU", "Prudential Financial");
            dataGridView1.Rows.Add("XEL", "Xcel Energy");
            dataGridView1.Rows.Add("XRX", "Xerox");
            dataGridView1.Rows.Add("DTE", "DTE Energy");
            dataGridView1.Rows.Add("WEC", "WEC Energy Group");
            dataGridView1.Rows.Add("MDT", "Medtronic");
            dataGridView1.Rows.Add("LMT", "Lockheed Martin");
            dataGridView1.Rows.Add("DD", "DuPont");
            dataGridView1.Rows.Add("ADM", "Archer-Daniels-Midland");
            dataGridView1.Rows.Add("CDW", "CDW");
            dataGridView1.Rows.Add("IP", "International Paper");
            dataGridView1.Rows.Add("BBY", "Best Buy");
            dataGridView1.Rows.Add("HRL", "Hormel Foods");
            dataGridView1.Rows.Add("DOW", "Dow Inc.");
            dataGridView1.Rows.Add("STZ", "Constellation Brands");
            dataGridView1.Rows.Add("AVGO", "Broadcom");
            dataGridView1.Rows.Add("HCA", "HCA Healthcare");
            dataGridView1.Rows.Add("AFL", "Aflac");
            dataGridView1.Rows.Add("BMY", "Bristol-Myers Squibb");
            dataGridView1.Rows.Add("COF", "Capital One");
            dataGridView1.Rows.Add("WDC", "Western Digital");
            dataGridView1.Rows.Add("FFIV", "F5 Networks");
            dataGridView1.Rows.Add("VRSK", "Verisk Analytics");
            dataGridView1.Rows.Add("CSX", "CSX Corporation");
            dataGridView1.Rows.Add("LRCX", "Lam Research");
            dataGridView1.Rows.Add("MAA", "Mid-America Apartment Communities");
            dataGridView1.Rows.Add("DRE", "Duke Realty");
            dataGridView1.Rows.Add("PLD", "Prologis");
            dataGridView1.Rows.Add("RE", "Great West Lifeco");
            dataGridView1.Rows.Add("ARE", "Alexandria Real Estate Equities");

        }

        private void SymbolListForm_Load(object sender, EventArgs e)
        {

        }
    }
}