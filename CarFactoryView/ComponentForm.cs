using CarFactoryContracts.BindingModels;
using CarFactoryContracts.BuisnessLogicsContracts;
using System;
using System.Windows.Forms;

namespace CarFactoryView
{
    public partial class ComponentForm : Form
    {
        public int Id { set { id = value; } }

        private readonly IComponentLogic _logic;

        private int? id;

        public ComponentForm(IComponentLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void ComponentForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new ComponentBindingModel { Id = id })?[0];
                    if(view != null)
                    {
                        textBoxComponentName.Text = view.ComponentName;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxComponentName.Text))
            {
                MessageBox.Show("Заполните название", "Ошиька", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new ComponentBindingModel
                {
                    Id = id,
                    ComponentName = textBoxComponentName.Text
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}