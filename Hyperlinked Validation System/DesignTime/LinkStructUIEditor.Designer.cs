namespace HyperlinkedValidationSystem.DesignTime
{
    partial class LinkStructUIEditor
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
            this.lsv_structs = new System.Windows.Forms.ListView();
            this.col_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_enabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_addStruct = new System.Windows.Forms.Button();
            this.btn_removeStruct = new System.Windows.Forms.Button();
            this.tree_objs = new System.Windows.Forms.TreeView();
            this.btn_addObj = new System.Windows.Forms.Button();
            this.btn_addCond = new System.Windows.Forms.Button();
            this.btn_removeObj = new System.Windows.Forms.Button();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.col_links = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lsv_structs
            // 
            this.lsv_structs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsv_structs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_name,
            this.col_links,
            this.col_enabled});
            this.lsv_structs.FullRowSelect = true;
            this.lsv_structs.GridLines = true;
            this.lsv_structs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsv_structs.HideSelection = false;
            this.lsv_structs.Location = new System.Drawing.Point(12, 12);
            this.lsv_structs.MultiSelect = false;
            this.lsv_structs.Name = "lsv_structs";
            this.lsv_structs.Size = new System.Drawing.Size(225, 379);
            this.lsv_structs.TabIndex = 0;
            this.lsv_structs.UseCompatibleStateImageBehavior = false;
            this.lsv_structs.View = System.Windows.Forms.View.Details;
            this.lsv_structs.SelectedIndexChanged += new System.EventHandler(this.lsv_structs_SelectedIndexChanged);
            // 
            // col_name
            // 
            this.col_name.Text = "Title";
            this.col_name.Width = 119;
            // 
            // col_enabled
            // 
            this.col_enabled.Text = "Enabled";
            // 
            // btn_addStruct
            // 
            this.btn_addStruct.Location = new System.Drawing.Point(243, 12);
            this.btn_addStruct.Name = "btn_addStruct";
            this.btn_addStruct.Size = new System.Drawing.Size(88, 23);
            this.btn_addStruct.TabIndex = 1;
            this.btn_addStruct.Text = "Add Structure";
            this.btn_addStruct.UseVisualStyleBackColor = true;
            this.btn_addStruct.Click += new System.EventHandler(this.btn_addStruct_Click);
            // 
            // btn_removeStruct
            // 
            this.btn_removeStruct.Location = new System.Drawing.Point(243, 41);
            this.btn_removeStruct.Name = "btn_removeStruct";
            this.btn_removeStruct.Size = new System.Drawing.Size(88, 23);
            this.btn_removeStruct.TabIndex = 1;
            this.btn_removeStruct.Text = "Remove";
            this.btn_removeStruct.UseVisualStyleBackColor = true;
            this.btn_removeStruct.Click += new System.EventHandler(this.btn_removeStruct_Click);
            // 
            // tree_objs
            // 
            this.tree_objs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree_objs.Location = new System.Drawing.Point(431, 12);
            this.tree_objs.Name = "tree_objs";
            this.tree_objs.Size = new System.Drawing.Size(231, 350);
            this.tree_objs.TabIndex = 2;
            this.tree_objs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_objs_AfterSelect);
            // 
            // btn_addObj
            // 
            this.btn_addObj.Location = new System.Drawing.Point(337, 12);
            this.btn_addObj.Name = "btn_addObj";
            this.btn_addObj.Size = new System.Drawing.Size(88, 23);
            this.btn_addObj.TabIndex = 3;
            this.btn_addObj.Text = "Add Object";
            this.btn_addObj.UseVisualStyleBackColor = true;
            this.btn_addObj.Click += new System.EventHandler(this.btn_addObj_Click);
            // 
            // btn_addCond
            // 
            this.btn_addCond.Location = new System.Drawing.Point(337, 41);
            this.btn_addCond.Name = "btn_addCond";
            this.btn_addCond.Size = new System.Drawing.Size(88, 23);
            this.btn_addCond.TabIndex = 3;
            this.btn_addCond.Text = "Add Condition";
            this.btn_addCond.UseVisualStyleBackColor = true;
            this.btn_addCond.Click += new System.EventHandler(this.btn_addCond_Click);
            // 
            // btn_removeObj
            // 
            this.btn_removeObj.Location = new System.Drawing.Point(337, 85);
            this.btn_removeObj.Name = "btn_removeObj";
            this.btn_removeObj.Size = new System.Drawing.Size(88, 23);
            this.btn_removeObj.TabIndex = 4;
            this.btn_removeObj.Text = "Remove";
            this.btn_removeObj.UseVisualStyleBackColor = true;
            // 
            // propGrid
            // 
            this.propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.propGrid.Location = new System.Drawing.Point(243, 114);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(182, 277);
            this.propGrid.TabIndex = 5;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(536, 368);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(127, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(431, 368);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(99, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // col_links
            // 
            this.col_links.Text = "Links";
            this.col_links.Width = 40;
            // 
            // LinkStructUIEditor
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(674, 403);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_removeObj);
            this.Controls.Add(this.btn_addCond);
            this.Controls.Add(this.btn_addObj);
            this.Controls.Add(this.tree_objs);
            this.Controls.Add(this.btn_removeStruct);
            this.Controls.Add(this.btn_addStruct);
            this.Controls.Add(this.lsv_structs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LinkStructUIEditor";
            this.Text = "LinkStructUITypeEditor";
            this.Load += new System.EventHandler(this.LinkStructUIEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsv_structs;
        private System.Windows.Forms.Button btn_addStruct;
        private System.Windows.Forms.Button btn_removeStruct;
        private System.Windows.Forms.TreeView tree_objs;
        private System.Windows.Forms.Button btn_addObj;
        private System.Windows.Forms.Button btn_addCond;
        private System.Windows.Forms.Button btn_removeObj;
        private System.Windows.Forms.PropertyGrid propGrid;
        private System.Windows.Forms.ColumnHeader col_name;
        private System.Windows.Forms.ColumnHeader col_enabled;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ColumnHeader col_links;

    }
}