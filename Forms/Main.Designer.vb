<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.menubar = New System.Windows.Forms.MenuStrip()
        Me.menu_file = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_sort = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_options = New System.Windows.Forms.ToolStripMenuItem()
        Me.codetree = New System.Windows.Forms.TreeView()
        Me.iconset = New System.Windows.Forms.ImageList(Me.components)
        Me.open_file = New System.Windows.Forms.OpenFileDialog()
        Me.GID_tb = New System.Windows.Forms.TextBox()
        Me.GT_tb = New System.Windows.Forms.TextBox()
        Me.gtitle_lbl = New System.Windows.Forms.Label()
        Me.GID_lbl = New System.Windows.Forms.Label()
        Me.CT_tb = New System.Windows.Forms.TextBox()
        Me.codetitle_lbl = New System.Windows.Forms.Label()
        Me.cl_tb = New System.Windows.Forms.TextBox()
        Me.cl_lbl = New System.Windows.Forms.Label()
        Me.on_rd = New System.Windows.Forms.RadioButton()
        Me.off_rd = New System.Windows.Forms.RadioButton()
        Me.cmt_tb = New System.Windows.Forms.TextBox()
        Me.cm_lbl = New System.Windows.Forms.Label()
        Me.tool_menu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.progbar = New System.Windows.Forms.ProgressBar()
        Me.save_file = New System.Windows.Forms.SaveFileDialog()
        Me.button_list = New System.Windows.Forms.CheckedListBox()
        Me.inverse_chk = New System.Windows.Forms.CheckBox()
        Me.Joker_lbl = New System.Windows.Forms.Label()
        Me.PSX_iconset = New System.Windows.Forms.ImageList(Me.components)
        Me.add_game = New System.Windows.Forms.ToolStripButton()
        Me.rem_game = New System.Windows.Forms.ToolStripButton()
        Me.Add_cd = New System.Windows.Forms.ToolStripButton()
        Me.rem_cd = New System.Windows.Forms.ToolStripButton()
        Me.save_gc = New System.Windows.Forms.ToolStripButton()
        Me.save_cc = New System.Windows.Forms.ToolStripButton()
        Me.file_new = New System.Windows.Forms.ToolStripMenuItem()
        Me.new_psp = New System.Windows.Forms.ToolStripMenuItem()
        Me.new_psx = New System.Windows.Forms.ToolStripMenuItem()
        Me.file_open = New System.Windows.Forms.ToolStripMenuItem()
        Me.file_saveas = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveas_cwcheat = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveas_pspar = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveas_psx = New System.Windows.Forms.ToolStripMenuItem()
        Me.file_exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.sort_GID = New System.Windows.Forms.ToolStripMenuItem()
        Me.sort_name = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sort_GTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sort_CTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.options_ontop = New System.Windows.Forms.ToolStripMenuItem()
        Me.options_error = New System.Windows.Forms.ToolStripMenuItem()
        Me.menubar.SuspendLayout()
        Me.tool_menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'menubar
        '
        Me.menubar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_file, Me.menu_sort, Me.menu_options})
        Me.menubar.Location = New System.Drawing.Point(0, 0)
        Me.menubar.Name = "menubar"
        Me.menubar.Size = New System.Drawing.Size(647, 24)
        Me.menubar.TabIndex = 0
        Me.menubar.Text = "MenuStrip1"
        '
        'menu_file
        '
        Me.menu_file.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.file_new, Me.file_open, Me.file_saveas, Me.file_exit})
        Me.menu_file.Name = "menu_file"
        Me.menu_file.Size = New System.Drawing.Size(37, 20)
        Me.menu_file.Text = "File"
        '
        'menu_sort
        '
        Me.menu_sort.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sort_GID, Me.sort_name})
        Me.menu_sort.Name = "menu_sort"
        Me.menu_sort.Size = New System.Drawing.Size(91, 20)
        Me.menu_sort.Text = "Sort Database"
        '
        'menu_options
        '
        Me.menu_options.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.options_ontop, Me.options_error})
        Me.menu_options.Name = "menu_options"
        Me.menu_options.Size = New System.Drawing.Size(61, 20)
        Me.menu_options.Text = "Options"
        '
        'codetree
        '
        Me.codetree.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.codetree.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codetree.ImageIndex = 0
        Me.codetree.ImageList = Me.iconset
        Me.codetree.Location = New System.Drawing.Point(4, 102)
        Me.codetree.Name = "codetree"
        Me.codetree.SelectedImageIndex = 0
        Me.codetree.Size = New System.Drawing.Size(309, 358)
        Me.codetree.TabIndex = 1
        '
        'iconset
        '
        Me.iconset.ImageStream = CType(resources.GetObject("iconset.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iconset.TransparentColor = System.Drawing.Color.Transparent
        Me.iconset.Images.SetKeyName(0, "database.png")
        Me.iconset.Images.SetKeyName(1, "sony psp.png")
        Me.iconset.Images.SetKeyName(2, "code title.png")
        Me.iconset.Images.SetKeyName(3, "code selected.png")
        '
        'open_file
        '
        Me.open_file.FileName = "*.db"
        Me.open_file.Filter = "CWcheat database (*.db)|*.db|All files (*.*)|*.*"
        '
        'GID_tb
        '
        Me.GID_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GID_tb.Enabled = False
        Me.GID_tb.Location = New System.Drawing.Point(322, 142)
        Me.GID_tb.MaxLength = 10
        Me.GID_tb.Name = "GID_tb"
        Me.GID_tb.Size = New System.Drawing.Size(74, 20)
        Me.GID_tb.TabIndex = 3
        '
        'GT_tb
        '
        Me.GT_tb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GT_tb.Enabled = False
        Me.GT_tb.Location = New System.Drawing.Point(322, 102)
        Me.GT_tb.MaxLength = 120
        Me.GT_tb.Name = "GT_tb"
        Me.GT_tb.Size = New System.Drawing.Size(320, 20)
        Me.GT_tb.TabIndex = 2
        '
        'gtitle_lbl
        '
        Me.gtitle_lbl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gtitle_lbl.AutoSize = True
        Me.gtitle_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gtitle_lbl.Location = New System.Drawing.Point(319, 81)
        Me.gtitle_lbl.Name = "gtitle_lbl"
        Me.gtitle_lbl.Size = New System.Drawing.Size(67, 15)
        Me.gtitle_lbl.TabIndex = 4
        Me.gtitle_lbl.Text = "Game Title"
        '
        'GID_lbl
        '
        Me.GID_lbl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GID_lbl.AutoSize = True
        Me.GID_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GID_lbl.Location = New System.Drawing.Point(319, 124)
        Me.GID_lbl.Name = "GID_lbl"
        Me.GID_lbl.Size = New System.Drawing.Size(56, 15)
        Me.GID_lbl.TabIndex = 5
        Me.GID_lbl.Text = "Game ID"
        '
        'CT_tb
        '
        Me.CT_tb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CT_tb.Enabled = False
        Me.CT_tb.Location = New System.Drawing.Point(322, 183)
        Me.CT_tb.MaxLength = 120
        Me.CT_tb.Name = "CT_tb"
        Me.CT_tb.Size = New System.Drawing.Size(320, 20)
        Me.CT_tb.TabIndex = 4
        '
        'codetitle_lbl
        '
        Me.codetitle_lbl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.codetitle_lbl.AutoSize = True
        Me.codetitle_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codetitle_lbl.Location = New System.Drawing.Point(319, 165)
        Me.codetitle_lbl.Name = "codetitle_lbl"
        Me.codetitle_lbl.Size = New System.Drawing.Size(62, 15)
        Me.codetitle_lbl.TabIndex = 7
        Me.codetitle_lbl.Text = "Code Title"
        '
        'cl_tb
        '
        Me.cl_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cl_tb.Enabled = False
        Me.cl_tb.Location = New System.Drawing.Point(322, 261)
        Me.cl_tb.Multiline = True
        Me.cl_tb.Name = "cl_tb"
        Me.cl_tb.Size = New System.Drawing.Size(193, 199)
        Me.cl_tb.TabIndex = 8
        '
        'cl_lbl
        '
        Me.cl_lbl.AutoSize = True
        Me.cl_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cl_lbl.Location = New System.Drawing.Point(319, 245)
        Me.cl_lbl.Name = "cl_lbl"
        Me.cl_lbl.Size = New System.Drawing.Size(58, 15)
        Me.cl_lbl.TabIndex = 9
        Me.cl_lbl.Text = "Code List"
        '
        'on_rd
        '
        Me.on_rd.AutoSize = True
        Me.on_rd.Enabled = False
        Me.on_rd.Location = New System.Drawing.Point(383, 244)
        Me.on_rd.Name = "on_rd"
        Me.on_rd.Size = New System.Drawing.Size(65, 17)
        Me.on_rd.TabIndex = 6
        Me.on_rd.Text = "Code on"
        Me.on_rd.UseVisualStyleBackColor = True
        '
        'off_rd
        '
        Me.off_rd.AutoSize = True
        Me.off_rd.Enabled = False
        Me.off_rd.Location = New System.Drawing.Point(454, 244)
        Me.off_rd.Name = "off_rd"
        Me.off_rd.Size = New System.Drawing.Size(65, 17)
        Me.off_rd.TabIndex = 7
        Me.off_rd.TabStop = True
        Me.off_rd.Text = "Code off"
        Me.off_rd.UseVisualStyleBackColor = True
        '
        'cmt_tb
        '
        Me.cmt_tb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmt_tb.Enabled = False
        Me.cmt_tb.Location = New System.Drawing.Point(322, 220)
        Me.cmt_tb.Name = "cmt_tb"
        Me.cmt_tb.Size = New System.Drawing.Size(320, 20)
        Me.cmt_tb.TabIndex = 5
        '
        'cm_lbl
        '
        Me.cm_lbl.AutoSize = True
        Me.cm_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_lbl.Location = New System.Drawing.Point(319, 203)
        Me.cm_lbl.Name = "cm_lbl"
        Me.cm_lbl.Size = New System.Drawing.Size(61, 15)
        Me.cm_lbl.TabIndex = 13
        Me.cm_lbl.Text = "Comment"
        '
        'tool_menu
        '
        Me.tool_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.add_game, Me.rem_game, Me.ToolStripSeparator2, Me.Add_cd, Me.rem_cd, Me.ToolStripSeparator1, Me.save_gc, Me.save_cc})
        Me.tool_menu.Location = New System.Drawing.Point(0, 24)
        Me.tool_menu.Name = "tool_menu"
        Me.tool_menu.Size = New System.Drawing.Size(647, 54)
        Me.tool_menu.TabIndex = 14
        Me.tool_menu.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'progbar
        '
        Me.progbar.Location = New System.Drawing.Point(4, 78)
        Me.progbar.Name = "progbar"
        Me.progbar.Size = New System.Drawing.Size(309, 18)
        Me.progbar.Step = 1
        Me.progbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progbar.TabIndex = 15
        Me.progbar.Visible = False
        '
        'save_file
        '
        Me.save_file.Filter = "CWcheat database file (*.db)|*.db"
        '
        'button_list
        '
        Me.button_list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button_list.CheckOnClick = True
        Me.button_list.Enabled = False
        Me.button_list.FormattingEnabled = True
        Me.button_list.Items.AddRange(New Object() {"SELECT", "START", "DPAD UP", "DPAD RIGHT", "DPAD DOWN", "DPAD LEFT", "L TRIGGER", "R TRIGGER", "TRIANGLE", "CIRCLE", "CROSS", "SQUARE", "HOME", "HOLD", "NOTE", "SCREEN", "VOLUME UP", "VOLUME DOWN", "WLAN UP", "REMOTE HOLD"})
        Me.button_list.Location = New System.Drawing.Point(521, 261)
        Me.button_list.Name = "button_list"
        Me.button_list.Size = New System.Drawing.Size(126, 199)
        Me.button_list.TabIndex = 9
        '
        'inverse_chk
        '
        Me.inverse_chk.AutoSize = True
        Me.inverse_chk.Enabled = False
        Me.inverse_chk.Location = New System.Drawing.Point(566, 244)
        Me.inverse_chk.Name = "inverse_chk"
        Me.inverse_chk.Size = New System.Drawing.Size(61, 17)
        Me.inverse_chk.TabIndex = 17
        Me.inverse_chk.Text = "Inverse"
        Me.inverse_chk.UseVisualStyleBackColor = True
        '
        'Joker_lbl
        '
        Me.Joker_lbl.AutoSize = True
        Me.Joker_lbl.Location = New System.Drawing.Point(518, 246)
        Me.Joker_lbl.Name = "Joker_lbl"
        Me.Joker_lbl.Size = New System.Drawing.Size(33, 13)
        Me.Joker_lbl.TabIndex = 18
        Me.Joker_lbl.Text = "Joker"
        '
        'PSX_iconset
        '
        Me.PSX_iconset.ImageStream = CType(resources.GetObject("PSX_iconset.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.PSX_iconset.TransparentColor = System.Drawing.Color.Transparent
        Me.PSX_iconset.Images.SetKeyName(0, "database.png")
        Me.PSX_iconset.Images.SetKeyName(1, "sony playstation.ico")
        Me.PSX_iconset.Images.SetKeyName(2, "code title.png")
        Me.PSX_iconset.Images.SetKeyName(3, "code selected.png")
        '
        'add_game
        '
        Me.add_game.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_game.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.add_game
        Me.add_game.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.add_game.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.add_game.Name = "add_game"
        Me.add_game.Size = New System.Drawing.Size(69, 51)
        Me.add_game.Text = "Add Game"
        Me.add_game.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'rem_game
        '
        Me.rem_game.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.rem_game.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rem_game.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.remove_game
        Me.rem_game.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.rem_game.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.rem_game.Name = "rem_game"
        Me.rem_game.Size = New System.Drawing.Size(85, 51)
        Me.rem_game.Text = "Delete Game"
        Me.rem_game.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Add_cd
        '
        Me.Add_cd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_cd.Image = CType(resources.GetObject("Add_cd.Image"), System.Drawing.Image)
        Me.Add_cd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Add_cd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Add_cd.Name = "Add_cd"
        Me.Add_cd.Size = New System.Drawing.Size(64, 51)
        Me.Add_cd.Text = "Add Code"
        Me.Add_cd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'rem_cd
        '
        Me.rem_cd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rem_cd.Image = CType(resources.GetObject("rem_cd.Image"), System.Drawing.Image)
        Me.rem_cd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.rem_cd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.rem_cd.Name = "rem_cd"
        Me.rem_cd.Size = New System.Drawing.Size(80, 51)
        Me.rem_cd.Text = "Delete Code"
        Me.rem_cd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'save_gc
        '
        Me.save_gc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save_gc.Image = CType(resources.GetObject("save_gc.Image"), System.Drawing.Image)
        Me.save_gc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.save_gc.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.save_gc.Name = "save_gc"
        Me.save_gc.Size = New System.Drawing.Size(123, 51)
        Me.save_gc.Text = "Save Game Changes"
        Me.save_gc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'save_cc
        '
        Me.save_cc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save_cc.Image = CType(resources.GetObject("save_cc.Image"), System.Drawing.Image)
        Me.save_cc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.save_cc.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.save_cc.Name = "save_cc"
        Me.save_cc.Size = New System.Drawing.Size(118, 51)
        Me.save_cc.Text = "Save Code Changes"
        Me.save_cc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'file_new
        '
        Me.file_new.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.new_psp, Me.new_psx})
        Me.file_new.Image = Global.CWcheat_Database_Editor.My.Resources.Resources._new
        Me.file_new.Name = "file_new"
        Me.file_new.Size = New System.Drawing.Size(152, 22)
        Me.file_new.Text = "New"
        '
        'new_psp
        '
        Me.new_psp.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.psp_menu
        Me.new_psp.Name = "new_psp"
        Me.new_psp.Size = New System.Drawing.Size(94, 22)
        Me.new_psp.Text = "PSP"
        '
        'new_psx
        '
        Me.new_psx.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.sony_playstation1
        Me.new_psx.Name = "new_psx"
        Me.new_psx.Size = New System.Drawing.Size(94, 22)
        Me.new_psx.Text = "PSX"
        '
        'file_open
        '
        Me.file_open.Image = CType(resources.GetObject("file_open.Image"), System.Drawing.Image)
        Me.file_open.Name = "file_open"
        Me.file_open.Size = New System.Drawing.Size(152, 22)
        Me.file_open.Text = "Open"
        '
        'file_saveas
        '
        Me.file_saveas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.saveas_cwcheat, Me.saveas_pspar, Me.saveas_psx})
        Me.file_saveas.Enabled = False
        Me.file_saveas.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.save
        Me.file_saveas.Name = "file_saveas"
        Me.file_saveas.Size = New System.Drawing.Size(152, 22)
        Me.file_saveas.Text = "Save as..."
        '
        'saveas_cwcheat
        '
        Me.saveas_cwcheat.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.psp_menu
        Me.saveas_cwcheat.Name = "saveas_cwcheat"
        Me.saveas_cwcheat.Size = New System.Drawing.Size(152, 22)
        Me.saveas_cwcheat.Text = "CWcheat"
        '
        'saveas_pspar
        '
        Me.saveas_pspar.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.psp_menu
        Me.saveas_pspar.Name = "saveas_pspar"
        Me.saveas_pspar.Size = New System.Drawing.Size(152, 22)
        Me.saveas_pspar.Text = "PSPar"
        '
        'saveas_psx
        '
        Me.saveas_psx.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.sony_playstation1
        Me.saveas_psx.Name = "saveas_psx"
        Me.saveas_psx.Size = New System.Drawing.Size(152, 22)
        Me.saveas_psx.Text = "PSX"
        '
        'file_exit
        '
        Me.file_exit.Image = CType(resources.GetObject("file_exit.Image"), System.Drawing.Image)
        Me.file_exit.Name = "file_exit"
        Me.file_exit.Size = New System.Drawing.Size(152, 22)
        Me.file_exit.Text = "Exit"
        '
        'sort_GID
        '
        Me.sort_GID.Image = CType(resources.GetObject("sort_GID.Image"), System.Drawing.Image)
        Me.sort_GID.Name = "sort_GID"
        Me.sort_GID.Size = New System.Drawing.Size(122, 22)
        Me.sort_GID.Text = "By GID"
        '
        'sort_name
        '
        Me.sort_name.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Sort_GTitle, Me.Sort_CTitle})
        Me.sort_name.Image = CType(resources.GetObject("sort_name.Image"), System.Drawing.Image)
        Me.sort_name.Name = "sort_name"
        Me.sort_name.Size = New System.Drawing.Size(122, 22)
        Me.sort_name.Text = "By Name"
        '
        'Sort_GTitle
        '
        Me.Sort_GTitle.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.sony_psp
        Me.Sort_GTitle.Name = "Sort_GTitle"
        Me.Sort_GTitle.Size = New System.Drawing.Size(136, 22)
        Me.Sort_GTitle.Text = "Game Titles"
        '
        'Sort_CTitle
        '
        Me.Sort_CTitle.Image = CType(resources.GetObject("Sort_CTitle.Image"), System.Drawing.Image)
        Me.Sort_CTitle.Name = "Sort_CTitle"
        Me.Sort_CTitle.Size = New System.Drawing.Size(136, 22)
        Me.Sort_CTitle.Text = "Code Titles"
        '
        'options_ontop
        '
        Me.options_ontop.Image = Global.CWcheat_Database_Editor.My.Resources.Resources.alwaystop
        Me.options_ontop.Name = "options_ontop"
        Me.options_ontop.Size = New System.Drawing.Size(178, 22)
        Me.options_ontop.Text = "Always On Top"
        '
        'options_error
        '
        Me.options_error.Image = CType(resources.GetObject("options_error.Image"), System.Drawing.Image)
        Me.options_error.Name = "options_error"
        Me.options_error.Size = New System.Drawing.Size(178, 22)
        Me.options_error.Text = "Show Error Window"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 462)
        Me.Controls.Add(Me.Joker_lbl)
        Me.Controls.Add(Me.inverse_chk)
        Me.Controls.Add(Me.button_list)
        Me.Controls.Add(Me.progbar)
        Me.Controls.Add(Me.tool_menu)
        Me.Controls.Add(Me.cm_lbl)
        Me.Controls.Add(Me.cmt_tb)
        Me.Controls.Add(Me.off_rd)
        Me.Controls.Add(Me.on_rd)
        Me.Controls.Add(Me.cl_lbl)
        Me.Controls.Add(Me.cl_tb)
        Me.Controls.Add(Me.codetitle_lbl)
        Me.Controls.Add(Me.CT_tb)
        Me.Controls.Add(Me.GID_lbl)
        Me.Controls.Add(Me.gtitle_lbl)
        Me.Controls.Add(Me.GT_tb)
        Me.Controls.Add(Me.GID_tb)
        Me.Controls.Add(Me.codetree)
        Me.Controls.Add(Me.menubar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.menubar
        Me.Name = "Main"
        Me.Text = "CWcheat Database Editor (v0.996)"
        Me.menubar.ResumeLayout(False)
        Me.menubar.PerformLayout()
        Me.tool_menu.ResumeLayout(False)
        Me.tool_menu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menubar As System.Windows.Forms.MenuStrip
    Friend WithEvents menu_file As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents file_open As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents file_saveas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents file_exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents codetree As System.Windows.Forms.TreeView
    Friend WithEvents open_file As System.Windows.Forms.OpenFileDialog
    Friend WithEvents iconset As System.Windows.Forms.ImageList
    Friend WithEvents GID_tb As System.Windows.Forms.TextBox
    Friend WithEvents GT_tb As System.Windows.Forms.TextBox
    Friend WithEvents gtitle_lbl As System.Windows.Forms.Label
    Friend WithEvents GID_lbl As System.Windows.Forms.Label
    Friend WithEvents CT_tb As System.Windows.Forms.TextBox
    Friend WithEvents codetitle_lbl As System.Windows.Forms.Label
    Friend WithEvents cl_lbl As System.Windows.Forms.Label
    Friend WithEvents cl_tb As System.Windows.Forms.TextBox
    Friend WithEvents off_rd As System.Windows.Forms.RadioButton
    Friend WithEvents on_rd As System.Windows.Forms.RadioButton
    Friend WithEvents cm_lbl As System.Windows.Forms.Label
    Friend WithEvents cmt_tb As System.Windows.Forms.TextBox
    Friend WithEvents tool_menu As System.Windows.Forms.ToolStrip
    Friend WithEvents add_game As System.Windows.Forms.ToolStripButton
    Friend WithEvents rem_game As System.Windows.Forms.ToolStripButton
    Friend WithEvents Add_cd As System.Windows.Forms.ToolStripButton
    Friend WithEvents rem_cd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menu_sort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sort_name As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents save_gc As System.Windows.Forms.ToolStripButton
    Friend WithEvents save_cc As System.Windows.Forms.ToolStripButton
    Friend WithEvents progbar As System.Windows.Forms.ProgressBar
    Friend WithEvents save_file As System.Windows.Forms.SaveFileDialog
    Friend WithEvents button_list As System.Windows.Forms.CheckedListBox
    Friend WithEvents inverse_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Joker_lbl As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sort_GID As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sort_GTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sort_CTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_options As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents options_error As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PSX_iconset As System.Windows.Forms.ImageList
    Friend WithEvents file_new As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents new_psp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents new_psx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents options_ontop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveas_cwcheat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveas_pspar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveas_psx As System.Windows.Forms.ToolStripMenuItem

End Class
