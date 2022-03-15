using CarFactoryContracts.BindingModels;
using CarFactoryContracts.BuisnessLogicsContracts;
using CarFactoryContracts.ViewModels;
using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace CarFactoryView
{
    public partial class FormCreateOrder : Form
    {
        private readonly ICarLogic _logicC;

        private readonly IOrderLogic _logicO;

        public FormCreateOrder(ICarLogic logicC, IOrderLogic logicO)
        {
            InitializeComponent();
            _logicC = logicC;
            _logicO = logicO;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<CarViewModel> listP = _logicC.Read(null);
                if (listP != null)
                {
                    comboBoxCar.DisplayMember = "CarName";
                    comboBoxCar.ValueMember = "Id";
                    comboBoxCar.DataSource = listP;
                    comboBoxCar.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if(comboBoxCar.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxCar.SelectedValue);
                    CarViewModel car = _logicC.Read(new CarBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * car?.Price ?? 0).ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Count", "Ошибка",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(comboBoxCar.SelectedValue == null)
            {
                MessageBox.Show("Выберите машину", "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    CarId = Convert.ToInt32(comboBoxCar.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
