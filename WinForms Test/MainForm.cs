using cAlgo.API;
using System.Windows.Forms;

namespace cAlgo
{
    public partial class MainForm : Form
    {
        private readonly Robot _robot;

        public MainForm(Robot robot)
        {
            InitializeComponent();

            _robot = robot;

            FormClosed += MainForm_FormClosed;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _robot.Stop();
        }

        private void BtnBuy_Click(object sender, System.EventArgs e)
        {
            _robot.ExecuteMarketOrder(TradeType.Buy, _robot.SymbolName, _robot.Symbol.VolumeInUnitsMin);
        }

        private void BtnSell_Click(object sender, System.EventArgs e)
        {
            _robot.ExecuteMarketOrder(TradeType.Sell, _robot.SymbolName, _robot.Symbol.VolumeInUnitsMin);
        }
    }
}