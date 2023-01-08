
namespace ShopWinFormsUI
{
    partial class ProductUC
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonInBasket = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(142, 136);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonInBasket
            // 
            this.buttonInBasket.Location = new System.Drawing.Point(21, 162);
            this.buttonInBasket.Name = "buttonInBasket";
            this.buttonInBasket.Size = new System.Drawing.Size(94, 29);
            this.buttonInBasket.TabIndex = 2;
            this.buttonInBasket.Text = "В корзину";
            this.buttonInBasket.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(3, 139);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(136, 20);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "label1";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonInBasket);
            this.Controls.Add(this.pictureBoxImage);
            this.Name = "ProductUC";
            this.Size = new System.Drawing.Size(140, 195);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonInBasket;
        private System.Windows.Forms.Label labelName;
    }
}
