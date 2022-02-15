using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarFactoryContracts.BuisnessLogicsContracts;
using CarFactoryContracts.ViewModels;

namespace CarFactoryView
{
    public partial class FormCarComponent : Form
    {
        public int Id { get { return Convert.ToInt32(comboBoxComponents.SelectedValue); } set { comboBoxComponents.SelectedValue = value; } }

        public string ComponentName { get { return comboBoxComponents.Text; } }

        public int Count { get { return Convert.ToInt32(textBoxCount.Text); } set { textBoxCount.Text = value.ToString(); } }

        public FormCarComponent(IComponentLogic logic)
        {
            InitializeComponent();

            List<ComponentViewModel> list = logic.Read(null);
            if(list != null)
            {
                comboBoxComponents.DisplayMember = "ComponentName";
                comboBoxComponents.ValueMember = "Id";
                comboBoxComponents.DataSource = list;
                comboBoxComponents.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Count", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(comboBoxComponents.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
