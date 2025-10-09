
using ConceptArchitect.CalculatorAPI;

namespace CalculatorDesktop
{
    public partial class Form1 : Form
    {
        Calculator calculator;
        public Form1()
        {
            InitializeComponent();

            var pluginPath= $"{AppDomain.CurrentDomain.BaseDirectory}/plugins";

            calculator = new CalculatorBuilder()
                            .AddResultFormatter((o1, opr, o2, result) => result.ToString())
                            .AddResultPresener(result=>resultTextBox.Text=result)
                            .AddPlugins(pluginPath)
                            .Build();


            //calculator.ResultPresenter= result=> resultTextBox.Text= result;
            //calculator.ErrorPresenter = error => MessageBox.Show(error, "Invalid Operator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //calculator.ResultFormatter = (op1, operatorName, op2, result) => result.ToString();
            
           

            foreach (var _operator in calculator.Operators)
                operatorList.Items.Add(_operator);
        
        }

        private void computeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var op1 = int.Parse(number1TextBox.Text);
                var op2 = int.Parse(number2TextBox.Text);
                //var operatorName = operatorTextBox.Text;
                var operatorName = operatorList.SelectedItem.ToString();
                calculator.Calculate(op1, operatorName, op2);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
