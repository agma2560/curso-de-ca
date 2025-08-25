namespace Async03
{
    partial class FrmAsync
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsync));
            btnPrueba = new Button();
            pbImagen = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            SuspendLayout();
            // 
            // btnPrueba
            // 
            btnPrueba.Location = new Point(192, 275);
            btnPrueba.Name = "btnPrueba";
            btnPrueba.Size = new Size(75, 23);
            btnPrueba.TabIndex = 0;
            btnPrueba.Text = "Prueba";
            btnPrueba.UseVisualStyleBackColor = true;
            btnPrueba.Click += btnPrueba_Click;
            // 
            // pbImagen
            // 
            pbImagen.Image = (Image)resources.GetObject("pbImagen.Image");
            pbImagen.Location = new Point(137, 51);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(196, 179);
            pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;
            pbImagen.TabIndex = 1;
            pbImagen.TabStop = false;
            pbImagen.Visible = false;
            // 
            // FrmAsync
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 317);
            Controls.Add(pbImagen);
            Controls.Add(btnPrueba);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmAsync";
            Text = "Async";
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPrueba;
        private PictureBox pbImagen;
    }
}
