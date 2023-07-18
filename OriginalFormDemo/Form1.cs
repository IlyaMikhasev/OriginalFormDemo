using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OriginalFormDemo
{
    public partial class Form1 : Form
    {
        Point pointStart; // точка для перемещения
        Button buttonClose;


        private void addCloseButton() 
        {
            // Кнопка закрытия
            buttonClose = new Button();
            buttonClose.Location = new Point(this.Width / 3, this.Height / 3);
            buttonClose.Text = "Х";
            buttonClose.Click += buttonClose_Click;
            this.Controls.Add(buttonClose); 
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addChoiceForm()
        {
            ComboBox cmbChoice = new ComboBox();
            cmbChoice.Location = new Point(this.Width/3, this.Height/3 + 30);
            var items = new object[] { "normal", "ellipse", "polygon" };
            cmbChoice.Items.AddRange(items);
            cmbChoice.SelectedValueChanged += CmbChoice_SelectedValueChanged;
            this.Controls.Add(cmbChoice);
        }

        private void CmbChoice_SelectedValueChanged(object sender, EventArgs e)
        {
            OrigWindow.setOriginalForm(this, ((ComboBox)sender).SelectedItem.ToString());
            OrigWindow.setOriginalButton(this.buttonClose, this.Size, ((ComboBox)sender).SelectedItem.ToString());
        }

        public Form1()
        {
            InitializeComponent();
            addCloseButton();
            addChoiceForm();
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                pointStart = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if ((e.Button & MouseButtons.Left) != 0)
            {
                // получаем новую точку положения формы
                Point deltaPos = new Point(e.X - pointStart.X, e.Y - pointStart.Y);
                // устанавливаем положение формы
                this.Location = new Point(this.Location.X + deltaPos.X,
                  this.Location.Y + deltaPos.Y);
            }
        }

        
        
    }
}
