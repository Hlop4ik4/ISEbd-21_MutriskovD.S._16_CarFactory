using System.Windows.Forms;
namespace CarFactoryView
{
    partial class FormCarComponent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelComponent = new System.Windows.Forms.Label();
            this.labelComponentCount = new System.Windows.Forms.Label();
            this.comboBoxComponents = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(26, 21);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(72, 15);
            this.labelComponent.TabIndex = 0;
            this.labelComponent.Text = "Компонент:";
            // 
            // labelComponentCount
            // 
            this.labelComponentCount.AutoSize = true;
            this.labelComponentCount.Location = new System.Drawing.Point(26, 51);
            this.labelComponentCount.Name = "labelComponentCount";
            this.labelComponentCount.Size = new System.Drawing.Size(75, 15);
            this.labelComponentCount.TabIndex = 0;
            this.labelComponentCount.Text = "Количество:";
            // 
            // comboBoxComponents
            // 
            this.comboBoxComponents.FormattingEnabled = true;
            this.comboBoxComponents.Location = new System.Drawing.Point(118, 18);
            this.comboBoxComponents.Name = "comboBoxComponents";
            this.comboBoxComponents.Size = new System.Drawing.Size(259, 23);
            this.comboBoxComponents.TabIndex = 1;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(118, 48);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(259, 23);
            this.textBoxCount.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(195, 77);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(288, 77);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormCarComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 114);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxComponents);
            this.Controls.Add(this.labelComponentCount);
            this.Controls.Add(this.labelComponent);
            this.Name = "FormCarComponent";
            this.Text = "Компонент автомобиля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelComponent;
        private Label labelComponentCount;
        private ComboBox comboBoxComponents;
        private TextBox textBoxCount;
        private Button buttonSave;
        private Button buttonCancel;
    }
}