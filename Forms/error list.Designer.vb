<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class error_window
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(error_window))
        Me.list_load_error = New System.Windows.Forms.ListView
        Me.col_error = New System.Windows.Forms.ColumnHeader
        Me.col_line = New System.Windows.Forms.ColumnHeader
        Me.col_game = New System.Windows.Forms.ColumnHeader
        Me.col_title = New System.Windows.Forms.ColumnHeader
        Me.col_linetext = New System.Windows.Forms.ColumnHeader
        Me.tab_error = New System.Windows.Forms.TabControl
        Me.tab_load = New System.Windows.Forms.TabPage
        Me.tab_save = New System.Windows.Forms.TabPage
        Me.list_save_error = New System.Windows.Forms.ListView
        Me.scol_error = New System.Windows.Forms.ColumnHeader
        Me.scol_game = New System.Windows.Forms.ColumnHeader
        Me.scol_codetitle = New System.Windows.Forms.ColumnHeader
        Me.scol_reason = New System.Windows.Forms.ColumnHeader
        Me.tab_error.SuspendLayout()
        Me.tab_load.SuspendLayout()
        Me.tab_save.SuspendLayout()
        Me.SuspendLayout()
        '
        'list_load_error
        '
        Me.list_load_error.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_error, Me.col_line, Me.col_game, Me.col_title, Me.col_linetext})
        Me.list_load_error.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list_load_error.FullRowSelect = True
        Me.list_load_error.GridLines = True
        Me.list_load_error.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.list_load_error.Location = New System.Drawing.Point(3, 3)
        Me.list_load_error.MultiSelect = False
        Me.list_load_error.Name = "list_load_error"
        Me.list_load_error.Size = New System.Drawing.Size(643, 114)
        Me.list_load_error.TabIndex = 0
        Me.list_load_error.UseCompatibleStateImageBehavior = False
        Me.list_load_error.View = System.Windows.Forms.View.Details
        '
        'col_error
        '
        Me.col_error.Text = "Error #"
        Me.col_error.Width = 52
        '
        'col_line
        '
        Me.col_line.Text = "Line #"
        Me.col_line.Width = 49
        '
        'col_game
        '
        Me.col_game.Text = "Game"
        Me.col_game.Width = 94
        '
        'col_title
        '
        Me.col_title.Text = "Code Title"
        Me.col_title.Width = 178
        '
        'col_linetext
        '
        Me.col_linetext.Text = "Line Text"
        Me.col_linetext.Width = 252
        '
        'tab_error
        '
        Me.tab_error.Controls.Add(Me.tab_load)
        Me.tab_error.Controls.Add(Me.tab_save)
        Me.tab_error.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_error.Location = New System.Drawing.Point(0, 0)
        Me.tab_error.Name = "tab_error"
        Me.tab_error.SelectedIndex = 0
        Me.tab_error.Size = New System.Drawing.Size(657, 146)
        Me.tab_error.TabIndex = 1
        '
        'tab_load
        '
        Me.tab_load.Controls.Add(Me.list_load_error)
        Me.tab_load.Location = New System.Drawing.Point(4, 22)
        Me.tab_load.Name = "tab_load"
        Me.tab_load.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_load.Size = New System.Drawing.Size(649, 120)
        Me.tab_load.TabIndex = 0
        Me.tab_load.Text = "Loading Errors"
        Me.tab_load.UseVisualStyleBackColor = True
        '
        'tab_save
        '
        Me.tab_save.Controls.Add(Me.list_save_error)
        Me.tab_save.Location = New System.Drawing.Point(4, 22)
        Me.tab_save.Name = "tab_save"
        Me.tab_save.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_save.Size = New System.Drawing.Size(649, 120)
        Me.tab_save.TabIndex = 1
        Me.tab_save.Text = "Saving Errors"
        Me.tab_save.UseVisualStyleBackColor = True
        '
        'list_save_error
        '
        Me.list_save_error.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.scol_error, Me.scol_game, Me.scol_codetitle, Me.scol_reason})
        Me.list_save_error.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list_save_error.FullRowSelect = True
        Me.list_save_error.GridLines = True
        Me.list_save_error.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.list_save_error.Location = New System.Drawing.Point(3, 3)
        Me.list_save_error.MultiSelect = False
        Me.list_save_error.Name = "list_save_error"
        Me.list_save_error.Size = New System.Drawing.Size(643, 114)
        Me.list_save_error.TabIndex = 0
        Me.list_save_error.UseCompatibleStateImageBehavior = False
        Me.list_save_error.View = System.Windows.Forms.View.Details
        '
        'scol_error
        '
        Me.scol_error.Text = "Error #"
        Me.scol_error.Width = 55
        '
        'scol_game
        '
        Me.scol_game.Text = "Game"
        Me.scol_game.Width = 134
        '
        'scol_codetitle
        '
        Me.scol_codetitle.Text = "Code Title"
        Me.scol_codetitle.Width = 167
        '
        'scol_reason
        '
        Me.scol_reason.Text = "Save Error"
        Me.scol_reason.Width = 260
        '
        'error_window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 146)
        Me.Controls.Add(Me.tab_error)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "error_window"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Error List"
        Me.tab_error.ResumeLayout(False)
        Me.tab_load.ResumeLayout(False)
        Me.tab_save.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents list_load_error As System.Windows.Forms.ListView
    Friend WithEvents col_error As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_line As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_game As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_title As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_linetext As System.Windows.Forms.ColumnHeader
    Friend WithEvents tab_error As System.Windows.Forms.TabControl
    Friend WithEvents tab_load As System.Windows.Forms.TabPage
    Friend WithEvents tab_save As System.Windows.Forms.TabPage
    Friend WithEvents list_save_error As System.Windows.Forms.ListView
    Friend WithEvents scol_error As System.Windows.Forms.ColumnHeader
    Friend WithEvents scol_game As System.Windows.Forms.ColumnHeader
    Friend WithEvents scol_codetitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents scol_reason As System.Windows.Forms.ColumnHeader

End Class
