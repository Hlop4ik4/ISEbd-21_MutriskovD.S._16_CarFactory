using System.Windows.Forms;
namespace CarFactoryView
{
    partial class FormMain
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonUpdateList = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImplementersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentCarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.письмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 29);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(653, 328);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(659, 52);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(149, 23);
            this.buttonCreateOrder.TabIndex = 1;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(659, 97);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(149, 23);
            this.buttonIssuedOrder.TabIndex = 1;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonUpdateList
            // 
            this.buttonUpdateList.Location = new System.Drawing.Point(659, 143);
            this.buttonUpdateList.Name = "buttonUpdateList";
            this.buttonUpdateList.Size = new System.Drawing.Size(149, 23);
            this.buttonUpdateList.TabIndex = 1;
            this.buttonUpdateList.Text = "Обновить список";
            this.buttonUpdateList.UseVisualStyleBackColor = true;
            this.buttonUpdateList.Click += new System.EventHandler(this.buttonUpdateList_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guideToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.StartWorkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentsToolStripMenuItem,
            this.carsToolStripMenuItem,
            this.ClientsToolStripMenuItem,
            this.ImplementersToolStripMenuItem,
            this.письмаToolStripMenuItem});
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.guideToolStripMenuItem.Text = "Справочники";
            // 
            // componentsToolStripMenuItem
            // 
            this.componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            this.componentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.componentsToolStripMenuItem.Text = "Компоненты";
            this.componentsToolStripMenuItem.Click += new System.EventHandler(this.componentsToolStripMenuItem_Click);
            // 
            // carsToolStripMenuItem
            // 
            this.carsToolStripMenuItem.Name = "carsToolStripMenuItem";
            this.carsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.carsToolStripMenuItem.Text = "Автомобили";
            this.carsToolStripMenuItem.Click += new System.EventHandler(this.carsToolStripMenuItem_Click);
            // 
            // ClientsToolStripMenuItem
            // 
            this.ClientsToolStripMenuItem.Name = "ClientsToolStripMenuItem";
            this.ClientsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ClientsToolStripMenuItem.Text = "Клиенты";
            this.ClientsToolStripMenuItem.Click += new System.EventHandler(this.ClientsToolStripMenuItem_Click);
            // 
            // ImplementersToolStripMenuItem
            // 
            this.ImplementersToolStripMenuItem.Name = "ImplementersToolStripMenuItem";
            this.ImplementersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ImplementersToolStripMenuItem.Text = "Исполнители";
            this.ImplementersToolStripMenuItem.Click += new System.EventHandler(this.ImplementersToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComponentsListToolStripMenuItem,
            this.ComponentCarsToolStripMenuItem,
            this.OrdersToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // ComponentsListToolStripMenuItem
            // 
            this.ComponentsListToolStripMenuItem.Name = "ComponentsListToolStripMenuItem";
            this.ComponentsListToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ComponentsListToolStripMenuItem.Text = "Список компонентов";
            this.ComponentsListToolStripMenuItem.Click += new System.EventHandler(this.ComponentsListToolStripMenuItem_Click);
            // 
            // ComponentCarsToolStripMenuItem
            // 
            this.ComponentCarsToolStripMenuItem.Name = "ComponentCarsToolStripMenuItem";
            this.ComponentCarsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ComponentCarsToolStripMenuItem.Text = "Компоненты по изделиям";
            this.ComponentCarsToolStripMenuItem.Click += new System.EventHandler(this.ComponentCarsToolStripMenuItem_Click);
            // 
            // OrdersToolStripMenuItem
            // 
            this.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem";
            this.OrdersToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.OrdersToolStripMenuItem.Text = "Список заказов";
            this.OrdersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // StartWorkToolStripMenuItem
            // 
            this.StartWorkToolStripMenuItem.Name = "StartWorkToolStripMenuItem";
            this.StartWorkToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.StartWorkToolStripMenuItem.Text = "Запуск работ";
            this.StartWorkToolStripMenuItem.Click += new System.EventHandler(this.StartWorkToolStripMenuItem_Click);
            // 
            // письмаToolStripMenuItem
            // 
            this.письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            this.письмаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.письмаToolStripMenuItem.Text = "Письма";
            this.письмаToolStripMenuItem.Click += new System.EventHandler(this.письмаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 361);
            this.Controls.Add(this.buttonUpdateList);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Автомобильный завод";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView;
        private Button buttonCreateOrder;
        private Button buttonIssuedOrder;
        private Button buttonUpdateList;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem guideToolStripMenuItem;
        private ToolStripMenuItem componentsToolStripMenuItem;
        private ToolStripMenuItem carsToolStripMenuItem;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem ComponentsListToolStripMenuItem;
        private ToolStripMenuItem ComponentCarsToolStripMenuItem;
        private ToolStripMenuItem OrdersToolStripMenuItem;
        private ToolStripMenuItem ClientsToolStripMenuItem;
        private ToolStripMenuItem ImplementersToolStripMenuItem;
        private ToolStripMenuItem StartWorkToolStripMenuItem;
        private ToolStripMenuItem письмаToolStripMenuItem;
    }
}