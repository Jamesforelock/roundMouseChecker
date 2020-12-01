namespace RoundMouseChecker
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.roundMouseContainer = new RoundMouseChecker.RoundMouseContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roundMouseContainer
            // 
            this.roundMouseContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roundMouseContainer.Location = new System.Drawing.Point(12, 54);
            this.roundMouseContainer.Name = "roundMouseContainer";
            this.roundMouseContainer.Size = new System.Drawing.Size(349, 275);
            this.roundMouseContainer.TabIndex = 0;
            this.roundMouseContainer.OnRoundMouse += new System.EventHandler(this.roundMouseContainer_onRoundMouse);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Just move your mouse in a circle, get some magic.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 341);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundMouseContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Round Mouse Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundMouseContainer roundMouseContainer;
        private System.Windows.Forms.Label label1;
    }
}

